/// <summary>
/// Интерфейс стека
/// </summary>
public interface IStack
{
    /// <summary>
    /// Добавить элемент в стек
    /// </summary>
    public void Push(double value);

    /// <summary>
    /// Вернуть верхний элемент и удалить его из стека
    /// </summary>
    public double? Pop();

    /// <summary>
    /// Проверка стека на пустоту
    /// </summary>
    public bool IsEmpty();
}