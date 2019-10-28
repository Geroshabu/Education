## 補足 : 式とステートメント

式は、「評価」すると、「結果」が返るもの。例えば次のようなもの。

* `operand1 + operand2`
* `i++`
* `i = 0`
* `instance.ToString()`
* `new User("Geroshabu")`

式の結果には型がある。
void型も、評価して得られた「結果」と考えてもいいかもしれない。強引かな。

ステートメントは、式を組み合わせたもの。あと制御構文とか。
式を組み合わせると、ステートメントの区切りが分からないので、末尾に「;」が必要。

* `int result = operand1 + operand2;`
* `i++;`
* `if (i < 0) { i = 0; }`
* `return "My name is" + new User("Geroshabu").ToString();`
