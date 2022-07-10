namespace Game;

using System;

/// <summary>
/// Класс обработки событий нажатия клавиш управления
/// </summary>
public class EventLoop
{
    public event EventHandler<EventArgs> leftHandler = (sender, args) => { };
    public event EventHandler<EventArgs> rightHandler = (sender, args) => { };
    public event EventHandler<EventArgs> upHandler = (sender, args) => { };
    public event EventHandler<EventArgs> downHandler = (sender, args) => { };

    /// <summary>
    /// Игровой цикл
    /// </summary>
    public void Run()
    {
        bool stopGame = false;

        while (!stopGame)
        {
            var key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.Enter:
                    stopGame = true;
                    break;
                case ConsoleKey.LeftArrow:
                    leftHandler(this, EventArgs.Empty);
                    break;
                case ConsoleKey.RightArrow:
                    rightHandler(this, EventArgs.Empty);
                    break;
                case ConsoleKey.UpArrow:
                    upHandler(this, EventArgs.Empty);
                    break;
                case ConsoleKey.DownArrow:
                    downHandler(this, EventArgs.Empty);
                    break;
            }
        }

        Console.Clear();
    }
}