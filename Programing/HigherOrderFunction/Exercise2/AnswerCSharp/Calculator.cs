using System;
using System.Collections.Generic;

namespace Exercise2
{
    class Calculator
    {
        private readonly Dictionary<Operator, Func<int, int, int>> operators
	    = new Dictionary<Operator, Func<int, int, int>>();

        public void AddOperator(Operator operatorType, Func<int, int, int> function)
	{
	    operators[operatorType] = function;
	}

        public int Calculate(Operator operatorType, int operand1, int operand2)
	{
	    if (operators.ContainsKey(operatorType))
	    {
	        return operators[operatorType](operand1, operand2);
	    }
	    else
	    {
	        throw new InvalidOperationException();
	    }
	}
    }
}
