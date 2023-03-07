using RomanMathLib.Parser;
using RomanMathLib.Parser.Abstractions;

namespace RomanMathLib
{
    public interface ICalculator
    {
        string Evaluate(string input);
    }

    public class RomanCalculator : ICalculator
    {
        private readonly IExpressionParser _expressionParser;

        public RomanCalculator()
        {
            _expressionParser = new ExpressionParser();
        }
        
        public string Evaluate(string input)
        {
            var numberResult = _expressionParser.Parse(input);
            var result =  numberResult.Execute();
            return $"{result}";
        }
    }
}

