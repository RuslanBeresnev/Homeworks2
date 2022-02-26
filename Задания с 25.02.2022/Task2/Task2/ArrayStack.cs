using System;

internal class ArrayStack : IStack
{
    private double[] items;
    private int count = 0;

    internal ArrayStack()
        => items = new double[25];

    internal ArrayStack(int count)
        => items = new double[count];

    internal bool IsEmpty()
        => count == 0;

    public void Push(double value)
    {
        if (count == items.Length)
        {
            throw new InvalidOperationException("Переполнение стека");
        }
        items[count] = value;
        count++;
    }

    public double Pop()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Стек пуст");
        count--;
        double value = items[count];
        items[count] = 0.0;
        return value;
    }
}