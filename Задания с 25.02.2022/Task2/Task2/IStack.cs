using System;

/// <summary>
/// Интерфейс стека
/// </summary>
public interface IStack
{
    /// <summary>
    /// Добавляет элемент в стек
    /// </summary>
    /// <param name="value">То, что нужно добавить</param>
    public void Push(double value);
    /// <summary>
    /// Берёт верхний элемент стека и затем удаляет его
    /// </summary>
    public (double?, bool) Pop();
    /// <summary>
    /// Проверка стека на пустоту
    /// </summary>
    public bool IsEmpty();
}