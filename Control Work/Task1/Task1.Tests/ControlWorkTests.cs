namespace ControlWorkTests;

using NUnit.Framework;
using ControlWork;
using System.Collections.Generic;

public class Tests
{
    [Test]
    public void AdditionMethodTest()
    {
        var firstVector = new SparseVector(new int[3] { 1, 0, 3 });

        var secondVectorCoordinates = new Dictionary<int, int>();
        secondVectorCoordinates.Add(1, 5);
        secondVectorCoordinates.Add(2, 3);
        var secondVector = new SparseVector(secondVectorCoordinates, 3);

        var resultVector = VectorAddition(firstVector, secondVector);

        Assert.AreEqual(resultVector.Coordinates[0], 1);
        Assert.AreEqual(resultVector.Coordinates[1], 5);
        Assert.AreEqual(resultVector.Coordinates[2], 6);
    }

    [Test]
    public void SubtractionMethodTest()
    {
        var firstVector = new SparseVector(new int[3] { 1, 0, 3 });

        var secondVectorCoordinates = new Dictionary<int, int>();
        secondVectorCoordinates.Add(1, 5);
        secondVectorCoordinates.Add(2, 3);
        var secondVector = new SparseVector(secondVectorCoordinates, 3);

        var resultVector = VectorSubtraction(firstVector, secondVector);

        Assert.AreEqual(resultVector.Coordinates[0], 1);
        Assert.AreEqual(resultVector.Coordinates[1], -5);
        Assert.AreEqual(resultVector.Coordinates[2], 0);
    }

    [Test]
    public void ScalarMultiplicationMethodTest()
    {
        var firstVector = new SparseVector(new int[3] { 1, 0, 3 });

        var secondVectorCoordinates = new Dictionary<int, int>();
        secondVectorCoordinates.Add(1, 5);
        secondVectorCoordinates.Add(2, 3);
        var secondVector = new SparseVector(secondVectorCoordinates, 3);

        Assert.AreEqual(ScalarMultiplication(firstVector, secondVector), 9);
    }

    [Test]
    public void IsZeroVectorMethodTest()
    {
        var firstVector = new SparseVector(new int[3] { 1, 0, 3 });
        var secondVector = new SparseVector(new int[3] { 0, 0, 0 });

        Assert.IsFalse(IsZeroVector(firstVector));
        Assert.IsTrue(IsZeroVector(secondVector));
    }

    [Test]
    public void DifferentLengthVectorsTest()
    {
        var firstVector = new SparseVector(new int[3] { 1, 0, 3 });
        var secondVector = new SparseVector(new int[5] { 0, 0, 0, 3, 5});

        Assert.Throws<System.InvalidOperationException>(() => VectorAddition(firstVector, secondVector));
    }
}