namespace Calc;

// Задачи:
// 1. Доделать лексер
// 2. Подумать насчёт двух комментариев в третьем состоянии
// 3. Написать логику обработки нажатия каждой кнопки
// 4. Вывести всё на экран вычислений (заменить комментарии об этом)
// 5. Запилить DataBinding
// 6. Сделать тесты к калькулятору

public static class CalcLogic
{
    private enum State
    {
        EmptyCalculationWindow,
        FirstNumberInWindow,
        ArithmeticalOperation,
        SecondNumberInWindow
    }

    private static State currentState = State.EmptyCalculationWindow;

    private static string firstNumber = "";
    private static string operation = "";
    private static string secondNumber = "";
    private static float result = 0;

    private static bool inverseFirstNumberAfterParsing = false;
    private static bool inverseSecondNumberAfterParsing = false;

    private static void ClearAll()
    {
        currentState = State.EmptyCalculationWindow;
        // Стереть всё с экрана вычислений ( с помощью метода CalcWindowSetText() )

        firstNumber = "";
        operation = "";
        secondNumber = "";
    }

    public static void ChangeState(ButtonType type, string? text)
    {
        if (type == ButtonType.Clear)
        {
            ClearAll();
            return;
        }

        switch (currentState)
        {
            case State.EmptyCalculationWindow:
                if (type == ButtonType.Number)
                {
                    currentState = State.FirstNumberInWindow;
                    firstNumber += text;
                    // Вывести firstNumber на экран вычислений ( с помощью метода CalcWindowSetText() )
                }
                break;
            case State.FirstNumberInWindow:
                if (type == ButtonType.BinaryOperation)
                {
                    currentState = State.ArithmeticalOperation;
                    operation = text!;
                    // Вывести operation на экран вычислений ( с помощью метода CalcWindowSetText() )

                    if (firstNumber[firstNumber.Length - 1] == ',')
                    {
                        firstNumber = firstNumber.Substring(0, firstNumber.Length - 1);
                    }
                    float parsedFirstNumber = float.Parse(firstNumber);
                    if (inverseFirstNumberAfterParsing)
                    {
                        parsedFirstNumber = -parsedFirstNumber;
                    }
                    result += parsedFirstNumber;
                }
                else if (type == ButtonType.Number)
                {
                    firstNumber += text;
                    // Вывести firstNumber на экран вычислений ( с помощью метода CalcWindowSetText() )
                }
                else if (type == ButtonType.InverseNumber)
                {
                    inverseFirstNumberAfterParsing = !inverseFirstNumberAfterParsing;
                    if (float.Parse(firstNumber) > 0)
                    {
                        // Вывести на экран вычислений перед числом унарный знак
                    }
                    else if (float.Parse(firstNumber) < 0)
                    {
                        // Убрать на экране вычислений перед числом унарный знак
                    }
                }
                break;
            case State.ArithmeticalOperation:
                if (type == ButtonType.Number)
                {
                    currentState = State.SecondNumberInWindow;
                    secondNumber += text;
                    // Вывести secondNumber на экран вычислений ( с помощью метода CalcWindowSetText() )
                }
                break;
            case State.SecondNumberInWindow:
                if (type == ButtonType.BinaryOperation)
                {
                    currentState = State.ArithmeticalOperation;
                    operation = text!;
                    // Вывести operation на экран вычислений ( с помощью метода CalcWindowSetText() )

                    firstNumber = secondNumber;
                    secondNumber = "";

                    // Возможно, этот кусок и такой же кусок выше вынести в отдельный метод с осознанным названием ...
                    // Возможно, упразднить secondNumber, так как он вроде не нужен ...
                    if (firstNumber[firstNumber.Length - 1] == ',')
                    {
                        firstNumber = firstNumber.Substring(0, firstNumber.Length - 1);
                    }
                    float parsedFirstNumber = float.Parse(firstNumber);
                    if (inverseFirstNumberAfterParsing)
                    {
                        parsedFirstNumber = -parsedFirstNumber;
                    }

                    switch (text)
                    {
                        case "+":
                            // pass
                            break;
                        case "-":
                            // pass
                            break;
                        case "*":
                            // pass
                            break;
                        case "/":
                            // pass
                            break;
                        case "<Знак квадратного корня>": // Заменить
                            // pass
                            break;
                    }
                }
                else if (type == ButtonType.Equals)
                {
                    // pass
                }
                else if (type == ButtonType.Number)
                {
                    // pass
                }
                else if (type == ButtonType.InverseNumber)
                {
                    // pass
                }
                break;
        }
    }
}

public enum ButtonType
{
    Number,
    BinaryOperation,
    InverseNumber,
    Equals,
    Clear
}