namespace MapFilterFold;

using System.Collections.Generic;

/// <summary>
/// Класс с функциями Map(), Filter(), Fold()
/// </summary>
public static class MapFilterFold<T>
{
    /// <summary>
    /// Преобразование каждого элемента списка с помощью функции mapFunction
    /// </summary>
    public static List<T> Map(List<T> list, Func<T, T> mapFunction)
    {
        var resultList = new List<T>();
        foreach(var item in list)
        {
            resultList.Add(mapFunction(item));
        }
        return resultList;
    }

    /// <summary>
    /// Возвращает список только с теми элементами, для которых функция filterFunction вернула значение true
    /// </summary>
    public static List<T> Filter(List<T> list, Func<T, bool> filterFunction)
    {
        var resultList = new List<T>();
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
    public static T Fold(List<T> list, T initialValue, Func<T, T, T> foldFunction)
    {
        T result = initialValue;
        foreach (var item in list)
        {
            result = foldFunction(result, item);
        }
        return result;
    }
}