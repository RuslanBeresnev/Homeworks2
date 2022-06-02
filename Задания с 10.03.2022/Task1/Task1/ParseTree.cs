namespace ParseTree;

/// <summary>
/// Parse Tree building and calculating class
/// </summary>
public class ParseTree
{
    private int index = -1;
    private string[] sequence;

    public ParseTree(string sequence)
    {
        this.sequence = sequence.Split(" ");
    }

    private static bool IsInteger(string probablyNumber)
        => Int32.TryParse(probablyNumber, out int _);

    private bool BracketsConditionIsMet()
    {
        int counter = 0;
        bool verdict = true;
        foreach (var element in sequence[index].Split(")"))
        {
            if ((counter == 0 && !IsInteger(element)) || (counter > 0 && element != ""))
            {
                verdict = false;
            }
            counter++;
        }
        return verdict;
    }

    /// <summary>
    /// Build Parse Tree from splitted sequence
    /// </summary>
    /// <returns>Root of Parse Tree</returns>
    private INode? Parse()
    {
        index++;
        if (index < sequence.Length && sequence.Length != 1)
        {
            if (sequence[index][0] == '(' && "+-*/".Contains(sequence[index][1]))
            {
                char nodeOperator = sequence[index][1];
                Operator newNode = nodeOperator switch
                {
                    '+' => new Addition(),
                    '-' => new Subtraction(),
                    '*' => new Multiplication(),
                    '/' => new Division(),
                    _ => throw new InvalidOperationException()
                };
                newNode.LeftChild = Parse();
                newNode.RightChild = Parse();
                return newNode;
            }
            else if (IsInteger(sequence[index]))
            {
                return new Operand() { Number = int.Parse(sequence[index]) };
            }
            else if (BracketsConditionIsMet())
            {
                return new Operand() { Number = int.Parse(sequence[index].Split(")")[0]) };
            }
            return null;
        }
        return null;
    }

    /// <summary>
    /// Calculate Parse Tree value
    /// </summary>
    public int Calculate()
    {
        var root = Parse();
        if (root == null)
        {
            throw new InvalidOperationException();
        }
        return root.Calculate();
    }

    /// <summary>
    /// Print Parse Tree
    /// </summary>
    public void Print()
    {
        var root = Parse();
        if (root == null)
        {
            throw new InvalidOperationException();
        }
        root.Print();
    }
}