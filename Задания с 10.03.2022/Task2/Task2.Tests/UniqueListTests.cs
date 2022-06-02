namespace UniqueListTests;

using NUnit.Framework;
using UniqueList;

public class UniqueListTests
{
    [Test]
    public void AddAlreadyExistingElementTest()
    {
        var list = new UniqueList<int>();
        list.Add(1, 0);
        Assert.Throws<ExistingElementAddingException>(() => list.Add(1, 0));
    }

    [Test]
    public void SetlreadyExistingElementTest()
    {
        var list = new UniqueList<int>();
        list.Add(1, 0);
        list.Add(2, 0);
        list.Add(3, 0);
        Assert.Throws<ExistingElementAddingException>(() => list.SetElement(0, 1));
    }
}