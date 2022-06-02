namespace MapFilterFoldTests;

using NUnit.Framework;
using MapFilterFold;
using System.Collections.Generic;

public class Tests
{
    private List<int> numbersList = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

    [Test]
    public void MapFunctionTest()
    {
        var resultList = MapFilterFold.Map(numbersList, x => x * 3);
        Assert.AreEqual(new List<int> { 3, 6, 9, 12, 15, 18, 21, 24, 27, 30 }, resultList);
        Assert.AreEqual(new List<int>(), MapFilterFold.Map(new List<int>(), x => x * 3));
    }

    [Test]
    public void FilterFunctionTest()
    {
        var resultList = MapFilterFold.Filter(numbersList, x => x % 3 == 0);
        Assert.AreEqual(new List<int> { 3, 6, 9 }, resultList);
        Assert.AreEqual(new List<int>(), MapFilterFold.Filter(new List<int>(), x => x % 3 == 0));
    }

    [Test]
    public void FoldFunctionTest()
    {
        int result = MapFilterFold.Fold(numbersList, 1, (acc, elem) => acc * elem);
        Assert.AreEqual(3628800, result);
        Assert.AreEqual(1, MapFilterFold.Fold(new List<int>(), 1, (acc, elem) => acc * elem));
    }
}