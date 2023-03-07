using RomanMathLib.Model;
using RomanMathLib.Operations.Abstractions;
using RomanMathLib.Operations.Base;

namespace RomanMathLib.Operations;

internal class Negative : Unary
{
    public Negative(IOperation number) : base(number)
    {
    }

    public override Number Execute()
    {
        return -one.Execute();
    }
}