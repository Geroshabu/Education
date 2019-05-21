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

ここでのポイントは、**変数に入っている関数は入れ替えることもでき、そのとき変数に入っている関数が実行される** ということだ。

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

java
```Java
public void execute() {
    BiFunction<String, Integer, User> method = this::searchUser;
    User result = method.apply("Geroshabu", 29);
}

private User searchUser(String name, Integer age) { /* 省略 */ }
```

この変数 `method` には、最初の例の `printFoo` や `printBar` は格納することができない。
なぜなら、引数も、戻り値も違うからである。
