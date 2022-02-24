using System;

// Прямое и обратное преобразования Барроуза-Уилера
public static class BWT
{
    private static string LeftShift(string line, int count)
        => line.Substring(count) + line.Substring(0, count);

    public static (string, int) DirectBWT(string line)
    {
        var cyclicShifts = new string[line.Length];
        for (var i = 0; i < line.Length; i++)
        {
            cyclicShifts[i] = line;
            line = LeftShift(line, 1);
        }
        Array.Sort(cyclicShifts);

        string result = "";
        int endPosition = 0;
        for (var i = 0; i < line.Length; i++)
        {
            result += cyclicShifts[i][cyclicShifts[i].Length - 1];
            if (line == cyclicShifts[i])
            {
                endPosition = i;
            }
        }

        return (result, endPosition);
    }

    public static string InverseBWT(string line, int endPosition)
    {
        string[] table = new string[line.Length];
        for (var i = 0; i < line.Length; i++)
        {
            for (var j = 0; j < line.Length; j++)
            {
                table[j] = line[j] + table[j];
            }
            Array.Sort(table);
        }
        return table[endPosition];
    }

    private static bool Checking(string line)
    {
        (string transformedLine, int endPosition) = DirectBWT(line);
        string inversedTransformedLine = InverseBWT(transformedLine, endPosition);
        return String.Compare(inversedTransformedLine, line) == 0;
    }

    public static void Main(string[] args)
    {
        if (Checking("ABACABA"))
        {
            Console.WriteLine("Прямое и обратное преобразования BWT работают корректно");
        }
        else
        {
            Console.WriteLine("Прямое и обратное преобразования BWT работают некорректно");
        }
    }
}