namespace TextBaseCalculator
{
    public class VariableContext : IContext
    {
        IEnumerable<Expression> _expressions;
        public VariableContext(IEnumerable<Expression> expressions)
        {
            _expressions = expressions;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public double ResolveVariable(string name)
        {
            var v = _expressions.Where(e => e.VariableName == name && e.VariableValue.HasValue).Select(er => er.VariableValue.Value).LastOrDefault();
            return v;
        }
    }
}
