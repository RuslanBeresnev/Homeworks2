namespace Game;

/// <summary>
/// Класс, который запускает игровой процесс
/// </summary>
public class Program
{
    private static void Main(string[] args)
    {
        var eventLoop = new EventLoop();
        var game = new Game("../../../map.txt");
        game.DrawMap();

        eventLoop.leftHandler += game.OnLeft;
        eventLoop.rightHandler += game.OnRight;
        eventLoop.upHandler += game.OnUp;
        eventLoop.downHandler += game.OnDown;

        eventLoop.Run();
    }
}