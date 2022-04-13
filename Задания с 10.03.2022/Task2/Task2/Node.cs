namespace UniqueList;

/// <summary>
/// List element class
/// </summary>
internal class Node<T>
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