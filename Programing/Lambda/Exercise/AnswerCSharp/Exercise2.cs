using System;

namespace Exercise2
{
    class Exercise2
    {
        public void Execute()
	{
	    var calculator = new Calculator();
	    // 演算方法を登録
	    calculator.AddOperator(Operator.Add, (a, b) => a + b);
	    calculator.AddOperator(Operator.Sub, (a, b) => a - b);
	    calculator.AddOperator(Operator.Mul, (a, b) => a * b);
	    calculator.AddOperator(Operator.Div, (a, b) => a / b);

            // 演算方法を指定して演算
	    Console.WriteLine(calculator.Calculate(Operator.Add, 12, 30)); // 出力 : 42
	    Console.WriteLine(calculator.Calculate(Operator.Div, 252, 6)); // 出力 : 42
	}
    }
}
