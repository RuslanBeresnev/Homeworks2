namespace ParseTree;

/// <summary>
/// Class for operators
/// </summary>
 public abstract class Operator : INode
{
    private INode? rightChild;
    private INode? leftChild;
    private char nodeOperator;

    /// <summary>
    /// Interaction with nodeOperator
    /// </summary>
    public char NodeOperator
    {
        get { return nodeOperator; }
        set { nodeOperator = value; }
    }

    /// <summary>
    /// Interaction with rightChild
    /// </summary>
    public INode? RightChild
    {
        get { return rightChild; }
        set { rightChild = value; }
    }

    /// <summary>
    /// Interaction with leftChild
    /// </summary>
    public INode? LeftChild
    {
        get { return leftChild; }
        set { leftChild = value; }
    }

    public abstract void Print();

    public abstract int Calculate();
}