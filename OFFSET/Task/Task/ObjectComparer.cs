namespace Offset;

using System.Collections.Generic;

/// <summary>
/// Класс, реализующий сравнение объектов
/// </summary>
public class ObjectComparer<T> : IComparer<T> where T : IComparable<T>
{
    /// <summary>
    /// Сравнение двух объектов одного типа
    /// </summary>
    public int Compare(T? x, T? y)
    {
        if (x == null)
        {
            if (y == null)
            {
                return 0;
            }

            return -1;
        }

        if (y == null)
        {
            return 1;
        }

        return x.CompareTo(y);
    }
}