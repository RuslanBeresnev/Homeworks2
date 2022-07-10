static string ReadSequenceFromFile(string fileName)
{
    var streamReader = new StreamReader(fileName);
    string sequence = streamReader.ReadToEnd();
    streamReader.Close();
    return sequence;
}

string sequence = ReadSequenceFromFile("C:/Users/User/source/repos/Homeworks2/Задания с 10.03.2022/Task1/Task1/Parse Expression.txt");
var parseTree = new ParseTree.ParseTree(sequence);

var calculatedValue = 0;
try
{
    calculatedValue = parseTree.Calculate();
}
catch (InvalidOperationException)
{
    Console.WriteLine("Пустой файл или некорректная последовательность");
    return;
}
Console.WriteLine($"Вычисленное значение: {calculatedValue}");
Console.Write($"Напечатанное дерево: ");
parseTree.Print();
