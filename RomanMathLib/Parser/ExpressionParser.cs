using RomanMathLib.Exceptions;
using RomanMathLib.Model;
using RomanMathLib.Operations;
using RomanMathLib.Operations.Abstractions;
using RomanMathLib.Operations.Extension;
using RomanMathLib.Parser.Abstractions;

namespace RomanMathLib.Parser;

internal class ExpressionParser : IExpressionParser
{
    private string _mathExpression;
    private int _currentPosition;
    private readonly IOperationFactory _operationFactory;

    public ExpressionParser()
    {
        _mathExpression = string.Empty;
        _operationFactory = new OperationFactory();
    }

    public Number Parse(string mathExpression)
    {
        _mathExpression = mathExpression;
        _currentPosition = 0;

        IOperation root = LowPriorityParse();
        return root?.Execute() ?? new Number();
    }

    private IOperation LowPriorityParse()
    {
        var result = MediumPriorityParse();

        for (;;)
        {
            var operationType = OperationType.None;

            if (IsMatch(OperationType.Addition))
            {
                operationType = OperationType.Addition;
            }
            else if (IsMatch(OperationType.Subtraction))
            {
                operationType = OperationType.Subtraction;
            }

            if (operationType == OperationType.None)
            {
                return result;
            }

            result = _operationFactory.Create(operationType, result, MediumPriorityParse());
        }
    }

    private IOperation MediumPriorityParse()
    {
        var result = HighPriorityParse();
        for (;;)
        {
            var operationType = OperationType.None;

            if (IsMatch(OperationType.Multiplication))
            {
                operationType = OperationType.Multiplication;
            }
            else if (IsMatch(OperationType.Divide))
            {
                operationType = OperationType.Divide;
            }

            if (operationType == OperationType.None)
            {
                return result;
            }

            result = _operationFactory.Create(operationType, result, HighPriorityParse());
        }
    }

    private IOperation HighPriorityParse()
    {
        if (IsMatch(OperationType.Negative))
        {
            var result = _operationFactory.Create(OperationType.Negative, MediumPriorityParse());
            return result;
        }

        if (IsMatch(OperationType.BracketLeft))
        {
            var result = LowPriorityParse();
            if (!IsMatch(OperationType.BracketRight))
            {
                throw new ExpressionException("Missing right bracket");
            }

            return result;
        }

        var start = _currentPosition;
        while (_currentPosition < _mathExpression.Length && Number.IsDigit(_mathExpression[_currentPosition]))
        {
            ++_currentPosition;
        }

        var substring = _mathExpression.Substring(start, _currentPosition - start);
        return Number.Parse(substring);
    }

    private bool IsMatch(OperationType operationType)
    {
        var findSign = operationType.GetSignByType();

        if (IsEndParsing())
        {
            return false;
        }

        SkipSpace();

        if (_mathExpression[_currentPosition] != findSign)
        {
            return false;
        }

        ++_currentPosition;
        return true;
    }

    private void SkipSpace()
    {
        while (char.IsWhiteSpace(_mathExpression[_currentPosition]))
        {
            ++_currentPosition;
        }
    }

    private bool IsEndParsing()
    {
        return _currentPosition >= _mathExpression.Length;
    }
}