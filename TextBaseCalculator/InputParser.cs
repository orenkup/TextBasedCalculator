using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBaseCalculator
{
    /// <summary>
    /// A class that is responsible to parse the user input and store it in an expression collection.
    /// in case for post/pre increments and addition assignements it will "fix" the user input so that the parser will know how to handle it.
    /// </summary>
    public class InputParser
    {
        public IEnumerable<Expression> Parse(IEnumerable<string> inputs)
        {
            var exprs = new List<Expression>();
            foreach (var input in inputs)
            {
                // only a valid assignement exprewssion is parsed
                if (input.IndexOf("=") > 0) 
                {
                    var inputExpression = input.Split("=");
                    var variableName = inputExpression[0].Trim();
                    var variableExpression = inputExpression[1];

                    //in case of an addition assignement i += y
                    if (variableName.Contains("+"))
                    {
                        var varName = variableName.Split("+");
                        variableName = varName[0].Trim();
                        variableExpression = $"{variableName} +{variableExpression}";
                    }

                    //in case of pre increment j = ++i
                    if (variableExpression.Contains(" ++"))
                    {
                        var prevVariable = variableExpression.Split(" ++")[1].Trim();
                        exprs.Add(new Expression { OriginalExpression = input, VariableName = prevVariable, VariableExpression = $"{prevVariable} + 1" });
                        variableExpression = variableExpression.Replace(" ++", $" 1 + ");
                    }

                    exprs.Add(new Expression { OriginalExpression = input, VariableName = variableName, VariableExpression = variableExpression });

                    //in case of post increment x = i++ + 5
                    if (variableExpression.Contains("++ "))
                    {
                        var prevVariable = variableExpression.Split("++ ")[0].Trim();
                        exprs.Last().VariableExpression = variableExpression.Replace("++ ", " + 1 ");
                        exprs.Add(new Expression { OriginalExpression = input, VariableName = prevVariable, VariableExpression = $"{prevVariable} + 1" });
                    }
                }
            }

            return exprs;
        }

    }
}
