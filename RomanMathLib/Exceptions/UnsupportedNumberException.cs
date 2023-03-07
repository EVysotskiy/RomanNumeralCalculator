namespace RomanMathLib.Exceptions;

public sealed  class UnsupportedNumberException : Exception
{
    public UnsupportedNumberException(string exception)
    {
        Console.WriteLine(exception);
    }
}