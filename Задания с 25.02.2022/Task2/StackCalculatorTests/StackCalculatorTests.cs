using NUnit.Framework;
using System;
using System.Collections.Generic;
using PostfixCalculator;

namespace StackCalculatorTests;

public class StackCalculatorTests
{
    private static IEnumerable<TestCaseData> Stacks
        => new TestCaseData[]
        {
        new TestCaseData(new PostfixCalculator.PostfixCalculator(new ArrayStack())),
        new TestCaseData(new PostfixCalculator.PostfixCalculator(new ListStack()))
        };

    [TestCaseSource(nameof(Stacks))]
    public void CalculateCorrectSequence(PostfixCalculator.PostfixCalculator calculator)
    {
        (double? result, bool correctWork) = calculator.CalculateExpression("225 6 7 8 + * /");
        Assert.IsTrue(correctWork && Math.Abs((double)result - 2.5) < 0.000001);
    }

    [TestCaseSource(nameof(Stacks))]
    public void CalculateSequenceWithDivisingByZero(PostfixCalculator.PostfixCalculator calculator)
    {
        (double? result, bool correctWork) = calculator.CalculateExpression("5 0 /");
        Assert.IsFalse(correctWork);
    }

    [TestCaseSource(nameof(Stacks))]
    public void CalculteIncorrectSequence(PostfixCalculator.PostfixCalculator calculator)
    {
        (double? result, bool correctWork) = calculator.CalculateExpression("5 6 7 + - * /");
        Assert.IsFalse(correctWork);
    }
}