namespace StackCalculatorTests;

using NUnit.Framework;
using System.Collections.Generic;
using PostfixCalculator;

public class StackTests
{
    private static IEnumerable<TestCaseData> Stacks
        => new TestCaseData[]
        {
            new TestCaseData(new ArrayStack()),
            new TestCaseData(new ListStack())
        };

    [TestCaseSource(nameof(Stacks))]
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

        for (int i = 0; i < 3; i++)
        {
            Assert.AreEqual(3 - i, stack.Pop());
        }
    }

    [TestCaseSource(nameof(Stacks))]
    public void IsEmptyMethodWorkCorrectly(IStack stack)
    {
        Assert.True(stack.IsEmpty());
        stack.Push(1);
        Assert.False(stack.IsEmpty());
    }

    [TestCaseSource(nameof(Stacks))]
    public void PopUsingWithEmptyStack(IStack stack)
    {
        Assert.AreEqual(null, stack.Pop());
    }
}