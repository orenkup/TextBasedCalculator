using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBaseCalculator
{
    public class Calculator
    {
        public Dictionary<string, double> Calculate (IEnumerable<string> inputs)
        {
            var output = new Dictionary<string, double>();
            var expressions = new InputParser().Parse(inputs);
            var varibleContext = new VariableContext(expressions);


            foreach (var expr in expressions)
            {
                var result = Parser.Parse(expr.VariableExpression).Eval(varibleContext);
                expr.VariableValue = result;
                output[expr.VariableName] = expr.VariableValue.Value;
            }
            return output;

        }
        
    }
}
