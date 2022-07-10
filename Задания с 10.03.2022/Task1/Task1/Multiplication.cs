namespace ParseTree;

/// <summary>
/// Multiplication operator
/// </summary>
public class Multiplication : Operator
{
    protected override char Sign => '*';

    public override int Calculate()
    {
        if (LeftChild == null || RightChild == null)
        {
            throw new ArgumentException();
        }

        return LeftChild.Calculate() * RightChild.Calculate();
    }
}