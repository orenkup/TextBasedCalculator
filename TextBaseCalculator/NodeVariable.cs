using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBaseCalculator
{
    /// <summary>
    /// Represents a variable that was defined before
    /// </summary>
    public class NodeVariable : Node
    {
        private string _variableName;

        public NodeVariable(string variableName)
        {
            _variableName = variableName;
        }

        public override double Eval(IContext ctx)
        {
            return ctx.ResolveVariable(_variableName);
        }
    }
}
