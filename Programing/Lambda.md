# ラムダ式

## 前提知識

[メソッドを表す型](./VariableForFunction.md)の知識が必要。
先にそちらの内容を理解しておくこと。

## ラムダ式を使わない例

これは、[以前](./VariableForFunction.md)練習問題として考えた、計算器クラスの例である。
この計算器は、計算方法を外部から受け取れるようにすることで、様々な計算方法の拡張を可能としている。

C#

```csharp
public void Execute()
{
    Calculator calculator = new Calculator();
    calculator.AddOperator(Operator.Add, add);
    Console.WriteLine(calculator.Calculate(Operator.Add, 12, 30)); // 出力 : 42
}

private int add(int a, int b) { return a + b; }
```

Java

```java
public void execute() {
    Calculator calculator = new Calculator();
    calculator.addOperator(Operator.Add, this::add);
    System.out.println(calculator.calculate(Operator.Add, 12, 30)); // 出力 : 42
}

private Integer add(Integer a, Integer b) { return a + b; }
```

この計算器は、上記のように、計算方法を自由に設定できて大変すばらしいのだが、この使用例には次のような問題がある。

### 関数のスコープが大きくなる
`add` などのメソッドは、計算器インスタンスに指定するためだけに使われるが、`Sample` インスタンス内のどこからでも参照できてしまう。関係のないメンバからは、これらの関数を見えないようにしたい。

### いちいち関数を定義するのがめんどくさい
関数を定義するには、引数と戻り値の型や、名前を書かなければならない。プログラミングをするときは、名前を考えるのに結構な時間をとられるだろう。またちょっとした処理だと、いちいち定義するとかえってコードを読むのに邪魔になったりするかもしれない。

そこで登場するのが、ラムダ式だ。

# ラムダ式の例
例えば、

C#

```csharp
public void Execute()
{
    Func<int, int, int> method = add;
}
int add(int operand1, int operand2) { return operand1 + operand2; }
```

Java

```java
public void execute() {
    IntBinaryOperator method = this::add;
}
int add(int operand1, int operand2) { return operand1, operand2; }
```

のような、`method` に関数を割り当てるコードは、ラムダ式を用いると次のようになる。

C#

```csharp
public void Execute()
{
    Func<int, int, int> method = (operand1, operand2) => operand1 + operand2;
}
```

Java

```java
public void execute() {
    IntBinaryOperator method = (operand1, operand2) -> operand1 + operand2;
}
```

さっきよりシンプルになった。

## ラムダ式の構文

先ほどの例の、代入式「=」の右辺にあるのがラムダ式だ。
![Lambda_part.png](./Lambda_part.png)

ちなみに末尾の「;」は、このステートメント末尾の「;」であって、ラムダ式の一部ではない。
ごちゃまぜにすると、理解が遠のくかもしれないので、念のため。

このラムダ式の部分が、関数を表している。
ラムダ式は、次のような形式となっている。

C#

![Lambda_csharp.png](./Lambda_csharp.png)

Java

![Lambda_java.png](./Lambda_java.png)

**「仮引数」を入力として、「式」の評価結果が返る。**

「仮引数」と「式」の部分は、後で説明する。

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

## 「仮引数」の部分

正式には、関数を定義するときのように、型も付いている。先ほどの例も、ちゃんと書くと、

`(int operand1, int operand2)`

となる。
しかし、ラムダ式を使うほとんどの場面で、型は推論できるので、省略されることが多い。
前述の例では、`Func<int, int, int>`や`IntBinaryOperator`型の変数に割り当てようとしており、「intとintの2引数を持つ」ということが推論できるので、「int」は省略できる。

仮引数の書き方のバリエーションを挙げる。

* `(operand1, operand2)`
* `name`
* `(string name)`
* `()`

一引数の場合で、型名を書かない場合は、`name` のようにカッコを省略できる。
カッコは、「**どこからどこまでのまとまりが仮引数か**」を表すものであり、「`name`」 のように仮引数名だけの場合は、まとまりが明らかだからだ。
複数の引数があったり、型名を書いたりした場合は、どこからどこまでが仮引数かを、コンパイラが判断できなくなるので、カッコが必要となる。
また、引数が無い場合も、何も書かないとコンパイラは仮引数の部分が分からなくなるので、カッコを書く必要がある。

## 「式」の部分

ここには**一つの式**を書くことができる。
この式の中では、仮引数で受け取った値を使うことができる。

* `operand1 + operand2`
* `operand1 % 2 == 0`
* `new User("Geroshabu")`

しかし、やりたい処理が、一つの式で表すことができず、複数のステートメントで構成したい場合がある。
その場合はそれらのステートメントを `{ }` で囲むと、これが一つの式のように扱われる。
この場合は、`{ }` の中のステートメントを実行した結果が、`{ }` の評価結果となる。

* `{ int remain = operand1 % 2; return remain == 0; }`
* `{ User user = new User(); user.Name = "Geroshabu"; return user; }`

(便宜上、各ステートメントを一行で書いたが、改行してもよい。)

## まとめ

ラムダ式で、関数を簡単に表すことができる。

ちょっとした処理を、ラムダ式で表すと、コードがすっきりする。
ちなみに、何ステートメントもあるような複雑な処理をラムダ式で表すと、かえって分かりにくくなるかもしれないので注意が必要。
