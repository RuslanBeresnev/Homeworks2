namespace ParseTree;

internal class Program
{
    private static string ReadSequenceFromFile(string fileName)
    {
        var streamReader = new StreamReader(fileName);
        string sequence = streamReader.ReadToEnd();
        streamReader.Close();
        return sequence;
    }

    static void Main(string[] args)
    {
        string sequence = ReadSequenceFromFile("C:/Users/User/source/repos/Homeworks2/Задания с 10.03.2022/Task1/Task1/Parse Expression.txt");
        var parseTree = new ParseTree(sequence);
        INode? root = parseTree.Parse();
        if (root == null)
        {
            throw new ArgumentNullException("Пустой файл");
        }
        Console.WriteLine($"Вычисленное значение: {parseTree.Calculate(root)}");
        Console.Write($"Напечатанное дерево: ");
        parseTree.Print(root);
    }
}