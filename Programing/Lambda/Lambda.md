# ラムダ式

## 前提知識

[メソッドを表す型](../HigherOrderFunction/HigherOrderFunction.md)の知識が必要。
先にそちらの内容を理解しておくこと。

## ラムダ式を使わない例

これは、[以前](../HigherOrderFunction/HigherOrderFunction.md)練習問題として考えた、計算器クラスの例である。
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

```csharp
Func<int, int, int> method = /* ラムダ式 */;
```

ちなみに末尾の「;」は、このステートメント末尾の「;」であって、ラムダ式の一部ではない。
ごちゃまぜにすると、理解が遠のくかもしれないので、念のため。

このラムダ式の部分が、関数を表している。
ラムダ式は、次のような形式となっている。

C#

```csharp
仮引数 => 式
```

Java

```java
仮引数 -> 式
```

ラムダ式が表す関数は、
**「仮引数」を入力として、「式」の評価結果を返す**
関数である。

## 「仮引数」の部分

### 基本

ラムダ式の「仮引数」は、関数定義の仮引数の部分に当たる。
関数定義では、仮引数を表すには、括弧の中に型名と引数名を書く。

`(int operand1, int operand2)`

ラムダ式の仮引数も、これと同じように書くことができる。

### 型の省略

しかし、ラムダ式を使うほとんどの場面で、型は推論できるので、省略されることが多い。
前述の例では、`Func<int, int, int>`や`IntBinaryOperator`型の変数に割り当てようとしており、「intとintの2引数を持つ」ということが推論できるので、「int」は省略できる。

```csharp
// operand1 と operand2 の型が書いてないけど、
// Func<int, int, int>型で受けているので、
// おそらく int 型だろう
Func<int, int, int> method = (operand1, operand2) => operand1 + operand2;
```

### 括弧の省略

仮引数が一つの場合に型名を省略した場合は、括弧も省略できる。

```csharp
Func<int, bool> isAdult = age => age >= 20;
```

仮引数が2語以上の場合は括弧を付けてまとまりを表さなくてはならないが、
1語の場合はわざわざまとめなくてよいからだ。

## 「式」の部分

### 基本

ここには、**一つの式** を書くことができる。
この式の中では、仮引数で受け取った値を使うことができる。

* `operand1 + operand2`
* `operand1 % 2 == 0`
* `new User("Geroshabu")`

### 複数の式になる場合

しかし、やりたい処理が、一つの式で表すことができず、複数のステートメントで構成したい場合がある。
その場合はそれらのステートメントを `{ }` で囲むと、これが一つの式のように扱われる。
この場合は、`{ }` の中のステートメントを実行した結果が、`{ }` の評価結果となる。

```csharp
operand1 =>
{
    int remain = operand1 % 2;
    return remain == 0;
}
```

```csharp
() =>
{
    User user = new User();
    user.Name = "Geroshabu";
    return user;
}
```

この `{ }` の中は、通常の関数定義の本体と同じなので、評価結果は `return` で返す必要がある。

## まとめ

ラムダ式で、関数を簡単に表すことができる。

ちょっとした処理を、ラムダ式で表すと、コードがすっきりする。
ちなみに、何ステートメントもあるような複雑な処理をラムダ式で表すと、かえって分かりにくくなるかもしれないので注意が必要。

## 練習問題

[高階関数](../HigherOrderFunction/HigherOrderFunction.md)の練習問題2で作成した計算器で、`AddOperator`を呼ぶところを、ラムダ式を使用して記述せよ。
