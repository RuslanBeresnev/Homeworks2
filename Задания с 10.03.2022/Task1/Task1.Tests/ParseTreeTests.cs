namespace ParseTreeTests;

using NUnit.Framework;
using ParseTree;
using System;

public class Tests
{
    [Test]
    public void StandardSequenceTest()
    {
        string sequence = "(/ (* 5 -22) (- (- 9 8) (* -10 1)))";
        var parseTree = new ParseTree(sequence);
        int evaluation = parseTree.Calculate();
        Assert.AreEqual(-10, evaluation);
    }

    [Test]
    public void DivisionByZeroTest()
    {
        string sequence = "(/ 10 0)";
        var parseTree = new ParseTree(sequence);
        Assert.Throws<ArgumentException>(() => parseTree.Calculate());
    }

    [Test]
    public void EmptySequenceTest()
    {
        string sequence = "";
        var parseTree = new ParseTree(sequence);
        Assert.Throws<InvalidOperationException>(() => parseTree.Calculate());
    }

    [Test]
    public void IncorrectSequenceTest()
    {
        string sequence = "(( ))) dev 3";
        var parseTree = new ParseTree(sequence);
        Assert.Throws<InvalidOperationException>(() => parseTree.Calculate());
    }
}