namespace ParseTree;

/// <summary>
/// Node of the Parse Tree
/// </summary>
public interface INode
{
    /// <summary>
    /// Calculate node's value
    /// </summary>
    public int Calculate();

    /// <summary>
    /// Print node
    /// </summary>
    public void Print();
}