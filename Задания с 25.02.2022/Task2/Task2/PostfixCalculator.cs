using System;

internal class PostfixCalculator
{
    private IStack stack;

    internal PostfixCalculator(IStack stack)
    {
        this.stack = stack;
    }

    internal double CalculateExpression(string expression)
    {
        string[] tokens = expression.Split(' ');

        foreach(var token in tokens)
        {
            int number;
            bool isNumber = int.TryParse(token, out number);
            if (isNumber)
                stack.Push(number);
            else
            {
                switch(token)
                {
                    case "+":
                        stack.Push(stack.Pop() + stack.Pop());
                        break;
                    case "-":
                        double number2 = stack.Pop();
                        stack.Push(stack.Pop() - number2);
                        break;
                    case "*":
                        stack.Push(stack.Pop() * stack.Pop());
                        break;
                    case "/":
                        number2 = stack.Pop();
                        if (Math.Abs(number2 - 0.0) > 0.00000001)
                            stack.Push(stack.Pop() / number2);
                        else
                            throw new InvalidOperationException("Деление на ноль");
                        break;
                    default:
                        throw new InvalidOperationException("Неизвестная операция");

                }
            }
        }

        return stack.Pop();
    }
}