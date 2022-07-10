namespace ParseTree;

/// <summary>
/// Subtraction oparetor
/// </summary>
public class Subtraction : Operator
{
    protected override char Sign => '-';

    public override int Calculate()
    {
        if (LeftChild == null || RightChild == null)
        {
            throw new ArgumentException();
        }

        return LeftChild.Calculate() - RightChild.Calculate();
    }
}