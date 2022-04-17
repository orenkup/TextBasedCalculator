using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBaseCalculator
{
    /// <summary>
    /// A model for the the parse user input
    /// </summary>
    public class Expression
    {
        public string OriginalExpression { get; set; }
        public string VariableName { get; set; }
        public string VariableExpression { get; set; }
        public double? VariableValue { get; set; }

        public override string ToString() => $"VariableName: {VariableName} , VariableValue: {VariableValue} , VariableExpression: {VariableExpression} , OriginalExpression: {OriginalExpression}";

    }
}
