using System;

namespace PostfixCalculator;

/// <summary>
/// Реализация постфиксного калькулятора на выбранном стеке
/// </summary>
public class PostfixCalculator
{
    private IStack stack;

    public PostfixCalculator(IStack stack)
    {
        this.stack = stack;
    }

    /// <summary>
    /// Подсчитывает значение по постфиксной записи
    /// </summary>
    /// <param name="expression">Постфиксная запись</param>
    public (double?, bool) CalculateExpression(string expression)
    {
        string[] tokens = expression.Split(' ');
        bool isCorrectSequence = true;

        foreach(var token in tokens)
        {
            if (!isCorrectSequence)
            {
                break;
            }

            int number;
            bool isNumber = int.TryParse(token, out number);
            if (isNumber)
                stack.Push(number);
            else
            {
                (double? number2, isCorrectSequence) = stack.Pop();
                (double? number1, isCorrectSequence) = stack.Pop();

                if (!isCorrectSequence)
                    break;

                switch(token)
                {
                    case "+":
                        stack.Push((double)number1 + (double)number2);
                        break;
                    case "-":
                        stack.Push((double)number1 - (double)number2);
                        break;
                    case "*":
                        stack.Push((double)number1 * (double)number2);
                        break;
                    case "/":
                        if (Math.Abs((double)number2 - 0.0) > 0.00000001)
                            stack.Push((double)number1 / (double)number2);
                        else
                            isCorrectSequence = false;
                        break;
                    default:
                        isCorrectSequence = false;
                        break;
                }
            }
        }

        (double? result, isCorrectSequence) = stack.Pop();
        return (result, isCorrectSequence);
    }
}