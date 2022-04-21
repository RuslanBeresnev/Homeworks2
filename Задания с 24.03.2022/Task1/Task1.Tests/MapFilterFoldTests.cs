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
        var resultList = MapFilterFold<int>.Map(numbersList, x => x * 3);
        Assert.AreEqual(resultList, new List<int> { 3, 6, 9, 12, 15, 18, 21, 24, 27, 30 });
    }

    [Test]
    public void FilterFunctionTest()
    {
        var resultList = MapFilterFold<int>.Filter(numbersList, x => x % 3 == 0);
        Assert.AreEqual(resultList, new List<int> { 3, 6, 9 });
    }

    [Test]
    public void FoldFunctionTest()
    {
        int result = 0;
        result = MapFilterFold<int>.Fold(numbersList, 1, (acc, elem) => acc * elem);
        Assert.AreEqual(result, 3628800);
    }
}