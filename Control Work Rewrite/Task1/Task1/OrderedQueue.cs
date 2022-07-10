namespace ControlWorkRewrite;

/// <summary>
/// Класс, реализующий очередь с приоритетом
/// </summary>
/// <typeparam name="T">Тип значений, хранящихся в очереди</typeparam>
public class OrderedQueue<T>
{
    private QueueElement<T>? head = null;
    private int count = 0;

    /// <summary>
    /// Добавить элемент в очередь
    /// </summary>
    public void Enqueue(T value, int priority)
    {
        var newElement = new QueueElement<T>(value, priority);
        newElement.Next = head;
        head = newElement;
        count++;
    }

    /// <summary>
    /// Получить самый приоритетный элемент в очереди и удалить его
    /// </summary>
    public T Dequeue()
    {
        if (Empty)
        {
            throw new InvalidOperationException("Очередь пуста");
        }

        var currentElement = head;
        var previousElement = head;

        int maxPriority = 0;
        var elementWithMaxPriority = head;
        var ancestorOfElementWithMaxPriority = head;

        while (currentElement != null)
        {
            if (currentElement.Priority >= maxPriority)
            {
                maxPriority = currentElement.Priority;
                elementWithMaxPriority = currentElement;
                ancestorOfElementWithMaxPriority = previousElement;
            }

            previousElement = currentElement;
            currentElement = currentElement.Next;
        }

        T? resultValue = elementWithMaxPriority!.Value;
        if (elementWithMaxPriority == head)
        {
            head = head!.Next;
        }
        else
        {
            ancestorOfElementWithMaxPriority!.Next = elementWithMaxPriority.Next;
        }

        count--;
        return resultValue;
    }

    /// <summary>
    /// Проверить очередь на пустоту
    /// </summary>
    public bool Empty => count == 0;
}