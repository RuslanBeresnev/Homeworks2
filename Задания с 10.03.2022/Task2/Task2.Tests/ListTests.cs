namespace UniqueListTests;

using NUnit.Framework;
using UniqueList;

public class ListTests
{
    [Test]
    public void AddAndGetElementMethodsTest()
    {
        var list = new List<int>();
        list.Add(1);
        list.Add(2);
        list.Add(3);
        Assert.IsTrue(list.GetElement(0) == 1);
        Assert.IsTrue(list.GetElement(1) == 2);
        Assert.IsTrue(list.GetElement(2) == 3);
    }

    [Test]
    public void SetAndGetElementMethodsTest()
    {
        var list = new List<int>();
        list.Add(1);
        list.Add(2);
        list.Add(3);
        list.SetElement(0, 0);
        list.SetElement(1, 1);
        list.SetElement(2, 2);
        Assert.IsTrue(list.GetElement(0) == 0);
        Assert.IsTrue(list.GetElement(1) == 1);
        Assert.IsTrue(list.GetElement(2) == 2);
    }

    [Test]
    public void RemoveAndGetElementMethodsTest()
    {
        var list = new List<int>();
        list.Add(1);
        list.Add(2);
        list.Add(3);
        list.Remove(0);
        list.Remove(1);
        Assert.IsTrue(list.GetElement(0) == default(int));
        Assert.IsTrue(list.GetElement(1) == default(int));
        Assert.IsTrue(list.GetElement(2) == 3);
        Assert.IsTrue(list.Length == 3);
    }

    [Test]
    public void RemoveNonExistingElementTest()
    {
        var list = new List<int>();
        Assert.Throws<NonExistentElementReferencingException>(() => list.Remove(0));
    }
}