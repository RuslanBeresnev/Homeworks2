namespace UniqueList;

/// <summary>
/// List class realization without duplicate values
/// </summary>
public class UniqueList<T> : List<T>
{
    /// <summary>
    /// Add previously uncontained element
    /// </summary>
    public override void Add(T value, int index)
    {
        if (Contains(value).contains)
        {
            throw new ExistingElementAddingException("Добавление уже существующего элемента");
        }
        base.Add(value, index);
    }

    /// <summary>
    /// Set new List value by index
    /// </summary>
    public override void SetElement(int index, T value)
    {
        (bool contains, int position) = Contains(value);
        if (contains && position != index)
        {
            throw new ExistingElementAddingException("Изменение на уже существующий в списке элемент");
        }
        base.SetElement(index, value);
    }
}