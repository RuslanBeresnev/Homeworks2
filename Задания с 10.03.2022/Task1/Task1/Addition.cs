namespace ParseTree;

/// <summary>
/// Addition oparetor
/// </summary>
public class Addition : Operator
{
    protected override char Sign => '+';

    public override int Calculate()
    {
        if (LeftChild == null || RightChild == null)
        {
            throw new ArgumentException();
        }

        return LeftChild.Calculate() + RightChild.Calculate();
    }
}