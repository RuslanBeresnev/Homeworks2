namespace ParseTree;

/// <summary>
/// Division oparetor
/// </summary>
public class Division : Operator
{
    public Division()
    {
        NodeOperator = '/';
    }

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

    public override void Print()
    {
        if (LeftChild == null || RightChild == null)
        {
            throw new InvalidOperationException();
        }

        Console.Write("( ");
        LeftChild.Print();
        Console.Write("/ ");
        RightChild.Print();
        Console.Write(") ");
    }
}