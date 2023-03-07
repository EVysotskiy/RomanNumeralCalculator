using RomanMathLib.Model;
using RomanMathLib.Operations.Abstractions;

namespace RomanMathLib.Operations.Base;

internal abstract class Binary : IOperation
{
    public Binary(IOperation left, IOperation right)
    {
        this.left = left;
        this.right = right;
    }

    protected IOperation left, right;
    public virtual Number Execute()
    {
        throw new NotImplementedException();
    }
}