namespace GameTests;

using NUnit.Framework;
using System.IO;
using Game;

public class GameTests
{
    [Test]
    public void TryingGetThroughTheWallTest()
    {
        var game = new Game("../../../Close Area Map.txt");
        game.TestRun = true;

        Assert.False(game.CanMoveInThisDirection(Game.Direction.Left));
        Assert.False(game.CanMoveInThisDirection(Game.Direction.Up));
    }

    [Test]
    public void TryingMoveInEmptySpaceTest()
    {
        var game = new Game("../../../Close Area Map.txt");
        game.TestRun = true;

        Assert.True(game.CanMoveInThisDirection(Game.Direction.Right));
        game.MoveMainCharacter(Game.Direction.Right);
        Assert.AreEqual((2, 1), game.MainCharacterCoordinates);

        Assert.True(game.CanMoveInThisDirection(Game.Direction.Down));
        game.MoveMainCharacter(Game.Direction.Down);
        Assert.AreEqual((2, 2), game.MainCharacterCoordinates);
    }

    [Test]
    public void TryingGetThroughConsoleBordersTest()
    {
        var game = new Game("../../../Open Area Map.txt");
        game.TestRun = true;

        Assert.False(game.CanMoveInThisDirection(Game.Direction.Left));
        Assert.False(game.CanMoveInThisDirection(Game.Direction.Up));
    }

    [Test]
    public void MultipleMainCharactersInMapTest()
    {
        Assert.Throws<InvalidDataException>(() => new Game("../../../Map with multiple main characters.txt"));
    }

    [Test]
    public void MapWithoutASingleMainCharacterTest()
    {
        Assert.Throws<InvalidDataException>(() => new Game("../../../Map without a single main character.txt"));
    }
}