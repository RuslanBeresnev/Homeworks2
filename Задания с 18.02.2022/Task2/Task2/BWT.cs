/// <summary>
/// Класс, реализующий прямое и обратное преобразования Барроуза-Уилера
/// </summary>
public static class BWT
{
    /// <summary>
    /// Прямое преобразование
    /// </summary>
    public static (string, int) DirectBWT(string line)
    {
        // Сортированный список с индексами последних символов в каждой циклически сдвинутой строке
        var sortedLastSymbolsOfStringsIndexes = new List<int>();
        var currentLine = line;
        var currentLineLastSymbolIndex = currentLine.Length - 1;

        for (int i = 0; i < line.Length; i++)
        {
            if (i == 0)
            {
                sortedLastSymbolsOfStringsIndexes.Add(currentLineLastSymbolIndex);
            }
            else
            {
                int sortedListIndex = 0;
                while (true)
                {
                    int currentLineInIndexesListStartIndex = (sortedLastSymbolsOfStringsIndexes[sortedListIndex] + 1) % currentLine.Length;
                    string currentLineInIndexesList = line.Substring(currentLineInIndexesListStartIndex) +
                        line.Substring(0, currentLineInIndexesListStartIndex);
                    if (currentLine.CompareTo(currentLineInIndexesList) < 0)
                    {
                        break;
                    }
                    sortedListIndex++;
                    if (sortedListIndex == sortedLastSymbolsOfStringsIndexes.Count)
                    {
                        break;
                    }
                }
                sortedLastSymbolsOfStringsIndexes.Insert(sortedListIndex, currentLineLastSymbolIndex);
            }

            currentLine = currentLine.Substring(1) + currentLine.Substring(0, 1);
            currentLineLastSymbolIndex = (currentLineLastSymbolIndex + 1) % currentLine.Length;
        }

        string result = "";
        int lastSymbolPosition = 0;
        for (int i = 0; i < sortedLastSymbolsOfStringsIndexes.Count; i++)
        {
            if (sortedLastSymbolsOfStringsIndexes[i] == sortedLastSymbolsOfStringsIndexes.Count - 1)
            {
                lastSymbolPosition = i;
            }
            result += line[sortedLastSymbolsOfStringsIndexes[i]];
        }

        return (result, lastSymbolPosition);
    }

    /// <summary>
    /// Отсортировать строку в лексикографическом порядке
    /// </summary>
    private static string SortString(string input)
    {
        char[] characters = input.ToArray();
        Array.Sort(characters);
        return new string(characters);
    }

    /// <summary>
    /// Обратное преобразование
    /// </summary>
    public static string InverseBWT(string line, int endPosition)
    {
        // Строка для поиска первого вхождения символа, а затем замены этого символа на '-'
        var lineCopy = line;
        var sortedLine = SortString(line);

        // Словарь, в котором ключ - позиция символа в сортированной строке, а значение - числовой массив
        // из двух элементов, где первый - код символа в кодировке, второй - "индекс" пары (ключ, значение) в словаре.
        // Индекс в смысле "первое вхождение символа из пары в строку"
        var permutationDictionary = new Dictionary<int, int[]>();
        
        for (int i = 0; i < sortedLine.Length; i++)
        {
            var currentSymbol = sortedLine[i];
            var currentSymbolFirstOccurrenceIndex = lineCopy.IndexOf(currentSymbol);

            lineCopy = lineCopy.Substring(0, currentSymbolFirstOccurrenceIndex) + '-' +
                lineCopy.Substring(currentSymbolFirstOccurrenceIndex + 1);

            permutationDictionary.Add(i, new int[2] { (int)currentSymbol, currentSymbolFirstOccurrenceIndex });
        }

        var result = "";
        var currentIndex = endPosition;
        for (int i = 0; i < line.Length; i++)
        {
            var valuesArray = permutationDictionary[currentIndex];
            result += (char)valuesArray[0];
            currentIndex = valuesArray[1];
        }

        return result;
    }

    /// <summary>
    /// Проверка корректности алгоритма
    /// </summary>
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