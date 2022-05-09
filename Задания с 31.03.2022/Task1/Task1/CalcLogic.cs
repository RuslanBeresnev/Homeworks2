namespace Calc;

using System.ComponentModel;

/// <summary>
/// Класс, реализующий логику работы калькулятора
/// </summary>
public class CalcLogic : INotifyPropertyChanged
{
    /// <summary>
    /// Состояния конечного автомата
    /// </summary>
    private enum State
    {
        EmptyCalculationWindow,
        NumberInWindow,
        ArithmeticalOperation,
    }

    private State currentState = State.EmptyCalculationWindow;
    private ButtonType? previousPushedButtonType;

    private string number = "";
    private string operation = "";
    private float result = 0;

    private string calcWindowText = "";

    /// <summary>
    /// Получить текущее вычисленное значение
    /// </summary>
    public float Result => result;

    /// <summary>
    /// Текст на экране вычислений калькулятора
    /// </summary>
    public string CalcWindowText {
        get { return calcWindowText; }
        private set
        {
            if (value != CalcWindowText)
            {
                calcWindowText = value;
                OnPropertyChanged("CalcWindowText");
            }
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>
    /// Обработчик изменения свойства класса
    /// </summary>
    protected virtual void OnPropertyChanged(string propertyName)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    /// <summary>
    /// Очистить экран вычислений, текущие данные и перейти в нулевое состояние
    /// </summary>
    private void ClearAll()
    {
        currentState = State.EmptyCalculationWindow;
        CalcWindowText = "";

        number = "";
        operation = "";
        result = 0;
    }

    /// <summary>
    /// Преобразовать текст из цифр в число
    /// </summary>
    private float ParseNumber()
    {
        float parsedNumber;

        if (number[number.Length - 1] == ',')
        {
            string numberWithoutComma = number.Substring(0, number.Length - 1);
            parsedNumber = float.Parse(numberWithoutComma);
        }
        else
        {
            parsedNumber = float.Parse(number);
        }

        return parsedNumber;
    }

    /// <summary>
    /// Пересчитать результат вычислений
    /// </summary>
    private bool RecalculateResultValue()
    {
        float parsedNumber = ParseNumber();

        switch (operation)
        {
            case "+":
                result += parsedNumber;
                break;
            case "-":
                result -= parsedNumber;
                break;
            case "*":
                result *= parsedNumber;
                break;
            case "/":
                if (Math.Abs(parsedNumber) < 0.0000001F)
                {
                    return false;
                }
                result /= parsedNumber;
                break;
            case "√":
                if (result < 0)
                {
                    return false;
                }
                result = (float)Math.Sqrt(result);
                break;
        }

        return true;
    }

    /// <summary>
    /// Вычислить результат после применения операции и вывести на экран результат или сообщение об ошибке
    /// </summary>
    private void CheckOperationCorrectnessAndDisplayResultOnScreen()
    {
        bool successfulyRecalculation = RecalculateResultValue();
        if (!successfulyRecalculation)
        {
            ClearAll();
            CalcWindowText = "Ошибка";
        }
        else
        {
            CalcWindowText = result.ToString();
        }
    }

    /// <summary>
    /// Поменять состояние конечного автомата
    /// </summary>
    public void ChangeState(ButtonType currentPushedButtonType, string? text)
    {
        if (currentPushedButtonType == ButtonType.Clear)
        {
            ClearAll();
            return;
        }

        switch (currentState)
        {
            case State.EmptyCalculationWindow:
                if (currentPushedButtonType == ButtonType.Number && text != ",")
                {
                    ClearAll();
                    currentState = State.NumberInWindow;
                    number += text;
                    CalcWindowText = number;
                }
                break;
            case State.NumberInWindow:
                if (operation == "")
                {
                    result = ParseNumber();
                }

                if (currentPushedButtonType == ButtonType.BinaryOperation || currentPushedButtonType == ButtonType.Equals)
                {
                    if (!(previousPushedButtonType == ButtonType.Equals && currentPushedButtonType == ButtonType.BinaryOperation) &&
                        operation != "")
                    {
                        CheckOperationCorrectnessAndDisplayResultOnScreen();
                    }
                    if (currentPushedButtonType == ButtonType.BinaryOperation)
                    {
                        operation = text!;
                        currentState = State.ArithmeticalOperation;
                    }
                }
                else if (currentPushedButtonType == ButtonType.Number)
                {
                    if (number == "0")
                    {
                        if (text == ",")
                        {
                            number += ",";
                        }
                        else
                        {
                            number = text!;
                        }
                    }
                    else
                    {
                        if (text != "," || (text == "," && !number.Contains(",")))
                        {
                            number += text;
                        }
                    }

                    CalcWindowText = number;
                }
                else if (currentPushedButtonType == ButtonType.UnaryOperation)
                {
                    if (text == "±")
                    {
                        if (ParseNumber() > 0)
                        {
                            number = "-" + number;
                            CalcWindowText = number;
                        }
                        else if (ParseNumber() < 0)
                        {
                            number = number.Substring(1);
                            CalcWindowText = number;
                        }
                    }
                    else if (text == "√")
                    {
                        operation = "√";
                        CheckOperationCorrectnessAndDisplayResultOnScreen();
                    }
                }
                break;
            case State.ArithmeticalOperation:
                if (currentPushedButtonType == ButtonType.Number && text != ",")
                {
                    currentState = State.NumberInWindow;
                    number = text!;
                    CalcWindowText = number;
                }
                else if (currentPushedButtonType == ButtonType.BinaryOperation)
                {
                    operation = text!;
                }
                else if (currentPushedButtonType == ButtonType.Equals)
                {
                    CheckOperationCorrectnessAndDisplayResultOnScreen();
                }
                break;
        }

        previousPushedButtonType = currentPushedButtonType;
    }
}

/// <summary>
/// Типы кнопок на калькуляторе
/// </summary>
public enum ButtonType
{
    Number,
    BinaryOperation,
    UnaryOperation,
    Equals,
    Clear
}