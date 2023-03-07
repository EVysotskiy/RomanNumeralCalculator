namespace RomanMathLib.Exceptions;

public sealed class ExpressionException : Exception
{
    public ExpressionException(string exception)
    {
        Console.WriteLine(exception);
    }
}