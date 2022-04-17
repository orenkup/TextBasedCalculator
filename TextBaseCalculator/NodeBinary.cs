using System;

namespace TextBaseCalculator
{
    /// <summary>
    /// NodeBinary for binary operations such as Add, Subtract etc...
    /// </summary>
    public class NodeBinary : Node
    {
        private Node _lhs;                              // Left hand side of the operation
        private Node _rhs;                              // Right hand side of the operation
        private Func<double, double, double> _op;       // The callback operator

        /// <summary>
        /// Constructor accepts the two nodes to be operated on and function that performs the actual operation
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <param name="op"></param>
        public NodeBinary(Node lhs, Node rhs, Func<double, double, double> op)
        {
            _lhs = lhs;
            _rhs = rhs;
            _op = op;
        }

        public override double Eval(IContext ctx)
        {
            // Evaluate both sides
            var lhsVal = _lhs.Eval(ctx);
            var rhsVal = _rhs.Eval(ctx);

            // Evaluate and return
            var result = _op(lhsVal, rhsVal);
            return result;
        }
    }
}
