namespace UniqueList;

/// <summary>
/// List realization class
/// </summary>
public class List<T>
{
    private protected Node<T>? head = null;
    private protected int length = 0;

    /// <summary>
    /// Get List Length
    /// </summary>
    public int Length
    {
        get { return length; }
    }

    /// <summary>
    /// Add new value to List
    /// </summary>
    public virtual void Add(T value)
    {
        var newElement = new Node<T>(value, length);
        length++;
        newElement.Next = head;
        head = newElement;
    }

    /// <summary>
    /// Remove value from List by index
    /// </summary>
    public void Remove(int index)
    {
        if (index < 0 || index >= length)
        {
            throw new NonExistentElementReferencingException("Обращение к несуществующему элементу");
        }

        var currentNode = head;
        while (true)
        {
            if (currentNode!.Id == index)
            {
                currentNode.Value = default(T);
                return;
            }
            currentNode = currentNode!.Next;
        }
    }

    /// <summary>
    /// Set new List value by index
    /// </summary>
    public void SetElement(int index, T value)
    {
        if (index < 0 || index >= length)
        {
            throw new NonExistentElementReferencingException("Обращение к несуществующему элементу");
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
            throw new NonExistentElementReferencingException("Обращение к несуществующему элементу");
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
}