using RomanMathLib.Model;
using RomanMathLib.Operations.Abstractions;
using RomanMathLib.Operations.Base;

namespace RomanMathLib.Operations;

internal class Subtraction : Binary
{
    public Subtraction(IOperation left, IOperation right) : base(left, right)
    {
    }

    public override Number Execute()
    {
        return left.Execute() - right.Execute();
    }
}