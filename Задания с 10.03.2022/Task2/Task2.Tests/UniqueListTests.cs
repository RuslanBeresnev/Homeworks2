namespace UniqueListTests;

using NUnit.Framework;
using UniqueList;

public class UniqueListTests
{
    [Test]
    public void AddAlreadyExistingElementTest()
    {
        var list = new UniqueList<int>();
        list.Add(1);
        Assert.Throws<ExistingElementAddingException>(() => list.Add(1));
    }
}