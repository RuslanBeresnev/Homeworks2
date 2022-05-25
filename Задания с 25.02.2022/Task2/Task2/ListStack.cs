namespace PostfixCalculator;

/// <summary>
/// Реализация стека на списке
/// </summary>
public class ListStack : IStack
{
    /// <summary>
    /// Элемент списка
    /// </summary>
    private class Node
    {
        public Node(double value)
        {
            Value = value;
        }

        /// <summary>
        /// Следующй элемент
        /// </summary>
        public Node? Next { get; set; }

        /// <summary>
        /// Значение элемента списка
        /// </summary>
        public double Value { get; set; }
    }
    /// <summary>
    /// Самый первый элемент списка
    /// </summary>
    private Node? Head { get; set; }

    private int count;

    public bool IsEmpty() => count == 0;

    public void Push(double value)
    {
        var newNode = new Node(value);
        newNode.Next = Head;
        Head = newNode;
        count++;
    }

    public double? Pop()
    {
        if (IsEmpty())
        {
            return null;
        }

        count--;
        double value = Head!.Value;
        Head = Head.Next;
        return value;
    }
}