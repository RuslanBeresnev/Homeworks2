namespace Offset;

/// <summary>
/// Класс, реализующий сортировку пузырьком
/// </summary>
public static class BubbleSort<T>
{
    /// <summary>
    /// Сортировка пузырьком списка объектов
    /// </summary>
    public static List<T> Sort(List<T> objectList, IComparer<T> comparer)
    {
        for (var i = 0; i < objectList.Count; i++)
        {
            for (var j = 0; j < objectList.Count - 1; j++)
            {
                if (comparer.Compare(objectList[j], objectList[j + 1]) > 0)
                {
                    (objectList[j + 1], objectList[j]) = (objectList[j], objectList[j + 1]);
                }
            }
        }

        return objectList;
    }
}