using System;

namespace Exercise2
{
    class Exercise2
    {
        public void Execute()
	{
	    var calculator = new Calculator();
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
    }
}
