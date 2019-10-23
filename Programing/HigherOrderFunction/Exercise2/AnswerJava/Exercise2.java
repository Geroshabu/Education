import java.util.*;
import java.util.stream.*;

class Exercise2 {
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
}
