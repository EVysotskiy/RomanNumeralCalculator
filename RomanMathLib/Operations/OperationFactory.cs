using RomanMathLib.Exceptions;
using RomanMathLib.Operations.Abstractions;

namespace RomanMathLib.Operations;

internal interface IOperationFactory
{
    IOperation Create(OperationType operationType, IOperation left, IOperation right);
    IOperation Create(OperationType operationType, IOperation operation);
}

internal class OperationFactory : IOperationFactory
{
    public IOperation Create(OperationType operationType, IOperation left, IOperation right)
    {
        return operationType switch
        {
            OperationType.Addition => new Addition(left, right),
            OperationType.Multiplication => new Multiplication(left, right),
            OperationType.Subtraction => new Subtraction(left, right),
            _ => throw new UnsupportedOperationException(nameof(operationType))
        };
    }

    public IOperation Create(OperationType operationType, IOperation operation)
    {
        return operationType switch
        {
            OperationType.Negative => new Negative(operation),
            _ => throw new UnsupportedOperationException(nameof(operationType))
        };
    }
}