using System;

namespace TextBaseCalculator
{
    /// <summary>
    /// NodeUnary for unary operations such as Negate 
    /// </summary>
    public class NodeUnary : Node
    {
        private Node _rhs;                              // Right hand side of the operation
        private Func<double, double> _op;               // The callback operator

        /// <summary>
        /// Constructor accepts the two nodes to be operated on and function that performs the actual operation
        /// </summary>
        /// <param name="rhs"></param>
        /// <param name="op"></param>
        public NodeUnary(Node rhs, Func<double, double> op)
        {
            _rhs = rhs;
            _op = op;
        }

        public override double Eval(IContext ctx)
        {
            // Evaluate RHS
            var rhsVal = _rhs.Eval(ctx);

            // Evaluate and return
            var result = _op(rhsVal);
            return result;
        }
    }
}
