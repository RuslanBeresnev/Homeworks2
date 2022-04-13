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
    {
        return Int32.TryParse(probablyNumber, out int result);
    }

    private bool ThirdParseConditionIsMet()
    {
        int counter = 0;
        bool verdict = true;
        foreach (var element in sequence[index].Split(")"))
        {
            if ((counter == 0 && !IsInteger(element)) || (counter > 0 && element != ""))
                verdict = false;
            counter++;
        }
        return verdict;
    }

    /// <summary>
    /// Build Parse Tree from splitted sequence
    /// </summary>
    /// <returns>Root of Parse Tree</returns>
    public INode? Parse()
    {
        index++;
        INode? newNode = null;
        if (index < sequence.Length && sequence.Length != 1)
        {
            if (sequence[index][0] == '(' && "+-*/".Contains(sequence[index][1]))
            {
                char nodeOperator = sequence[index][1];
                switch (nodeOperator)
                {
                    case '+':
                        newNode = new Addition();
                        break;
                    case '-':
                        newNode = new Subtraction();
                        break;
                    case '*':
                        newNode = new Multiplication();
                        break;
                    case '/':
                        newNode = new Division();
                        break;
                }
                (newNode as Operator)!.LeftChild = Parse();
                (newNode as Operator)!.RightChild = Parse();
            }
            else if (IsInteger(sequence[index]))
            {
                newNode = new Operand();
                (newNode as Operand)!.Number = int.Parse(sequence[index]);
            }
            else if (ThirdParseConditionIsMet())
            {
                newNode = new Operand();
                (newNode as Operand)!.Number = int.Parse(sequence[index].Split(")")[0]);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
        return newNode;
    }

    /// <summary>
    /// Calculate Parse Tree value
    /// </summary>
    public int Calculate(INode root)
    {
        if (root == null)
        {
            throw new ArgumentNullException();
        }

        return root.Calculate();
    }

    /// <summary>
    /// Print Parse Tree
    /// </summary>
    public void Print(INode root)
    {
        if (root == null)
        {
            throw new ArgumentNullException();
        }

        root.Print();
    }
}