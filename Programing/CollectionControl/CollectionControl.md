# コレクション操作 (Linq・Stream API)

## 前提知識

[ラムダ式](../Lambda/Lambda.md)の知識が必要。
先にそちらを理解しておくこと。

## 繰り返し文によるコレクション操作

プログラムでは、よく配列やリストなどのコレクションの、すべての要素に対する操作を行う必要がある。
もちろん、for文と添字を使って、順番に処理することはできる。
また、C#やJavaでは、foreach文や拡張for文というものを習っただろう。

例えば、`User`というインスタンスのリストから、ユーザの名前のリストを作成するには、次のようなコードになる。

C#

```csharp
var names = new List<string>();
foreach (User user in users)
{
    names.Add(user.Name);
}
```

Java

```java
var names = new LinkedList<String>();
for (User user : users) {
    names.add(user.getName());
}
```

しかし、今どきこんな書き方はしない。
これからは、コレクション操作用の関数を使おう！

## コレクション操作用の関数

C# や Java には、配列やリストなどのコレクションを操作する関数が標準ライブラリとして用意されている。
それらの機能は、C# では **Linq**、Java では **Stream API** と呼ばれている。

いくつか代表的な関数を紹介する。

| 機能 | Linq | Stream API |
|:--|:--|:--|
|射影|Select|map|
|抽出|Where|filter|
|結果をリストとして得る|ToList|collect(Collectors.toList())|
|条件を満たす要素があるか|Any|anyMatch|

これ以外は自分で調べよう。

### 射影

射影というと、難しそうに聞こえるかもしれないが、要は変換だ。
射影操作では、コレクションの各要素を何らかの変換方法で変換し、新しいコレクションを得る。

ユーザのリストから、それらのユーザの名前のリストを作る例を次に示す。
ここではユーザから名前への変換方法はラムダ式で与えている。
リストの各要素に、この変換関数を順に適用していく。

C#

```csharp
List<string> names = users
    .Select(user => user.Name) // このラムダ式に従って各要素を変換
    .ToList();
```

Java

```java
List<string> names = users.stream()
    .map(user -> user.getName()) // このラムダ式に従って各要素を変換
    .collect(Collectors.toList());
```

### 抽出

抽出では、コレクションの中から条件に合う要素を取り出して、新しいコレクションを得る。

ユーザのリストから、年齢が20歳未満のユーザだけのリストを作る例を示す。
リストの各要素を、条件となる関数で判定していき、trueとなる要素のみ取得する。

C#

```csharp
List<string> underageUsers = users
    .Where(user => user.Age < 20) // この条件に合う要素を抜き出す
    .ToList();
```

Java

```java
List<string> underageUsers = users.stream()
    .filter(user -> user.getAge() < 20) // この条件に合う要素を抜き出す
    .collect(Collectors.toList());
```

### 条件を満たす要素があるか

コレクションの要素のうち、条件に合った要素があるかを判定する。

次の例では、ユーザの中に20歳未満のユーザがいるかを判定する。
20歳未満のユーザが含まれていれば、結果は真になるだろう。

C#

```csharp
bool isIncludingUnderage = users
    .Any(user => user.Age < 20);
```

Java

```java
boolean isIncludingUnderage = users.stream()
    .anyMatch(user -> user.getAge() < 20)
```

## 操作できる型

先ほどまで、コレクションに対して操作できるかのように説明したが、実はそうではない。
これらの関数を呼べるのは、C#では `IEnumerable<T>` という型で、Javaだと `Stream<T>` という型だ。

C#では、配列やリストは `IEnumerable<T>` を実装していて、配列やリストに対してこれらのメソッドを呼び出す形で記述できる。
Javaでは、配列やリストに対して、まず `stream()` という関数を呼び出し、`Stream<T>` を得る必要がある。

射影や抽出の結果も、`IEnumerable<T>` や `Stream<T>` で返ってくる。
これらはリストや配列のようなコレクションではないので、処理結果は、そのままでは `List<T>` のような型に格納することはできない。

C#

```csharp
List<string> names = users.Select(user => user.Name); // できない
```

Java

```java
List<string> names = users.stream().map(user -> user.getName()); // できない
```

すでに気付いているとは思うが、これまでの例のうち、結果がコレクションとなるものは、`ToList()` や `.collect(Collectors.toList())` といった関数を呼び出している。
これにより、結果をリストとして得られるのだ。
