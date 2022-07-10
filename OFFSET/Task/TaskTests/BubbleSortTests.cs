namespace OffsetTests;

using NUnit.Framework;
using Offset;

using System.Collections.Generic;

public class BubbleSortTests
{
    [Test]
    public void IntListTest()
    {
        var intList = new List<int>() { 5, 6, 1, 2, 7 };
        var intComparer = new ObjectComparer<int>();

        BubbleSort<int>.Sort(intList, intComparer);

        var correctIntList = new List<int>() { 1, 2, 5, 6, 7 };
        Assert.AreEqual(correctIntList, intList);
    }

    [Test]
    public void StringListTest()
    {
        var stringList = new List<string>() { "ololo", "aboba" };
        var stringComparer = new ObjectComparer<string>();

        BubbleSort<string>.Sort(stringList, stringComparer);

        var correctStringList = new List<string>() { "aboba", "ololo" };
        Assert.AreEqual(correctStringList, stringList);
    }
}