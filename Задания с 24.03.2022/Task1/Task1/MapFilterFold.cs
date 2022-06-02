namespace MapFilterFold;

/// <summary>
/// Класс с функциями Map(), Filter(), Fold()
/// </summary>
public static class MapFilterFold
{
    /// <summary>
    /// Преобразование каждого элемента списка с помощью функции mapFunction
    /// </summary>
    public static List<int> Map(List<int> list, Func<int, int> mapFunction)
    {
        var resultList = new List<int>();
        foreach (var item in list)
        {
            resultList.Add(mapFunction(item));
        }
        return resultList;
    }

    /// <summary>
    /// Возвращает список только с теми элементами, для которых функция filterFunction вернула значение true
    /// </summary>
    public static List<int> Filter(List<int> list, Func<int, bool> filterFunction)
    {
        var resultList = new List<int>();
        foreach (var item in list)
        {
            if (filterFunction(item))
            {
                resultList.Add(item);
            }
        }
        return resultList;
    }

    /// <summary>
    /// Функция возвращает "накопленное" значение, используя начальное значение и элементы списка
    /// </summary>
    public static int Fold(List<int> list, int initialValue, Func<int, int, int> foldFunction)
    {
        int result = initialValue;
        foreach (var item in list)
        {
            result = foldFunction(result, item);
        }
        return result;
    }
}