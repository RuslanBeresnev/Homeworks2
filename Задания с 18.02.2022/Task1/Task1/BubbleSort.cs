using System;

class Sort
{
    static void Swap(ref int a, ref int b)
    {
        var temporary = a;
        a = b;
        b = temporary;
    }

    static int[] BubbleSort(int[] array)
    {
        var length = array.Length;
        for (var i = 1; i < length; i++)
        {
            for (var j = 0; j < length - i; j++)
            {
                if (array[j] > array[j + 1])
                {
                    Swap(ref array[j], ref array[j + 1]);
                }
            }
        }
        return array;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Введите элементы массива через пробел: ");
        var data = Console.ReadLine().Split(" ");
        var array = new int[data.Length];
        for (int i = 0; i < data.Length; i++)
        {
            array[i] = Convert.ToInt32(data[i]);
        }
        Console.WriteLine("Отсортированный массив: {0}", string.Join(" ", BubbleSort(array)));
    }
}