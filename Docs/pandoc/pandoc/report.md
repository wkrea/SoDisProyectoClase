---
documentclass: ltjsarticle
title: すごいレポート
author: 寿限無
header-includes:
  - \usepackage[margin=1in]{geometry}

figureTitle: "図 "
tableTitle: "表 "
listingTitle: "コード "
figPrefix: "図."
eqnPrefix: "式."
tblPrefix: "表."
lstPrefix: "コード."
---

# 見出し
## 見出し
いい感じの文章を書いてレポートの本文をうめていく。改行したいときは見難いがこのように→  
スペースを 2 つつければ改行できる

1 行空行を空けると[^1]別のパラグラフになる。

![すごい図[^fig]](./inteligencia-artificial.jpg){#fig:sugoi}

![この図はちょっと大きいから調整する](inteligencia-artificial.jpg){#fig:sugoi-large height=60mm}

| i | サイコロの目 |
|------:|:------:|
| 1 | 3 |
| 2 | 2 |
| 3 | 6 |
| 4 | 5 |
| 5 | 1 |
| 6 | 4 |
| 7 | 2 |
| 8 | 6 |

:すごい表 {#tbl:table}


| サンプル | 見た目 / ${\rm m^2 \cdot kg \cdot s^{-3} \cdot A^{-1}}$ | 雰囲気 / ${\rm m^{-2} \cdot kg^{-1} \cdot s^{4} \cdot A^{2}}$ |
|:---------:|----------------------:|----------------------:|
| ポカリスエット | 2 | 40 |
| アクエリアス | 2 | 21 |
| ダカラ | 3 | 8 |

:へんな表 {#tbl:table-long}



この辺で改ページ
\clearpage

## 注意
1. [@fig:sugoi] は普通の図
1. [@fig:sugoi-large] のような大きい図を貼るときは height=70mm などとして適当に調整する
1. [@tbl:table] のように表にラベルをつけるときは `:タイトル {#tbl:tabl}` のように `{}` の前にスペースが必要
1. [@tbl:table-long] のように表のヘッダーが長いときは `:-----------------------:` みたいに 2 行目の `-` を増やせば表の横幅が広くなったりする

## いろいろな式
### インラインの式
本文中に唐突に $E = mc^2$ 埋め込む。

インラインの式中に $a_n = \frac{1}{\pi} \int_{0}^{2\pi} f(x) \cos nx dx$ のような分数やインテグラルが入るとちょっと見にくくなるので、$\displaystyle b_n = \frac{1}{\pi} \int_{0}^{2\pi} f(x) \sin nx dx$ とすると見やすくなる。


### よくある式
$$f(x) = \frac{a_0}{2} + \sum_{n = 1}^{\infty} a_n \cos nx + b_n \sin nx$${#eq:fourier}

こうやって [@eq:fourier] 参照する。

### よくつかうギリシャ文字たち
$\alpha, \beta, \gamma, \delta, \Delta, \varepsilon, \theta, \lambda, \mu, \nu, \pi, \rho, \sigma, \Sigma, \tau, \phi, \omega$

$$\frac{\partial f}{\partial y} \frac{d f}{d x}$$


## ソースコード
``{#lst:awesome-code .javascript .numberLines startFrom="10" caption="すごいコード"}
var gulp = require("gulp");
var browserify = require("browserify");
var source = require("vinyl-source-stream");

gulp.task("es6", function() {
  return browserify("./src/app.js")
    .transform("babelify")
    .bundle()
    .pipe(source("bundle.js"))
    .pipe(gulp.dest("dist"));
});
``

↑↓ホントはバッククォートは3つ書いてください


``
$ cd
$ mkdir -p projectX
$ pbpaste > projectX/gulpfile.js
``

[@lst:awesome-code] のようにするとシンタックスハイライトもできるし行番号もつけれたりするが、長いコードだとページ上の配置や改ページが微妙になることがあってあまり使い勝手がよくなかったりする。  
どうせ白黒で印刷するなら下の例のようにしたほうがいい。

### 見出し
#### 見出し
##### 見出し

# 参考文献 {-}
`{-}` をつけるとこのセクションには見出しに通し番号がつかなくなる

- 箇条書き
- 箇条書き
    - ネスト
    - ネスト
    - ネスト
