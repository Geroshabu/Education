# 関数を格納できる変数

## 普通の変数

新人研修では、「変数」とはオブジェクトを格納したり取り出したり出来る、箱のようなものだと教わったかもしれない。

```csharp
int age = 42; // 格納する
if (age < 20) // 取り出して使う
{
    age = 20; // 入れ替える
}
```

この例はC#だが、「int」という型の変数の中身を入れ替えたり、使用したりできるということがわかるだろう。
ここまでは、イメージしやすいかもしれない。

## 関数を格納できる変数

変数には、関数を格納することができる。
格納した関数を取り出したり、使用したりもできる。普通の変数と同様である。

C#
```csharp
class Sample
{
    public void Execute()
    {
        Action printMethod = printFoo;
        printMethod(); // "Foo" が表示される

        printMethod = printBar;
        printMethod(); // "Bar" が表示される
    }

    private void printFoo() { Console.WriteLine("Foo"); }

    private void printBar() { Console.WriteLine("Bar"); }
}
```

Java
```java
class Sample {
    public void execute() {
        Runnable printMethod = this::printFoo;
        printMethod.run(); // "Foo" が表示される

        printMethod = this::printBar;
        printMethod.run(); // "Bar" が表示される
    }

    private void printFoo() { System.out.println("Foo"); }

    private void printBar() { System.out.println("Bar"); }
}
```

「Action」や「Runnable」は、型名である。
「int」などと同じだ。

ここでのポイントは、変数に入っている関数は入れ替えることもでき、そのとき変数に入っている関数が実行されるということだ。

## 関数の型

前述の通り、「Action」や「Runnable」といった型の変数には、関数を格納することができる。

ただし、どんな関数でも格納できるわけではない。
変数に関数を格納するためには、「引数」と「戻り値」の型が一致していなければならない。

C#(.Net)やJavaでは、関数を表す型がいくつか用意されている。
関数の引数と戻り値と、それに対応する型の例を次表に示す。この他にもたくさんある。

|引数|戻り値|この関数を表す型(C#)|この関数を表す型(Java)|
|---|---|---|---|
|なし|なし|`System.Action`|`java.lang.Runnable`|
|T|なし|`System.Action<T>`|`java.util.function.Consumer<T>`|
|なし|TRet|`System.Func<TRet>`|`java.util.function.Supplier<TRet>`|
|T1, T2|TRet|`System.Func<T1, T2, TRet>`|`java.util.function.BiFunction<T1, T2, TRet>`|

カッコ (`<`と`>`) が付いている型はジェネリック型である。実際に型を使用する際には、具体的な型名が T1 や T2 や TRet に当てはまる。

例として、2 つの引数を受け取り、戻り値がある関数を、変数に格納して使う例を示す。

C#
```csharp
public void Execute()
{
    Func<string, int, User> method = searchUser;
    User result = method("Geroshabu", 29);
}

private User searchUser(string name, int age) { /* 省略 */ }
```

Java
```Java
public void execute() {
    BiFunction<String, Integer, User> method = this::searchUser;
    User result = method.apply("Geroshabu", 29);
}

private User searchUser(String name, Integer age) { /* 省略 */ }
```

この変数 `method` には、最初の例の `printFoo` や `printBar` は格納することができない。
なぜなら、引数も、戻り値も違うからである。

## まとめ

関数は、値やオブジェクトとは異なるものという感覚があるかもしれない。
しかし、関数もオブジェクトの一つだと考えた方がよい。

すなわち、**関数も、変数に入れて持ち運んだり、引数として受け渡したり、戻り値として返すことができる。**
**配列やリストに、関数をたくさん保持させておくことだってできる。**

この考え方は重要だ。
引数に関数を渡すことは頻繁にある。
状況によって実行する関数を変更したりできる。
また、イベントやコールバックといった考え方にもつながっている。

ここでは、C#やJavaでの、細かい書き方の説明や、型の紹介は行わない。
ここで伝えたいのは、関数もオブジェクトと同じように扱えるという感覚である。
書き方や型の種類について知りたくなった場合は、「デリゲート」(C#)や「関数型インターフェイス」(Java)という語で調べてみるとよい。

## 練習問題

### 問題1

### 問題2

下記のように、2つの整数の演算を行う `Calculator` クラスを作成せよ。
`Calculator` インスタンスへは、次のことができる。

* 2つの整数の演算方法を登録できる。
* 登録した演算方法を指定して、演算を実行することができる。演算方法の指定は列挙型(Enum)で行う。

なお、このように演算方法を外部から登録するようにすることで、この `Calculator` での演算方法を自由にカスタマイズすることができるようになる。
将来、さらなる演算をする必要が出てきた場合は、`Calculator` 内部の修正をすることなく、演算方法を拡張することができるという利点がある。


`Calculator` クラスの使用例 (C#)

```csharp
public void Execute()
{
    Calculator calculator = new Calculator();
    // 演算方法を登録
    calculator.AddOperator(Operator.Add, add);
    calculator.AddOperator(Operator.Sub, subtract);
    calculator.AddOperator(Operator.Mul, multiply);
    calculator.AddOperator(Operator.Div, divide);

    // 演算方法を指定して演算
    Console.WriteLine(calculator.Calculate(Operator.Add, 12, 30)); // 出力 : 42
    Console.WriteLine(calculator.Calculate(Operator.Div, 252, 6)); // 出力 : 42
}

private int add(int a, int b) { return a + b; }
private int subtract(int a, int b) { return a - b; }
private int multiply(int a, int b) { return a * b; }
private int divide(int a, int b) { return a / b; }

```

`Calculator` クラスの使用例 (Java)

```java
public void execute() {
    Calculator calculator = new Calculator();
    // 演算方法を登録
    calculator.addOperator(Operator.Add, this::add);
    calculator.addOperator(Operator.Sub, this::subtract);
    calculator.addOperator(Operator.Mul, this::multiply);
    calculator.addOperator(Operator.Div, this::divide);

    // 演算方法を指定して演算
    System.out.println(calculator.calculate(Operator.Add, 12, 30)); // 出力 : 42
    System.out.println(calculator.calculate(Operator.Div, 252, 6)); // 出力 : 42
}

private Integer add(Integer a, Integer b) { return a + b; }
private Integer subtract(Integer a, Integer b) { return a - b; }
private Integer multiply(Integer a, Integer b) { return a * b; }
private Integer divide(Integer a, Integer b) { return a / b; }
```
