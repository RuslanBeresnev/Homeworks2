namespace PostfixCalculator;

/// <summary>
/// Реализация стека на массиве
/// </summary>
public class ArrayStack : IStack
{
    private double[] items;
    private int count = 0;

    public ArrayStack() => items = new double[25];

    public ArrayStack(int maxLength) => items = new double[maxLength];

    public bool IsEmpty() => count == 0;

    public void Push(double value)
    {
        if (count == items.Length)
        {
            var extendedItems = new double[count * 2];
            for (int i = 0; i < count / 2; i++)
            {
                extendedItems[i] = items[i];
            }
            items = extendedItems;
        }

        items[count] = value;
        count++;
    }

    public double? Pop()
    {
        if (IsEmpty())
        {
            return null;
        }

        count--;
        return items[count];
    }
}