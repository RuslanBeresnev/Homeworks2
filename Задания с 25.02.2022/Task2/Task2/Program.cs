using System;
using PostfixCalculator;

/// <summary>
/// Интерфейсная часть программы
/// </summary>
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Программа \"Постфиксный калькулятор\". Введите постфиксную последовательность, " +
    "чтобы посчитать её значение:");
        string? sequence = Console.ReadLine();

        if (sequence == "")
        {
            Console.WriteLine("Вы ничего не ввели ...");
        }
        else
        {
            ArrayStack arrayStack = new ArrayStack();
            PostfixCalculator.PostfixCalculator calculator = new PostfixCalculator.PostfixCalculator(arrayStack);
            (double? result, bool allRight) = calculator.CalculateExpression(sequence);

            if (allRight)
            {
                Console.WriteLine($"Результат: {result}");
            }
            else
            {
                Console.WriteLine("Введена некорректная постфиксная последовательность ...");
            }
        }
    }
}