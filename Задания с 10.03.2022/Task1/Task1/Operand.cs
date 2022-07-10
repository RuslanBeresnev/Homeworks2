namespace ParseTree;

/// <summary>
/// Class for operand
/// </summary>
public class Operand : INode
{
    /// <summary>
    /// Interacrion with number
    /// </summary>
    public int Number { get; set; }

    public void Print()
        => Console.Write($"{Number} ");

    public int Calculate()
        => Number;
}