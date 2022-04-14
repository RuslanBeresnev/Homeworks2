namespace ControlWork;

using System.Collections.Generic;

/// <summary>
/// Класс, реализующий операции с разреженный вектор и операции над ним
/// </summary>
public class SparseVector
{
    private Dictionary<int, int> vector;
    private int length;
    private int notEmptyCoordinatesCount;

    /// <summary>
    /// Создание разреженного вектора с помощью словаря координат
    /// </summary>
    /// <param name="dictionaryWithNotEmptyCoordinates">Ключ в словаре: индекс координаты; Значение в словаре: значение координаты</param>
    public SparseVector(Dictionary<int, int> dictionaryWithNotEmptyCoordinates, int length)
    {
        vector = dictionaryWithNotEmptyCoordinates;
        notEmptyCoordinatesCount = dictionaryWithNotEmptyCoordinates.Count;
        this.length = length;
    }

    /// <summary>
    /// Создание разреженного вектора с помощью массива
    /// </summary>
    /// <param name="coordinatesArray">Массив координат, идущих подряд (начиная с самой первой)</param>
    public SparseVector(int[] coordinatesArray)
    {
        vector = new Dictionary<int, int>();
        int currentIndex = 0;

        foreach (var value in coordinatesArray)
        {
            vector.Add(currentIndex, value);
            currentIndex++;
        }
        notEmptyCoordinatesCount = coordinatesArray.Length;
        length = coordinatesArray.Length;
    }

    /// <summary>
    /// Узнать длину полную вектора
    /// </summary>
    public int Length
    {
        get { return length; }
    }

    /// <summary>
    /// Узнать количество неулевых координат в разреженном векторе
    /// </summary>
    public int Count
    {
        get { return notEmptyCoordinatesCount; }
    }

    /// <summary>
    /// Получить словарь координат разреженного вектора
    /// </summary>
    public Dictionary<int, int> Coordinates
    {
        get { return vector; }
    }

    private static SparseVector GetVectorCopy(SparseVector vector)
    {
        var coordinatesCopy = new Dictionary<int, int>();
        foreach (var coordinate in vector.Coordinates)
        {
            coordinatesCopy.Add(coordinate.Key, coordinate.Value);
        }
        return new SparseVector(coordinatesCopy, vector.Length);
    }

    /// <summary>
    /// По-координатное сложение векторов
    /// </summary>
    public static SparseVector VectorAddition(SparseVector firstVector, SparseVector secondVector)
    {
        if (firstVector.Length != secondVector.Length)
        {
            throw new InvalidOperationException("Векторы имеют разную длину");
        }

        var twoVectors = new SparseVector[2] { firstVector, secondVector };
        var resultCoordinates = new Dictionary<int, int>();

        for (int i = 0; i < 2; i++)
        {
            foreach (var coordinate in twoVectors[i].Coordinates)
            {
                if (resultCoordinates.ContainsKey(coordinate.Key))
                {
                    resultCoordinates[coordinate.Key] += coordinate.Value;
                }
                else
                {
                    resultCoordinates.Add(coordinate.Key, coordinate.Value);
                }
            }
        }

        var resultVector = new SparseVector(resultCoordinates, firstVector.Length);
        return resultVector;
    }

    /// <summary>
    /// По-координатное вычитание из первого вектора второго
    /// </summary>
    public static SparseVector VectorSubtraction(SparseVector firstVector, SparseVector secondVector)
    {
        if (firstVector.Length != secondVector.Length)
        {
            throw new InvalidOperationException("Векторы имеют разную длину");
        }

        var resultCoordinates = GetVectorCopy(firstVector).Coordinates;
        foreach (var coordinate in secondVector.Coordinates)
        {
            if (resultCoordinates.ContainsKey(coordinate.Key))
            {
                resultCoordinates[coordinate.Key] -= coordinate.Value;
            }
            else
            {
                resultCoordinates.Add(coordinate.Key, -coordinate.Value);
            }
        }

        var resultVector = new SparseVector(resultCoordinates, firstVector.Length);
        return resultVector;
    }

    /// <summary>
    /// Скалярное умножение векторов
    /// </summary>
    public static int ScalarMultiplication(SparseVector firstVector, SparseVector secondVector)
    {
        if (firstVector.Length != secondVector.Length)
        {
            throw new InvalidOperationException("Векторы имеют разную длину");
        }

        int resultSum = 0;
        foreach (var coordinate in firstVector.Coordinates)
        {
            if (secondVector.Coordinates.ContainsKey(coordinate.Key))
            {
                resultSum += coordinate.Value * secondVector.Coordinates[coordinate.Key];
            }
        }

        return resultSum;
    }

    /// <summary>
    /// Проверка на нулевой вектор
    /// </summary>
    public static bool IsZeroVector(SparseVector vector)
    {
        return vector.Count == 0;
    }
}