namespace ParseTree;

/// <summary>
/// Division oparetor
/// </summary>
public class Division : Operator
{
    protected override char Sign => '/';

    public override int Calculate()
    {
        if (LeftChild == null || RightChild == null)
        {
            throw new ArgumentException();
        }

        if (RightChild.Calculate() == 0)
        {
            throw new ArgumentException("Деление на ноль");
        }
        return LeftChild.Calculate() / RightChild.Calculate();
    }
}