namespace ParseTree;

/// <summary>
/// Multiplication operator
/// </summary>
public class Multiplication : Operator
{
    public Multiplication()
    {
        NodeOperator = '*';
    }

    public override int Calculate()
    {
        if (LeftChild == null || RightChild == null)
        {
            throw new ArgumentException();
        }

        return LeftChild.Calculate() * RightChild.Calculate();
    }

    public override void Print()
    {
        if (LeftChild == null || RightChild == null)
        {
            throw new InvalidOperationException();
        }

        Console.Write("( ");
        LeftChild.Print();
        Console.Write("* ");
        RightChild.Print();
        Console.Write(") ");
    }
}