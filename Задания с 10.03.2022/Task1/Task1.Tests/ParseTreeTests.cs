namespace ParseTreeTests;

using NUnit.Framework;
using ParseTree;

public class Tests
{
    [Test]
    public void StandardSequenceTest()
    {
        string sequence = "(/ (* 5 -22) (- (- 9 8) (* -10 1)))";
        var parseTree = new ParseTree(sequence);
        var root = parseTree.Parse();
        int evaluation = parseTree.Calculate(root);
        Assert.IsTrue(evaluation == -10);
    }

    [Test]
    public void DivisionByZeroTest()
    {
        string sequence = "(/ 10 0)";
        var parseTree = new ParseTree(sequence);
        var root = parseTree.Parse();
        Assert.Throws<System.ArgumentException>(() => parseTree.Calculate(root));
    }

    [Test]
    public void EmptySequenceTest()
    {
        string sequence = "";
        var parseTree = new ParseTree(sequence);
        var root = parseTree.Parse();
        Assert.IsTrue(root == null);
    }

    [Test]
    public void IncorrectSequenceTest()
    {
        string sequence = "(( ))) dev 3";
        var parseTree = new ParseTree(sequence);
        Assert.Throws<System.InvalidOperationException>(() => parseTree.Parse());
    }
}