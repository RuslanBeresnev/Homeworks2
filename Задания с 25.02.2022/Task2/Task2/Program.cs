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
            return;
        }

        var arrayStack = new ArrayStack();
        var calculator = new PostfixCalculator.PostfixCalculator(arrayStack);
        double? result = calculator.CalculateExpression(sequence!);

        if (result != null)
        {
            Console.WriteLine($"Результат: {result}");
        }
        else
        {
            Console.WriteLine("Введена некорректная постфиксная последовательность ...");
        }
    }
}