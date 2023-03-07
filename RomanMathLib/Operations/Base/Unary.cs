using RomanMathLib.Model;
using RomanMathLib.Operations.Abstractions;

namespace RomanMathLib.Operations.Base;

internal abstract class Unary : IOperation
{
    public Unary(IOperation op)
    {
        one = op;
    }

    protected IOperation one;
    public virtual Number Execute()
    {
        throw new NotImplementedException();
    }
}