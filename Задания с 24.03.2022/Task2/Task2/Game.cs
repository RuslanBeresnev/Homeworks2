namespace Game;

using System;

/// <summary>
/// Класс с игровыми функциями и механиками
/// </summary>
public class Game
{
    private bool testRun = false;

    private string fileName;
    private char[,] mapMatrix;
    private (int, int) mainCharacterCoordinates;

    private List<char> symbolsWithoutCollider = new List<char>() { default(char), ' ', '@' };

    public Game(string fileName)
    {
        this.fileName = fileName;
        mapMatrix = BuildMapFromFile();
        mainCharacterCoordinates = GetMainCharacterStartCoordinates();
    }

    /// <summary>
    /// Получить текущие координаты главного персонажа
    /// </summary>
    public (int, int) MainCharacterCoordinates => mainCharacterCoordinates;

    /// <summary>
    /// Для включения тестового прогона
    /// </summary>
    public bool TestRun { get; set; }

    /// <summary>
    /// Создать по файлу игровую карту в виде двумерного массива
    /// </summary>
    private char[,] BuildMapFromFile()
    {
        var lines = new List<string?>();
        var streamReader = new StreamReader(fileName);

        int maxLineLength = 0;
        int linesCount = 0;

        while (!streamReader.EndOfStream)
        {
            string? line = streamReader.ReadLine();
            lines.Add(line);

            if (line != null)
            {
                maxLineLength = Math.Max(maxLineLength, line.Length);
            }
            linesCount++;
        }
        streamReader.Close();

        var mapMatrix = new char[linesCount, maxLineLength];

        for (int i = 0; i < linesCount; i++)
        {
            if (lines[i] == null)
            {
                for (int j = 0; j < maxLineLength; j++)
                {
                    mapMatrix[i, j] = default(char);
                }
            }
            else
            {
                for (int j = 0; j < lines[i]!.Length; j++)
                {
                    mapMatrix[i, j] = lines[i]![j];
                }
            }
        }

        return mapMatrix;
    }

    /// <summary>
    /// Нарисовать карту в консоли
    /// </summary>
    public void DrawMap()
    {
        for (int i = 0; i < mapMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < mapMatrix.GetLength(1); j++)
            {
                Console.Write(mapMatrix[i, j]);
            }
            Console.WriteLine();
        }
        Console.CursorVisible = false;
    }

    /// <summary>
    /// Получить начальную позицию главного персонажа
    /// </summary>
    private (int, int) GetMainCharacterStartCoordinates()
    {
        bool mainCharacterDetectedInMap = false;
        var mainCharacterStartCoordinates = (0, 0);

        for (int row = 0; row < mapMatrix.GetLength(0); row++)
        {
            for (int column = 0; column < mapMatrix.GetLength(1); column++)
            {
                if (mapMatrix[row, column] == '@')
                {
                    if (!mainCharacterDetectedInMap)
                    {
                        mainCharacterDetectedInMap = true;
                        mainCharacterStartCoordinates = (column, row);
                    }
                    else
                    {
                        throw new InvalidDataException("На карте несколько главных персонажей");
                    }
                }
            }
        }

        if (!mainCharacterDetectedInMap)
        {
            throw new InvalidDataException("На карте нет главного персонажа");
        }

        return mainCharacterStartCoordinates;
    }

    /// <summary>
    /// Направления перемещения главного персонажа
    /// </summary>
    public enum Direction
    {
        Left,
        Right,
        Up,
        Down
    }

    /// <summary>
    /// Проверить, можно ли двигаться в данном направлении
    /// </summary>
    public bool CanMoveInThisDirection(Direction direction)
    {
        switch (direction)
        {
            case Direction.Left:
                return mainCharacterCoordinates.Item1 > 0 &&
                    symbolsWithoutCollider.Contains(mapMatrix[mainCharacterCoordinates.Item2, mainCharacterCoordinates.Item1 - 1]);
            case Direction.Right:
                return mainCharacterCoordinates.Item1 < mapMatrix.GetLength(1) - 1 &&
                    symbolsWithoutCollider.Contains(mapMatrix[mainCharacterCoordinates.Item2, mainCharacterCoordinates.Item1 + 1]);
            case Direction.Up:
                return mainCharacterCoordinates.Item2 > 0 &&
                    symbolsWithoutCollider.Contains(mapMatrix[mainCharacterCoordinates.Item2 - 1, mainCharacterCoordinates.Item1]);
            case Direction.Down:
                return mainCharacterCoordinates.Item2 < mapMatrix.GetLength(0) - 1 &&
                    symbolsWithoutCollider.Contains(mapMatrix[mainCharacterCoordinates.Item2 + 1, mainCharacterCoordinates.Item1]);
            default:
                return false;
        }
    }

    /// <summary>
    /// Перерисовать главного персонажа и поменять его координаты
    /// </summary>
    public void MoveMainCharacter(Direction direction)
    {
        if (!TestRun)
        {
            Console.SetCursorPosition(mainCharacterCoordinates.Item1, mainCharacterCoordinates.Item2);
            Console.Write(" ");
        }

        switch (direction)
        {
            case Direction.Left:
                mainCharacterCoordinates = (mainCharacterCoordinates.Item1 - 1, mainCharacterCoordinates.Item2);
                break;
            case Direction.Right:
                mainCharacterCoordinates = (mainCharacterCoordinates.Item1 + 1, mainCharacterCoordinates.Item2);
                break;
            case Direction.Up:
                mainCharacterCoordinates = (mainCharacterCoordinates.Item1, mainCharacterCoordinates.Item2 - 1);
                break;
            case Direction.Down:
                mainCharacterCoordinates = (mainCharacterCoordinates.Item1, mainCharacterCoordinates.Item2 + 1);
                break;
        }

        if (!TestRun)
        {
            Console.SetCursorPosition(mainCharacterCoordinates.Item1, mainCharacterCoordinates.Item2);
            Console.Write("@");

            Console.SetCursorPosition(mainCharacterCoordinates.Item1, mainCharacterCoordinates.Item2);
        }
    }

    /// <summary>
    /// Сдвинуть главного персонажа влево
    /// </summary>
    public void OnLeft(object sender, EventArgs args)
    {
        if (CanMoveInThisDirection(Direction.Left))
        {
            MoveMainCharacter(Direction.Left);
        }
    }

    /// <summary>
    /// Сдвинуть главного персонажа вправо
    /// </summary>
    public void OnRight(object sender, EventArgs args)
    {
        if (CanMoveInThisDirection(Direction.Right))
        {
            MoveMainCharacter(Direction.Right);
        }
    }

    /// <summary>
    /// Сдвинуть главного персонажа наверх
    /// </summary>
    public void OnUp(object sender, EventArgs args)
    {
        if (CanMoveInThisDirection(Direction.Up))
        {
            MoveMainCharacter(Direction.Up);
        }
    }

    /// <summary>
    /// Сдвинуть главного персонажа вниз
    /// </summary>
    public void OnDown(object sender, EventArgs args)
    {
        if (CanMoveInThisDirection(Direction.Down))
        {
            MoveMainCharacter(Direction.Down);
        }
    }
}