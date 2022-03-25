using System;

namespace PostfixCalculator;

public class ArrayStack : IStack
{
    private double[] items;
    private int count = 0;

    public ArrayStack()
        => items = new double[25];

    public ArrayStack(int count)
        => items = new double[count];

    public bool IsEmpty()
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

    public (double?, bool) Pop()
    {
        if (IsEmpty())
            return (null, false);
        count--;
        double value = items[count];
        items[count] = 0.0;
        return (value, true);
    }
}