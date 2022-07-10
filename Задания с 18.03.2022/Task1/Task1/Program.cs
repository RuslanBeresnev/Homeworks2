namespace Routers;

using System.IO;

public class Program
{
    static int Main(string[] args)
    {
        Console.WriteLine("Построение оптимальной конфигурации роутеров");

        Console.WriteLine("Введите путь к входному файлу:");
        string? inputFilePath = Console.ReadLine();
        if (!File.Exists(inputFilePath))
        {
            Console.WriteLine("Вы не ввели путь к входному файлу или ввели его некорректно ...");
            return -1;
        }

        Console.WriteLine("Введите путь к выходному файлу:");
        string? outputFilePath = Console.ReadLine();
        if (!File.Exists(outputFilePath))
        {
            Console.WriteLine("Вы не ввели путь к выходному файлу или ввели его некорректно ...");
            return -1;
        }

        var initialGraph = MakeGraphByFile(inputFilePath);
        if (initialGraph.Count == 0)
        {
            Console.WriteLine("Входной файл пуст ...");
            return -1;
        }

        var resultGraph = Graph.GetMaximalSpanningTree(initialGraph);
        if (resultGraph == null)
        {
            Console.Error.WriteLine("Граф не является связным ...");
            return -1;
        }

        WriteGraphToFile(outputFilePath, resultGraph);
        Console.WriteLine("Оптимальная конфигурация роутеров построена");
        return 0;
    }

    /// <summary>
    /// Создать граф по информации из текстового файла
    /// </summary>
    public static Graph MakeGraphByFile(string fileName)
    {
        StreamReader reader = new StreamReader(fileName);
        string? line = reader.ReadLine();

        var networkGraph = new Graph();

        while (line != null)
        {
            int nodeNumber = int.Parse(line.Split(":")[0]);
            var currentNode = networkGraph.GetNodeByNumber(nodeNumber);
            if (currentNode == null)
            {
                currentNode = new Node(nodeNumber);
                networkGraph.AddNode(currentNode);
            }

            if (line.Split(":")[1] == "" || line.Split(":")[1] == " ")
            {
                line = reader.ReadLine();
                continue;
            }

            string[] data = line.Split(": ")[1].Split(", ");
            foreach (var adjacentNodeData in data)
            {
                int adjacentNodeNumber = int.Parse(adjacentNodeData.Split(" ")[0]);
                int distance = int.Parse(adjacentNodeData.Split(" ")[1].Split("(")[1].Split(")")[0]);

                var adjacentNode = networkGraph.GetNodeByNumber(adjacentNodeNumber);
                if (adjacentNode == null)
                {
                    adjacentNode = new Node(adjacentNodeNumber);
                    networkGraph.AddNode(adjacentNode);
                }

                currentNode.AddAdjacentNode(adjacentNode, distance);
            }
            line = reader.ReadLine();
        }

        reader.Close();
        return networkGraph;
    }

    /// <summary>
    /// Записать информацию о графе в текстовый файл
    /// </summary>
    public static void WriteGraphToFile(string fileName, Graph networkGraph)
    {
        StreamWriter writer = new StreamWriter(fileName);
        
        for (int i = 0; i < networkGraph.Count; i++)
        {
            string lineToWrite = "";
            var currentNode = networkGraph.Nodes[i];
            int adjacentNodeCounter = 1;

            if (currentNode.AdjacentNodes.Count == 0)
            {
                continue;
            }

            lineToWrite += currentNode.Number.ToString();
            lineToWrite += ": ";
            foreach (var adjacentNodeData in currentNode.AdjacentNodes)
            {
                int adjacentNodeNumber = adjacentNodeData.Key.Number;
                int distance = adjacentNodeData.Value;
                lineToWrite += adjacentNodeNumber.ToString();
                lineToWrite += " (";
                lineToWrite += distance.ToString();
                lineToWrite += ")";

                if (adjacentNodeCounter < currentNode.AdjacentNodes.Count)
                {
                    lineToWrite += ", ";
                }

                adjacentNodeCounter++;
            }

            writer.WriteLine(lineToWrite);
        }

        writer.Close();
    }
}