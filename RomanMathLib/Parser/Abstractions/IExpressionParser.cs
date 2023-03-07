using RomanMathLib.Model;

namespace RomanMathLib.Parser.Abstractions;

internal interface IExpressionParser
{
    Number Parse(string mathExpression);
}