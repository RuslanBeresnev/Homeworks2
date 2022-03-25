using NUnit.Framework;
using System.Collections.Generic;
using PostfixCalculator;

namespace StackCalculatorTests;

public class StackTests
{
    private static IEnumerable<TestCaseData> Stacks
        => new TestCaseData[]
        {
        new TestCaseData(new ArrayStack()),
        new TestCaseData(new ListStack())
        };

    public void StackNotEmptyAfterPush(IStack stack)
    {
        stack.Push(1);
        Assert.False(stack.IsEmpty());
    }

    [TestCaseSource(nameof(Stacks))]
    public void PushAndPopMethodsWorkCorrectly(IStack stack)
    {
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        var values = new double?[3];
        bool correctWork = true;

        for (int i = 0; i < 3; i++)
        {
            (values[i], bool correctOperation) = stack.Pop();
            correctWork = correctWork && correctOperation;
        }

        Assert.True(values[0] == 3 && values[1] == 2 && values[2] == 1);
    }

    public void IsEmptyMethodWorkCorrectly(IStack stack)
    {
        Assert.True(stack.IsEmpty());
        stack.Push(1);
        Assert.False(stack.IsEmpty());
    }

    public void PopUsingWithEmptyStack(IStack stack)
    {
        (double? value, bool correctWork) = stack.Pop();
        Assert.False(correctWork);
    }
}