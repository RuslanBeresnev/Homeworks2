namespace ControlWorkRewrite;

/// <summary>
/// Класс элемента очереди
/// </summary>
internal class QueueElement<T>
{
    private T value;
    private int priority;
    private QueueElement<T>? next;

    internal QueueElement(T value, int priority)
    {
        this.value = value;
        this.priority = priority;
    }

    /// <summary>
    /// Следующий по добавлению элемент очереди
    /// </summary>
    internal QueueElement<T>? Next { get; set; }

    /// <summary>
    /// Получить значение элемента очереди
    /// </summary>
    internal T Value => value;

    /// <summary>
    /// Получить приоритет элемента очереди
    /// </summary>
    internal int Priority => priority;
}