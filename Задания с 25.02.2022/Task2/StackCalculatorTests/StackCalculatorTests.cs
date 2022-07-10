namespace StackCalculatorTests;

using NUnit.Framework;
using System.Collections.Generic;
using PostfixCalculator;

public class StackCalculatorTests
{
    private static IEnumerable<TestCaseData> Stacks
        => new TestCaseData[]
        {
            new TestCaseData(new PostfixCalculator(new ArrayStack())),
            new TestCaseData(new PostfixCalculator(new ListStack()))
        };

    [TestCaseSource(nameof(Stacks))]
    public void CalculateCorrectSequence(PostfixCalculator calculator)
    {
        double? result = calculator.CalculateExpression("225 6 7 8 + * /");
        Assert.True(result != null);
        Assert.AreEqual(2.5, result!.Value, 0.000001);
    }

    [TestCaseSource(nameof(Stacks))]
    public void CalculateSequenceWithDivisingByZero(PostfixCalculator calculator)
    {
        double? result = calculator.CalculateExpression("5 0 /");
        Assert.True(result == null);
    }

    [TestCaseSource(nameof(Stacks))]
    public void CalculteIncorrectSequence(PostfixCalculator calculator)
    {
        double? result = calculator.CalculateExpression("5 6 7 + - * /");
        Assert.True(result == null);
    }
}