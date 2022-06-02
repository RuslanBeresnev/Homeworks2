namespace UniqueListTests;

using NUnit.Framework;
using UniqueList;
using System;
using System.Collections.Generic;

public class ListTests
{
    private static IEnumerable<TestCaseData> Lists
        => new TestCaseData[]
        {
            new TestCaseData(new UniqueList.List<int>()),
            new TestCaseData(new UniqueList<int>()),
        };

    [TestCaseSource(nameof(Lists))]
    public void AddAndGetElementMethodsTest(UniqueList.List<int> list)
    {
        list.Add(1, 0);
        list.Add(2, 0);
        list.Add(3, 0);
        Assert.AreEqual(3, list.GetElement(0));
        Assert.AreEqual(2, list.GetElement(1));
        Assert.AreEqual(1, list.GetElement(2));
    }

    [TestCaseSource(nameof(Lists))]
    public void SetAndGetElementMethodsTest(UniqueList.List<int> list)
    {
        list.Add(1, 0);
        list.Add(2, 0);
        list.Add(3, 0);
        list.SetElement(0, 0);
        list.SetElement(1, -1);
        list.SetElement(2, -2);
        Assert.AreEqual(0, list.GetElement(0));
        Assert.AreEqual(-1, list.GetElement(1));
        Assert.AreEqual(-2, list.GetElement(2));
    }

    [TestCaseSource(nameof(Lists))]
    public void RemoveAndGetElementMethodsTest(UniqueList.List<int> list)
    {
        list.Add(1, 0);
        list.Add(2, 0);
        list.Add(3, 0);
        list.Remove(0);
        list.Remove(1);
        Assert.AreEqual(1, list.GetElement(0));
        Assert.IsTrue(list.Length == 1);
    }

    [TestCaseSource(nameof(Lists))]
    public void RemoveNonExistingElementTest(UniqueList.List<int> list)
    {
        Assert.Throws<IndexOutOfRangeException>(() => list.Remove(-1));
    }
}