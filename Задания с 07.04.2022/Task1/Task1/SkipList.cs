namespace SkipList;

using System.Collections;

/// <summary>
/// Реализация структуры данных "Список с пропусками"
/// </summary>
public class SkipList<T> : IList<T> where T : IComparable<T>
{
    /// <summary>
    /// Реализация элемента списка с пропусками
    /// </summary>
    private class ListElement
    {
        public ListElement(T? value)
        {
            Value = value;
        }

        /// <summary>
        /// Значение элемента списка
        /// </summary>
        public T? Value { get; private set; }

        /// <summary>
        /// Следующий элемент
        /// </summary>
        public ListElement? Next { get; set; }

        /// <summary>
        /// Предыдущий элемент
        /// </summary>
        public ListElement? Previous { get; set; }

        /// <summary>
        /// Тот же элемент более высокого уровня
        /// </summary>
        public ListElement? Top { get; set; }

        /// <summary>
        /// Тот же элемент более нижнего уровня
        /// </summary>
        public ListElement? Bottom { get; set; }
    }

    private ListElement[] headsOfLevels;
    private List<T> listForEnumerator;

    public SkipList(int levelsCount)
    {
        LevelsCount = levelsCount;

        listForEnumerator = new List<T>();
        headsOfLevels = new ListElement[LevelsCount];
        InitializeHeadsOfLevels();
    }

    /// <summary>
    /// Проинициализировать каждый уровень списка его начальным самым минимальным элементом
    /// </summary>
    private void InitializeHeadsOfLevels()
    {
        for (int i = 0; i < LevelsCount; i++)
        {
            var headOfLevel = new ListElement(default);
            if (i > 0)
            {
                headOfLevel.Bottom = headsOfLevels[i - 1];
                headsOfLevels[i - 1].Top = headOfLevel;
            }
            headsOfLevels[i] = headOfLevel;
        }
    }

    /// <summary>
    /// Получить количество уровней разреженности в списке
    /// </summary>
    public int LevelsCount { get; }

    /// <summary>
    /// Количество элементов в списке
    /// </summary>
    public int Count { get; private set; }

    /// <summary>
    /// Только для чтения или нет
    /// </summary>
    public bool IsReadOnly { get; }

    /// <summary>
    /// Проверить список на пустоту
    /// </summary>
    public bool IsEmpty()
    {
        return Count == 0;
    }

    /// <summary>
    /// Добавить элемент в список
    /// </summary>
    public void Add(T item)
    {
        if (IsReadOnly)
        {
            throw new NotSupportedException("Список только для чтения");
        }

        if (listForEnumerator.Count == 0 || item.CompareTo(listForEnumerator[listForEnumerator.Count - 1]) >= 0)
        {
            listForEnumerator.Add(item);
        }
        else
        {
            for (int i = 0; i < listForEnumerator.Count - 1; i++)
            {
                if (item.CompareTo(listForEnumerator[i]) >= 0 && item.CompareTo(listForEnumerator[i + 1]) <= 0)
                {
                    listForEnumerator.Insert(i + 1, item);
                    break;
                }
            }
        }

        var currentElement = headsOfLevels[LevelsCount - 1];
        var newElement = new ListElement(item);
        var descentPoints = new List<ListElement>();

        while (true)
        {
            while (currentElement.Next != null && item.CompareTo(currentElement.Next.Value) >= 0)
            {
                currentElement = currentElement.Next;
            }
            if (currentElement.Bottom != null)
            {
                descentPoints.Add(currentElement);
                currentElement = currentElement.Bottom;
                continue;
            }
            break;
        }

        newElement.Next = currentElement.Next;
        if (currentElement.Next != null)
        {
            currentElement.Next.Previous = newElement;
        }
        currentElement.Next = newElement;
        newElement.Previous = currentElement;

        Count++;

        currentElement = currentElement.Next;
        int addedTopElements = 0;
        var random = new Random();
        int verdict = random.Next(2);
        while (verdict == 1 && addedTopElements < LevelsCount - 1)
        {
            var newTopElement = new ListElement(item);
            addedTopElements++;

            currentElement.Top = newTopElement;
            newTopElement.Bottom = currentElement;
            newTopElement.Next = descentPoints[descentPoints.Count - addedTopElements].Next;
            if (descentPoints[descentPoints.Count - addedTopElements].Next != null)
            {
                descentPoints[descentPoints.Count - addedTopElements].Next!.Previous = newTopElement;
            }
            descentPoints[descentPoints.Count - addedTopElements].Next = newTopElement;
            newTopElement.Previous = descentPoints[descentPoints.Count - addedTopElements];

            currentElement = newTopElement;
            verdict = random.Next(2);
        }
    }

    /// <summary>
    /// Очистить список от всех значений
    /// </summary>
    public void Clear()
    {
        listForEnumerator.Clear();
        
        Count = 0;
        headsOfLevels = new ListElement[LevelsCount];
        InitializeHeadsOfLevels();
    }

    /// <summary>
    /// Найти первое вхождение элемента в список; если элемента нет в списке, возвращает null
    /// </summary>
    private ListElement? FindFirstOccurrenceOfElement(T item)
    {
        var currentElement = headsOfLevels[LevelsCount - 1];
        while (true)
        {
            while (currentElement.Next != null && item.CompareTo(currentElement.Next.Value) >= 0)
            {
                if (item.CompareTo(currentElement.Next.Value) == 0)
                {
                    return currentElement.Next;
                }
                currentElement = currentElement.Next;
            }
            if (currentElement.Bottom != null)
            {
                currentElement = currentElement.Bottom;
                continue;
            }
            return null;
        }
    }

    /// <summary>
    /// Проверить наличие элемента в списке
    /// </summary>
    public bool Contains(T item)
    {
        return FindFirstOccurrenceOfElement(item) != null;
    }

    /// <summary>
    /// Удалить элемент из списка
    /// </summary>
    public bool Remove(T item)
    {
        if (IsReadOnly)
        {
            throw new NotSupportedException("Список только для чтения");
        }

        for (int i = 0; i < listForEnumerator.Count; i++)
        {
            if (listForEnumerator[i].CompareTo(item) == 0)
            {
                listForEnumerator.RemoveAt(i);
            }
        }

        var elementToRemove = FindFirstOccurrenceOfElement(item);
        if (elementToRemove == null)
        {
            return false;
        }
        while (true)
        {
            elementToRemove.Previous!.Next = elementToRemove.Next;
            if (elementToRemove.Next != null)
            {
                elementToRemove.Next.Previous = elementToRemove.Previous;
            }

            if (elementToRemove.Bottom == null)
            {
                break;
            }
            elementToRemove = elementToRemove.Bottom;
        }

        Count--;
        return true;
    }

    /// <summary>
    /// Получить индекс элемента в списке
    /// </summary>
    public int IndexOf(T item)
    {
        var currentElement = headsOfLevels[0];
        int index = 0;

        while (currentElement.Next != null)
        {
            if (item.CompareTo(currentElement.Next.Value) == 0)
            {
                return index;
            }

            currentElement = currentElement.Next;
            index++;
        }

        return -1;
    }

    /// <summary>
    /// Вставить элемент по индексу в список
    /// </summary>
    public void Insert(int index, T item)
    {
        throw new NotSupportedException("Вставка по индексу не поддерживается в списке с пропусками, так как он отсортирован");
    }

    /// <summary>
    /// Удалить элемент из списка по индексу
    /// </summary>
    public void RemoveAt(int index)
    {
        if (IsReadOnly)
        {
            throw new NotSupportedException("Список только для чтения");
        }
        if (index < 0 || index >= Count)
        {
            throw new ArgumentOutOfRangeException("Индекс находится за пределами элементов списка");
        }

        listForEnumerator.RemoveAt(index);

        var elementToDelete = headsOfLevels[0];
        for (int i = 0; i <= index; i++)
        {
            elementToDelete = elementToDelete!.Next;
        }

        Count--;

        while (true)
        {
            elementToDelete!.Previous!.Next = elementToDelete.Next;
            if (elementToDelete.Next != null)
            {
                elementToDelete.Next.Previous = elementToDelete.Previous;
            }

            if (elementToDelete.Top != null)
            {
                elementToDelete = elementToDelete.Top;
                continue;
            }
            return;
        }
    }

    /// <summary>
    /// Скопировать элементы списка в массив, начиная с указанной позиции в массиве
    /// </summary>
    public void CopyTo(T[] array, int arrayIndex)
    {
        if (IsEmpty())
        {
            throw new ArgumentNullException("Список пуст");
        }
        if (arrayIndex < 0 || arrayIndex >= array.Length)
        {
            throw new ArgumentOutOfRangeException("Индекс находится за пределами элементов массива");
        }
        if (arrayIndex + Count > array.Length)
        {
            throw new InvalidOperationException("В массив не поместятся все элементы списка");
        }

        var currentElement = headsOfLevels[0].Next;
        int elementsCopiedCount = 0;
        while (currentElement != null)
        {
            array[arrayIndex + elementsCopiedCount] = currentElement!.Value!;
            elementsCopiedCount++;
            currentElement = currentElement.Next;
        }
    }

    /// <summary>
    /// Получить или задать значение элементу списка по индексу
    /// </summary>
    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException("Индекс находится за пределами элементов списка");
            }

            var currentElement = headsOfLevels[0];
            for (int i = 0; i <= index; i++)
            {
                currentElement = currentElement!.Next;
            }
            return currentElement!.Value!;
        }
        set => throw new NotSupportedException("Изменение элемента по индексу не поддерживается в списке с пропусками, так как он отсортирован");
    }

    /// <summary>
    /// Получить список в виде обычного отсортированного списка
    /// </summary>
    private List<T> GetList()
    {
        return listForEnumerator;
    }

    /// <summary>
    /// Получить нумератор универсального списка
    /// </summary>
    public IEnumerator<T> GetEnumerator()
    {
        return GetList().GetEnumerator();
    }

    /// <summary>
    /// Получить нумератор списка
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}