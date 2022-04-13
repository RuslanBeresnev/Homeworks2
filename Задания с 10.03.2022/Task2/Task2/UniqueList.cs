namespace UniqueList;

/// <summary>
/// List class realization without duplicate values
/// </summary>
public class UniqueList<T> : List<T>
{
    /// <summary>
    /// Add previously uncontained element
    /// </summary>
    public override void Add(T value)
    {
        var currentNode = head;
        while (currentNode != null)
        {
            if (Equals(currentNode.Value, value))
            {
                throw new ExistingElementAddingException("Добавление уже существующего элемента");
            }
            currentNode = currentNode!.Next;
        }
        base.Add(value);
    }
}