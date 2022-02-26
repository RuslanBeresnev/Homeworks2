using System;

public class Program
{

    public static bool GlobalTest()
    {
        ListStack listStack = new ListStack();
        PostfixCalculator firstCalculator = new PostfixCalculator(listStack);
        double firstResult = firstCalculator.CalculateExpression("3 2 - 5 / 6 *");

        ArrayStack arrayStack = new ArrayStack();
        PostfixCalculator secondCalculator = new PostfixCalculator(arrayStack);
        double secondResult = secondCalculator.CalculateExpression("3 2 - 5 / 6 *");

        return Math.Abs(firstResult - 1.2) < 0.000001 && Math.Abs(secondResult - 1.2) < 0.000001;
    }

    public static void Main(string[] args)
    {
        if (GlobalTest())
            Console.WriteLine("Калькулятор работает правильно");
        else
            Console.WriteLine("Калькулятор работает неправильно");
    }
}