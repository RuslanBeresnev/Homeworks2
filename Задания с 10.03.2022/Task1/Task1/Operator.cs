namespace ParseTree;

/// <summary>
/// Class for operators
/// </summary>
 public abstract class Operator : INode
{
    /// <summary>
    /// Interaction with rightChild
    /// </summary>
    public INode? RightChild { get; set; }

    /// <summary>
    /// Interaction with leftChild
    /// </summary>
    public INode? LeftChild { get; set; }

    protected abstract char Sign { get; }

    public void Print()
    {
        if (LeftChild == null || RightChild == null)
        {
            throw new InvalidOperationException();
        }

        Console.Write("( ");
        LeftChild.Print();
        Console.Write($"{Sign} ");
        RightChild.Print();
        Console.Write(") ");
    }

    public abstract int Calculate();
}