namespace CalcTests;

using NUnit.Framework;
using Calc;
using System;

public class CalcTests
{
    [Test]
    public void AdditionOperationTest()
    {
        var calc = new CalcLogic();

        calc.ChangeState(ButtonType.Number, "5");
        calc.ChangeState(ButtonType.Number, "0");
        calc.ChangeState(ButtonType.BinaryOperation, "+");
        calc.ChangeState(ButtonType.Number, "4");
        calc.ChangeState(ButtonType.Equals, "=");

        Assert.AreEqual(calc.Result, 54);
    }

    [Test]
    public void SubtractionOperationTest()
    {
        var calc = new CalcLogic();

        calc.ChangeState(ButtonType.Number, "5");
        calc.ChangeState(ButtonType.Number, "0");
        calc.ChangeState(ButtonType.BinaryOperation, "-");
        calc.ChangeState(ButtonType.Number, "5");
        calc.ChangeState(ButtonType.Number, "5");
        calc.ChangeState(ButtonType.Equals, "=");

        Assert.AreEqual(calc.Result, -5);
    }

    [Test]
    public void MultiplicationOperationTest()
    {
        var calc = new CalcLogic();

        calc.ChangeState(ButtonType.Number, "5");
        calc.ChangeState(ButtonType.Number, "0");
        calc.ChangeState(ButtonType.BinaryOperation, "*");
        calc.ChangeState(ButtonType.Number, "4");
        calc.ChangeState(ButtonType.Equals, "=");

        Assert.AreEqual(calc.Result, 200);
    }

    [Test]
    public void DivisionOperationTest()
    {
        var calc = new CalcLogic();

        calc.ChangeState(ButtonType.Number, "5");
        calc.ChangeState(ButtonType.Number, "0");
        calc.ChangeState(ButtonType.BinaryOperation, "/");
        calc.ChangeState(ButtonType.Number, "4");
        calc.ChangeState(ButtonType.Equals, "=");

        Assert.True(Math.Abs(calc.Result - 12.5F) < 0.000001);
    }

    [Test]
    public void SquareRootFromPositiveNumberTest()
    {
        var calc = new CalcLogic();

        calc.ChangeState(ButtonType.Number, "2");
        calc.ChangeState(ButtonType.Number, "5");
        calc.ChangeState(ButtonType.Number, "6");
        calc.ChangeState(ButtonType.UnaryOperation, "√");

        Assert.AreEqual(calc.Result, 16);
    }

    [Test]
    public void SeveralOperationsStraightTest()
    {
        var calc = new CalcLogic();

        calc.ChangeState(ButtonType.Number, "5");
        calc.ChangeState(ButtonType.Number, "0");
        calc.ChangeState(ButtonType.BinaryOperation, "+");
        calc.ChangeState(ButtonType.Number, "4");
        calc.ChangeState(ButtonType.BinaryOperation, "*");

        Assert.AreEqual(calc.Result, 54);

        calc.ChangeState(ButtonType.Number, "5");
        calc.ChangeState(ButtonType.Number, "4");
        calc.ChangeState(ButtonType.Equals, "=");

        Assert.AreEqual(calc.Result, 2916);

        calc.ChangeState(ButtonType.UnaryOperation, "√");

        Assert.AreEqual(calc.Result, 54);
    }

    [Test]
    public void TryingToEnterSeveralCommasTest()
    {
        var calc = new CalcLogic();

        calc.ChangeState(ButtonType.Number, "5");
        calc.ChangeState(ButtonType.Number, "5");
        calc.ChangeState(ButtonType.Number, ",");
        calc.ChangeState(ButtonType.Number, ",");
        calc.ChangeState(ButtonType.Number, ",");

        Assert.AreEqual(calc.Result, 55);
    }

    [Test]
    public void TryingToDivideByZeroTest()
    {
        var calc = new CalcLogic();

        calc.ChangeState(ButtonType.Number, "5");
        calc.ChangeState(ButtonType.Number, "0");
        calc.ChangeState(ButtonType.BinaryOperation, "/");
        calc.ChangeState(ButtonType.Number, "0");
        calc.ChangeState(ButtonType.Equals, "=");

        Assert.AreEqual(calc.CalcWindowText, "Ошибка");
    }

    [Test]
    public void SquareRootFromNegativeNumberTest()
    {
        var calc = new CalcLogic();

        calc.ChangeState(ButtonType.Number, "5");
        calc.ChangeState(ButtonType.Number, "0");
        calc.ChangeState(ButtonType.UnaryOperation, "±");
        calc.ChangeState(ButtonType.UnaryOperation, "√");

        Assert.AreEqual(calc.CalcWindowText, "Ошибка");
    }
}