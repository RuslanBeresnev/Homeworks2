namespace SkipList;

using System.Collections.Generic;

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
        public ListElement(T value)
        {
            Value = value;
        }

        /// <summary>
        /// Значение элемента списка
        /// </summary>
        public T Value { get; private set; }

        /// <summary>
        /// Следующий элемент
        /// </summary>
        public ListElement? Next { get; set; }

        /// <summary>
        /// Тот же элемент более нижнего уровня
        /// </summary>
        public ListElement? Bottom { get; set; }
    }

    public SkipList(int levelsCount)
    {
        LevelsCount = levelsCount;
        Count = 0;
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
    /// Добавить элемент в список
    /// </summary>
    public void Add(T item)
    {
        // pass
    }

    /// <summary>
    /// Очистить список от всех значений
    /// </summary>
    public void Clear()
    {
        // pass
    }

    /// <summary>
    /// Проверить наличие элемента в списке
    /// </summary>
    public bool Contains(T item)
    {
        // pass
    }

    /// <summary>
    /// Удалить элемент из списка
    /// </summary>
    public bool Remove(T item)
    {
        // pass
    }
}