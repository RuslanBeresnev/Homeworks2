namespace UniqueList;

/// <summary>
/// List realization class
/// </summary>
public class List<T>
{
    /// <summary>
    /// List element class
    /// </summary>
    private class Node<T>
    {
        internal Node(T value, int id)
        {
            Id = id;
            Value = value;
            Next = null;
        }

        /// <summary>
        /// Element's number
        /// </summary>
        internal int Id { get; set; }

        /// <summary>
        /// Interaction with Node's value
        /// </summary>
        internal T? Value { get; set; }

        /// <summary>
        /// Interaction with next element
        /// </summary>
        internal Node<T>? Next { get; set; }
    }

    private Node<T>? head = null;
    private int length = 0;

    /// <summary>
    /// Get List Length
    /// </summary>
    public int Length => length;

    /// <summary>
    /// Add new value to List by index
    /// </summary>
    public virtual void Add(T value, int index)
    {
        var newElement = new Node<T>(value, index);
        length++;

        if (head == null)
        {
            head = newElement;
            return;
        }

        var currentElement = head;
        if (index == 0)
        {
            newElement.Next = head;
            head = newElement;
            currentElement = head;
        }
        else
        {
            for (int i = 1; i < index; i++)
            {
                currentElement = currentElement!.Next;
            }
            currentElement!.Next = newElement;
            if (index != length)
            {
                newElement.Next = currentElement!.Next;
            }
        }

        while (currentElement.Next != null)
        {
            currentElement.Next.Id = currentElement.Id + 1;
            currentElement = currentElement.Next;
        }
    }

    /// <summary>
    /// Remove value from List by index
    /// </summary>
    public void Remove(int index)
    {
        if (index < 0 || index >= length)
        {
            throw new IndexOutOfRangeException();
        }

        length--;
        var currentNode = head;
        var previousNode = head;

        if (index == 0)
        {
            head = head!.Next;
            currentNode = head!.Next;
        }
        else
        {
            while (currentNode != null)
            {
                if (currentNode!.Id == index)
                {
                    previousNode!.Next = currentNode.Next;
                    currentNode = currentNode.Next;
                    break;
                }
                previousNode = currentNode;
                currentNode = currentNode!.Next;
            }
        }

        while (currentNode != null)
        {
            currentNode!.Id--;
            currentNode = currentNode.Next;
        }
    }

    /// <summary>
    /// Set new List value by index
    /// </summary>
    public virtual void SetElement(int index, T value)
    {
        if (index < 0 || index >= length)
        {
            throw new IndexOutOfRangeException();
        }

        var currentNode = head;
        while (true)
        {
            if (currentNode!.Id == index)
            {
                currentNode.Value = value;
                return;
            }
            currentNode = currentNode!.Next;
        }
    }

    /// <summary>
    /// Get List value by index
    /// </summary>
    public T? GetElement(int index)
    {
        if (index < 0 || index >= length)
        {
            throw new IndexOutOfRangeException();
        }

        var currentNode = head;
        while (true)
        {
            if (currentNode!.Id == index)
            {
                return currentNode.Value;
            }
            currentNode = currentNode!.Next;
        }
    }

    /// <summary>
    /// Проверка на содержание элемента в списке
    /// </summary>
    public (bool contains, int position) Contains(T value)
    {
        var currentNode = head;
        while (currentNode != null)
        {
            if (Equals(currentNode.Value, value))
            {
                return (true, currentNode.Id);
            }
            currentNode = currentNode.Next;
        }
        return (false, -1);
    }
}