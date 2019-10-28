import java.util.stream.*;

class Exercise2 {
    public void execute() {
	Calculator calculator = new Calculator();
	// 演算方法を登録
	calculator.addOperator(Operator.Add, (a, b) -> a + b);
	calculator.addOperator(Operator.Sub, (a, b) -> a - b);
	calculator.addOperator(Operator.Mul, (a, b) -> a * b);
	calculator.addOperator(Operator.Div, (a, b) -> a / b);

	// 演算方法を指定して演算
	System.out.println(calculator.calculate(Operator.Add, 12, 30)); // 出力 : 42
	System.out.println(calculator.calculate(Operator.Div, 252, 6)); // 出力 : 42
    }
}
