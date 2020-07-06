# GitLab-Pandoc Markdown Cheat Sheet

See this document as a collection of best practices on how to write
Markdown files being nicely rendered on GitLab and producing good
looking PDF docs generated using pandoc.

This requires that our Markdown has primarily to be GitLab compatible
with the possibility to adjust/style for other media. To achieve this we
have to make use of [filters](#filters) to tailor the [*GitLab flavoured
Markdown*](https://docs.gitlab.com/ce/user/markdown.html) file for use
with pandoc.

View this file as [PDF output on
GitLab](/../-/jobs/artifacts/master/file/CheatSheet/CheatSheet.pdf?job=CheatSheet)

View this file as [downloaded PDF](/../-/jobs/artifacts/master/raw/CheatSheet/CheatSheet.pdf?job=CheatSheet)

## Filters

[Pandoc](https://pandoc.org) allows using either Haskell or Python
programs which act as filters on the processed content. Filters can be
used to modify the structure or contents of the document before going
through the output processor.

To use Python filters, the Python package
[`pandocfilters`](https://github.com/jgm/pandocfilters) must be
installed for your Python version. Check the examples section of the
repository to get an overview and examples what can be done.

### Special link treatment (`gitlab_links.py`)

Using the
[`gitlab_links.py`](/../../../m1huber/pandocfilters/blob/master/gitlab_links.py)
filter, `/../` prefixes in internal references will be replaced with the
correct project url. Relative links, `./` and `../` will not be touched
to allow relative file reference in conjunction with the `adaptformat`
replacement.

#### Other namespace/project reference

To reference a project in another namespace, special relative movement
within the link target is required. We even need to explicitly specify
`blob/master` or something similar to point to the correct repository
revision.

Example link format

    [gitlab_links.py](/../../../m1huber/pandocfilters/blob/master/gitlab_links.py)

#### `?adaptformat[=extension]` or `?af[=extension]`

In order to preserve relative links in `HTML` or `PDF` output, add
`adaptformat` or `af` (short form) as query attribute to the link
reference. This will keep relative links to Markdown (`.md`) files but
change the extension to either `.html` for `HTML[5]` output or `.pdf`
for `latex` output.

Example link format:

    [Link name](../path/to/file.md?af)

results in (HTML pseudocode):

    href='../path/to/file.html'

### Hidden content, aka solution filtering (`inline_solutions.py`)

To conditionally hide content from being shown on GitLab and in an
output file, wrap it inside an HTML comment block like shown here:

    <!-- SOLUTION
    -   Solutions Entry

        This content is visible in generated file using inline_solutions.py filter.
    SOLUTION -->

To enable its content, the
[`inline_solutions.py`](m1huber/pandocfilters/inline_solutions.py)
filter is used. See the full PDF output
[here](/../-/jobs/artifacts/master/file/CheatSheet/CheatSheet-Solutions.pdf?job=CheatSheet)

<!-- SOLUTION
-   Solutions Entry

    This content was enabled using filter [`inline_solutions.py`](m1huber/pandocfilters/inline_solutions.py).
SOLUTION -->
### Git commit marking (`gitinfo2`)

This \LaTeX package can be used to mark documents with a Git version. It
is included in the debian package `texlive-latex-extra` or can be
retrieved at its [GitHub origin](https://github.com/Hightor/gitinfo2)
location.

tbd. [eisvogel
template](https://github.com/Wandmalfarbe/pandoc-latex-template)
contains extension

***Version matching***

The hook used to create a latex style Git description assumes that your
tags follow this convention: `[0-9]*.*`. If your tags are prefixed or
look different, you need to adapt the variable
[`RELTAG`](hooks/post-checkout#L12) in
[`hooks/post-checkout`](hooks/post-checkout). According to [`git describe`
docs](https://git-scm.com/docs/git-describe#git-describe---matchltpatterngt),
it is a glob string so take care.

## References / Links

**Explicit external reference:**

`[pgAdmin](https://www.pgadmin.org/)` $`\Rightarrow`$ [pgAdmin](https://www.pgadmin.org/)

**Implicit external reference:**

`<https://www.pgadmin.org/>` $`\Rightarrow`$ <https://www.pgadmin.org/>

**Reference to repository file or directory:**

`[pandoc metadata yaml](CheatSheet/pandoc_meta.yaml)` $`\Rightarrow`$ [pandoc metadata yaml](CheatSheet/pandoc_meta.yaml)

**Relative reference to repository file:**

`[README](./README.md)` $`\Rightarrow`$ [README](./README.md)

**Rewrite file extension in output format (pdf/html/...):**

Uses [adaptformat](#adaptformatextension-or-afextension) extension

`[extension adapted README.pdf/html/custom](./README.md?adaptformat)` $`\Rightarrow`$ [extension adapted README.pdf/html/custom](./README.md?adaptformat)

**Reference to file/dir on different branch:**

`[Solutions Readme](/../tree/Demo-Solutions/CheatSheet/README.solutions.md)` $`\Rightarrow`$ [Solutions Readme](/../tree/Demo-Solutions/CheatSheet/README.solutions.md)

**View (`file`) latest artifacts file in GitLab:**

`[In-browser PDF](/../-/jobs/artifacts/master/file/CheatSheet/CheatSheet.pdf?job=CheatSheet)` $`\Rightarrow`$ [In-browser PDF](/../-/jobs/artifacts/master/file/CheatSheet/CheatSheet.pdf?job=CheatSheet)

**Download (`raw`) latest artifacts file:**

`[Download PDF](/../-/jobs/artifacts/master/raw/CheatSheet/CheatSheet.pdf?job=CheatSheet)` $`\Rightarrow`$ [Download PDF](/../-/jobs/artifacts/master/raw/CheatSheet/CheatSheet.pdf?job=CheatSheet)

**Browse latest job artifacts:**

`[latest artifacts](/../-/jobs/artifacts/master/browse/?job=CheatSheet)` $`\Rightarrow`$ [latest artifacts](/../-/jobs/artifacts/master/browse/?job=CheatSheet)

**Internal reference to heading (anchor):**

`[Filters](#filters)` $`\Rightarrow`$ [Filters](#filters)


## Source Code formatting / Code Blocks

Please stick to the following convention to specify code blocks.

-   Multi line blocks should be introduced with three backticks followed
    by a space and the language

        ``` sql
        SELECT * from Angestellter;
        ```

    results in

    ``` sql
    SELECT * from Angestellter;
    ```

-   Inline Code blocks use single backticks and can not contain language
    specifiers on GitLab.

        `int main()`

## Tables

It is best to stick with pipe-tables to have nice output on GitLab and
in PDF output. [Formatting the
table](https://pandoc.org/MANUAL.html#extension-pipe_tables) is a bit
tricky as the width and proportions of the *separator lines* are
relevant. According to the docs, `--columns` should be 72 but it seems
to be 80 for the current document. Therefore you should spend at most 80
characters for column formatting. As an example you can look at the
formatting of the [references links table](#references-links) in the
[source](CheatSheet/README.md#L16) of this document. If table contents
are narrower than the reserved space, the table will shrink
appropriately.

A table formatted like the following

    | **titel**  |  **bitmap**|
    |:-----------|-----------:|
    | Prof.      |  1000111101|
    | Dr.        |  0110000010|
    | Dr. habil. |  0001000000|

results in:

| **titel**  |  **bitmap**|
|:-----------|-----------:|
| Prof.      |  1000111101|
| Dr.        |  0110000010|
| Dr. habil. |  0001000000|

## Images / Figures

It is possible to insert images and figures either *inline* or
*floating*.

### inline

An inline image should render inline

![Link name](HSR_Logo_trans_56mm_300dpi.png){width="30%"}\

with your text depending on the output format and the layout engine.

To include an *inline* image, use the following syntax:

    ![Link name](HSR_Logo_trans_56mm_300dpi.png){width="30%"}\

Note the trailing backslash which is **important**.

## floating but referrable

A *floating* image will be placed somewhere around your text but its
position can not be influenced. Instead you can [reference](#idifs) your
image to let your document viewer possibliy jump to it. It can contain a
caption (figure text) and some other options.

![Figure
description](IFS_Institute_for_Software_trans_56mm_300dpi.png "some text"){#idifs
.class width="30%"}

To include a *floating* image, use the following syntax:

    ![Figure description](IFS_Institute_..._56mm_300dpi.png "some text"){#idifs .class width="30%"}

## Plantuml / Graphviz

[Plantuml](http://plantuml.com/) can be used to dynamically render
images base on text input. Many different
[languages](http://plantuml.com/sitemap-language-specification) are
supported including [`graphviz`/`dot`](http://plantuml.com/dot)
capabilities.

### Sequence diagram

    ``` plantuml
    a->b
    ```

``` plantuml
a->b
```

## Math (\LaTeX style Math)

    $`a^2+b^2=c^2`$

$`a^2+b^2=c^2`$

    $`N + M * \frac{N}{(B-2)} = 50 + 1000 * \frac{50}{50} = 1050`$

$`N + M * \frac{N}{(B-2)} = 50 + 1000 * \frac{50}{50} = 1050`$

## Styling Output

To override the default templates, customized templates can be used.
Default search directory is
[`$HOME/.pandoc`](https://pandoc.org/MANUAL.html) but can be overriden
specifying `--data-dir=/my/templates/path`. `--template=myfancytemplate`
specifies to use `myfancytemplate.latex` in case \LaTeX output is
requested.

## Cross referencing `pandoc-crossref`

If you want to use cross referencing of sections, figures etc.,
[`pandoc-crossref`](https://github.com/lierdakil/pandoc-crossref) is the
tool you might need.

### Section numbering

tbd.

### Figure / Image / Code references

tbd.

## Emoji and Special/Unicode characters

Rendering special characters, like unicode and emoji, require a capable
font. A font which is partly capable of displaying Unicode characters is
`DejaVuSerif`. Set `mainfont=DejaVuSerif` to make use of it.

A more capable font is `FreeSerif` as it has more Unicode characters
available and also supports emojis. It seems to be a bit narrower than
the default font but its output looks quite nice.

When changing the font is not an option, I recommend using latex Boxes
for best results in both GitLab and PDF output:

-   $`\Box`$ latex `\Box`
-   $`\boxtimes`$ latex `\boxtimes`
-   [ ] Hallo - will be rendered as HTML checkbox on GitLab
-   [X] Gugus - will be rendered as HTML checkbox on GitLab
-   :white_medium_square: unchecked
-   :ballot_box_with_check: checked
-   &#9744; unchecked unicode [Unicode Chars](http://unexpected-vortices.com/doc-notes/some-common-unicode-characters.html)
-   &#9745; checkmarked unicode
-   &#9746; checked unicode

Emoji's like `:zap:`, :zap:, are possible when using a capable font setting like `mainfont=FreeSerif`.

---
keywords:
- pandoc
- Markdown
- GitLab
title: 'gitlab/pandoc Markdown CheatSheet'
listings-disable-line-numbers: True
---
