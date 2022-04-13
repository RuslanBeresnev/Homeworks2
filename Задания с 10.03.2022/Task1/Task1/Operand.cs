namespace ParseTree;

/// <summary>
/// Class for operand
/// </summary>
public class Operand : INode
{
    private int number;

    /// <summary>
    /// Interacrion with number
    /// </summary>
    public int Number
    {
        get { return number; }
        set { number = value; }
    }

    public void Print()
        => Console.Write($"{number} ");

    public int Calculate()
        => number;
}