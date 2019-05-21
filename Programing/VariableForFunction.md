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

ここでのポイントは、**変数に入っている関数は入れ替えることもでき、そのとき変数に入っている関数が実行される**ということだ。
