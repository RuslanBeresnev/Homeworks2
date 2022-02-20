using System;

public class BWT
{
    private static string leftShift(string line, int count)
    {
        return line.Substring(count) + line.Substring(0, count);
    }

    public static string Direct(string line, ref int endPosition)
    {
        string[] cyclicShifts = new string[line.Length];
        for (var i = 0; i < line.Length; i++)
        {
            cyclicShifts[i] = line;
            line = leftShift(line, 1);
        }
        Array.Sort(cyclicShifts);

        string result = "";
        for (var i = 0; i < line.Length; i++)
        {
            result += cyclicShifts[i][cyclicShifts[i].Length - 1];
            if (String.Compare(line, cyclicShifts[i]) == 0)
            {
                endPosition = i;
            }
        }

        return result;
    }

    public static string Inverse(string line, int endPosition)
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
        int endPosition = 0;
        string transformedLine = Direct(line, ref endPosition);
        string inversedTransformedLine = Inverse(transformedLine, endPosition);
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