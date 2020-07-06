#! /usr/bin/env python
# -*- coding: utf-8 -*-

# Generate PDF from markdown.  Requires pandoc, a recent
# python-pandocfilters and TeX with following packages:
# texlive-babel-german, texlive-inconsolata, texlive-opensans, texlive-mdframed,
# texlive-hyphen-german, texlive-glossaries-german
# Later maybe also:
# texlive-xelatex-bin, texlive-mathspec, texlive-euenc, texlive-polyglossia,

import sys
import os
import argparse
import subprocess
import json
import re
import yaml
import shlex

_force_help = False
try:
    from pandocfilters import toJSONFilter, walk, stringify
    from pandocfilters import elt, Para, Plain, Str, Header, Image, RawInline, RawBlock
except:
    print('=> pandocfilters module is required to execute this program')
    _force_help = True


def doc_meta(doc):
    return doc.setdefault('meta', {})

def doc_version(doc):
    return doc.setdefault('pandoc_api_version', [1,17,3])

def doc_blocks(doc):
    return doc.setdefault('blocks', [])

def RawTexPara(tex):
    return Para([RawInline('latex', tex)])

def BookPart(title):
    titlestr = stringify(title)
    partcmd = r'\part{%s}' % titlestr
    return RawTexPara(partcmd)

RE_HEADER_REF = re.compile(r'\W+', re.UNICODE)
def MakeHeader(level, title):
    titlestr = stringify(title)
    ref = RE_HEADER_REF.sub('-', titlestr)
    ref = ref.rstrip('-').lower()
    return Header(level, [ref, [], []], [Str(titlestr)])

IMAGE_PATH = os.path.dirname(os.path.abspath(__file__))
PANDOC = 'pandoc'
LC = 'en'
PAPERSIZE = 'a4'
TOC = True
NUMBERSECTIONS = True
OUT_FORMAT = "json"
IN_FORMAT = "markdown"

def to_json(args, filename='', from_format=IN_FORMAT, from_ext='', to_format=OUT_FORMAT, to_ext='', pandoc_opts=None, stdincontent=None):
    _command = [args.pandoc, "-f", from_format+from_ext, "-t", to_format+to_ext]
    _command.extend(shlex.split(' '.join(args.panopts if not pandoc_opts else pandoc_opts)))
    if filename:
        _command.append(filename)
        data = subprocess.check_output(_command)
    else:
        po = subprocess.Popen(_command, stdin=subprocess.PIPE, stdout=subprocess.PIPE)
        _kwargs = {'input': stdincontent}
        try:
            data, _stderr = po.communicate(**_kwargs)
        except OSError as ex:
            os_except = ex
    return json.loads(data) if to_format==OUT_FORMAT else data

# Generic filter
def fix_header_ref(key, value, to_format, _meta):
    if key == 'Header':
        level, ref, content = value
        # Hugo removes . and - from header before creating the anchor, while pandoc does not.
        # This can create duplicated hyphens, which we replace here.
        ref_label = ref[0]
        ref_label = RE_HEADER_REF.sub("-", ref_label)
        ref_label = ref_label.rstrip("-")
        ref = [ref_label] + ref[1:]
        return Header(level, ref, content)
    return None

def fix_image_ref(key, value, to_format, _meta):
    if key == 'Image':
        try:
            [[ident, classes, keyvals], alt, [image_path, title]] = value
        except:
            return None
        #_, _, keyvals = get_caption(keyvals)
        # Replace leading '/' with relative path to images/.
        if image_path.startswith('/'):
            image_path = os.path.join(IMAGE_PATH, "static", image_path[1:])
            return Image([ident, classes, keyvals], alt, [image_path, title])
    return None

RE_NOTE = re.compile(r'''\s*([a-z]+)(?:\s+title\s*=\s*"([^"]*)")?\s*''')
RE_NOTE_END = re.compile(r'''\s*/\s*([a-z]+)\s*''')
fix_notes_buffer = None
def fix_notes(key, value, to_format, _meta):
    global fix_notes_buffer
    if key == 'Str' and value == '{{<':
        fix_notes_buffer = ""
        return Str("")
    elif key == 'Str' and value == '>}}':
        if fix_notes_buffer is not None:
            buffer = fix_notes_buffer
            fix_notes_buffer = None

            mtb = RE_NOTE.match(buffer)
            mte = RE_NOTE_END.match(buffer)
            if mtb is not None:
                note_type, label = mtb.groups()
                if label is None:
                    return RawInline('latex', r'\begin{%s}' % note_type)
                else:
                    return RawInline('latex', r'\begin{%s}[frametitle=%s]' % (note_type, label))
            elif mte is not None:
                note_type = mte.groups()
                return RawInline('latex', r'\end{%s}' % note_type)
            else:
                return Str("{{< %s >}}" % buffer)
            return ret
    elif fix_notes_buffer is not None:
        fix_notes_buffer += stringify([{'t': key, 'c': value}])
        return Str("")
    return None

RE_YAML_METADATA_BLOCK_CONTENTS = re.compile(r'^---\s+(.*)^(-{3}|\.{3})\s+.*$', re.UNICODE | re.MULTILINE | re.DOTALL)
_HEADER_INCLUDES = 'header-includes'

def book_add_metadata(args, doc, documentclass="book"):
    default_meta = {
        'documentclass': documentclass,
        'lang': args.lang,
        'papersize': args.papersize,
        'toc': str(args.toc),
        'numbersections': str(args.number_sections),
        _HEADER_INCLUDES: [
            r'`\PassOptionsToPackage{xcolor}{mdframed}`{=latex}',
            r'`\usepackage{mdframed}`{=latex}',
            r'`\newmdenv[linewidth=0pt,skipabove=\topskip,skipbelow=\topskip,backgroundcolor=red!10]{warning}`{=latex}',
            r'`\newmdenv[linewidth=0pt,skipabove=\topskip,skipbelow=\topskip,backgroundcolor=blue!10]{note}`{=latex}',
            #r'`\newmdenv[topline=false,bottomline=false,linecolor=red,linewidth=3pt,skipabove=\topskip,skipbelow=\topskip]{warning}`{=latex}',
        ]
    }
    if args.author is not None:
        default_meta['author'] = args.author
    file_meta = {}
    def update_default_meta(matchgroup):
        if matchgroup:
            _meta = yaml.safe_load(matchgroup.group(1))
            _meta_header_includes = _meta.get(_HEADER_INCLUDES, [])
            default_header_includes = default_meta.get(_HEADER_INCLUDES, [])
            new_header_includes = [e for e in _meta_header_includes if e not in default_header_includes]
            default_header_includes.extend(new_header_includes)
            default_meta.update(_meta)
            default_meta[_HEADER_INCLUDES] = default_header_includes
            return True
        return False

    if args.metadata is not None:
        update_default_meta(RE_YAML_METADATA_BLOCK_CONTENTS.match(args.metadata.read()))
    with open(args.book if args.book else args.article, 'r') as f:
        doc_content = f.read()
        if not update_default_meta(RE_YAML_METADATA_BLOCK_CONTENTS.match(doc_content)):
            doc_content_with_meta = to_json(args, None, to_format='markdown', pandoc_opts=['-s'], stdincontent=doc_content)
            update_default_meta(RE_YAML_METADATA_BLOCK_CONTENTS.match(doc_content_with_meta))

    default_meta_as_yaml = "---\n"+yaml.safe_dump(default_meta, default_flow_style=False)+"---\n"
    default_meta_json = doc_meta(to_json(args, None, from_ext=args.from_ext, stdincontent=default_meta_as_yaml))
    doc['meta'] = default_meta_json
    return doc

def book_add_part(args, doc, part):
    meta = doc_meta(part)
    part = BookPart(meta.get('title', 'MISSING TITLE'))
    doc_blocks(doc).append(part)
    return doc

def chapter_header_level(key, value, to_format, _meta):
    if key == 'Header':
        level, ref, content = value
        # Move all header elements one up, because material doc theme reserves h1 for the theme and starts with h2.
        level = level - 1
        return Header(level if level >= 0 else 0, ref, content)
    return None

def book_add_chapter(args, doc, chapter):
    MetaString = elt('MetaString', 1)
    meta = doc_meta(chapter)
    header = meta.get('title', MetaString('MISSING TITLE'))
    header = MakeHeader(1, header)
    doc_blocks(doc).append(header)

    content = doc_blocks(chapter)

    actions = [fix_notes] #chapter_header_level, fix_header_ref, fix_image_ref, fix_notes]
    content = reduce(lambda x, action: walk(x, action, OUT_FORMAT, meta), actions, content)
    doc_blocks(doc).extend(content)
    return doc

def article_add_chapter(args, doc, chapter):
    meta = doc_meta(chapter)
    content = doc_blocks(chapter)

    actions = [fix_notes] #[chapter_header_level, fix_header_ref, fix_image_ref, fix_notes]
    content = reduce(lambda x, action: walk(x, action, OUT_FORMAT, meta), actions, content)
    doc_blocks(doc).extend(content)
    return doc

def arg_parser():

    # In args.parts, we end up with a list of (part, chapters) tuples (first part may be None).
    class ChaptersAction(argparse.Action):
        def __init__(self, option_strings, dest, **kwargs):
            super(ChaptersAction, self).__init__(option_strings, dest, **kwargs)
        def __call__(self, parser, namespace, values, option_string=None):
            parts = getattr(namespace, 'parts', None)
            if parts is None:
                parts = []
            parts.append((namespace.part, values))
            namespace.part = None
            namespace.chapters = None
            setattr(namespace, 'parts', parts)

    parser = argparse.ArgumentParser(description='generate a book from multiple pandoc documents')
    parser.add_argument('--pandoc', metavar='FILE', type=str, default=PANDOC, help='path to pandoc binary (default: %s)' % PANDOC)
    parser.add_argument('--pandoc-option', metavar='OPTION', type=str, dest='panopts', action='append',default=[], help='pandoc option like filters etc')
    parser.add_argument('--from-format', metavar='STRING', type=str, dest='from_format', default=IN_FORMAT, help='input format (default: %s)' % IN_FORMAT)
    parser.add_argument('--from-ext', metavar='STRING', type=str, dest='from_ext', default='', help='input format extension')
    parser.add_argument('--to-format', metavar='STRING', type=str, dest='to_format', default=OUT_FORMAT, help='output format (default: %s)' % OUT_FORMAT)
    parser.add_argument('--to-ext', metavar='STRING', type=str, dest='to_ext', default='', help='output format extension')

    parser.add_argument('--metadata', metavar='FILE', type=argparse.FileType('r'), help='path to valid meta data yaml file')

    parser.add_argument('--lang', metavar='LC', type=str, default=LC, help='language code (default: %s)' % LC)
    parser.add_argument('--papersize', metavar='FORMAT', type=str, default=PAPERSIZE, help='papersize (default: %s)' % PAPERSIZE)
    parser.add_argument('--toc', metavar='BOOL', type=bool, default=TOC, help='toc (default: %s)' % TOC)
    parser.add_argument('--number-sections', metavar='BOOL', type=bool, default=NUMBERSECTIONS, help='number sections (default: %s)' % NUMBERSECTIONS)

    parser.add_argument('--author', metavar='STRING', type=str, help='document author')

    parser.add_argument('--book', metavar='FILE', type=str, help='start a book with this file')
    parser.add_argument('--part', metavar='FILE', type=str, help='start a new part in a multi-volume book')
    parser.add_argument('--chapters', metavar='FILE', type=str, action=ChaptersAction, nargs='*', help='chapters in the book or part')

    parser.add_argument('--article', metavar='FILE', type=str, help='start an article with this file')
    args = parser.parse_args()
    if _force_help:
        parser.print_help()
        sys.exit()
    # Normalize parts member.
    parts = getattr(args, 'parts', None)
    if parts is None:
        parts = []
    args.parts = parts

    # Prepare title and metadata.
    doc = None
    if args.book is not None:
        doc = to_json(args, args.book, from_ext=args.from_ext)
        book_add_metadata(args, doc)
        if len(doc_blocks(doc)) > 0:
            # Add a silent chapter for the preambel.
            header = RawTexPara(r"\chapter*{%s}" % stringify(doc_meta(doc).get('title', Str('Einleitung'))))
            doc_blocks(doc).insert(0, header)

        for part, chapters in args.parts:
            if part is not None:
                part = to_json(args, part, from_ext=args.from_ext)
                book_add_part(args, doc, part)
                if len(doc_blocks(part)) > 0:
                    # Add a silent chapter for the preambel.
                    header = RawTexPara(r"\chapter*{%s}" % stringify(doc_meta(part).get('title', Str('Einleitung'))))
                    doc_blocks(doc).append(header)
                    doc_blocks(doc).extend(doc_blocks(part))
            for chaptername in chapters:
                chapter = to_json(args, chaptername, from_ext=args.from_ext)
                book_add_chapter(args, doc, chapter)
    elif args.article is not None:
        doc = to_json(args, args.article, from_ext=args.from_ext)
        book_add_metadata(args, doc, documentclass="article")

        chapter = {'meta':doc_meta(doc), 'blocks':doc_blocks(doc)[:], 'pandoc_api_version':doc_version(doc)}
        doc_blocks(doc)[:] = []
        article_add_chapter(args, doc, chapter)
    else:
        parser.print_help()

    if doc:
        print ('%s' % json.dumps(doc))

if __name__ == '__main__':
    arg_parser()
