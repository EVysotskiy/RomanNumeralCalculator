namespace RomanMathLib.Exceptions;

public sealed class UnsupportedOperationException: Exception
{
    public UnsupportedOperationException(string exception)
    {
        Console.WriteLine(exception);
    }
}