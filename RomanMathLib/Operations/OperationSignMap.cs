namespace RomanMathLib.Operations;

public interface IOperationSignMap : IReadOnlyDictionary<OperationType,char> { }

internal class OperationSignMap : Dictionary<OperationType,char>,IOperationSignMap
{
    
}