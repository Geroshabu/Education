import java.util.function.*;
import java.util.HashMap;

class Calculator {
    private HashMap<Operator, IntBinaryOperator> operators
	= new HashMap<Operator, IntBinaryOperator>();
    
    public void addOperator(Operator operatorType, IntBinaryOperator operator) {
	operators.put(operatorType, operator);
    }

    public int calculate(Operator operatorType, int operand1, int operand2) {
	if (operators.containsKey(operatorType)) {
	    return operators
		.get(operatorType)
		.applyAsInt(operand1, operand2);
	}
	else {
	    throw new IllegalStateException();
	}
    }
}
