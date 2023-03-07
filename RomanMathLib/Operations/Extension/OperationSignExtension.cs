namespace RomanMathLib.Operations.Extension;

internal static class OperationSignExtension
{
    private static IOperationSignMap OperationSignMap => new OperationSignMap()
    {
        {OperationType.Multiplication,'*'},
        {OperationType.Addition,'+'},
        {OperationType.Subtraction,'-'},
        {OperationType.Negative,'-'},
        {OperationType.Divide,'/'},
        {OperationType.BracketLeft,'('},
        {OperationType.BracketRight,')'},
    };

    internal static char GetSignByType(this OperationType operationType)
    {
        if (OperationSignMap.TryGetValue(operationType, out var sign))
        {
            return sign;
        }

        throw new ArgumentException($"Sign not found by {operationType.ToString()}");
    }
}