namespace TextBaseCalculator
{
    /// <summary>
    /// NodeNumber represents a literal number in the expression
    /// </summary>
    public class NodeNumber : Node
    {
        private double _number; 

        public NodeNumber(double number)
        {
            _number = number;
        }

        public override double Eval(IContext ctx) => _number;
    }
}
