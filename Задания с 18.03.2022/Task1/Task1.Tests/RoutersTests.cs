namespace RoutersTests;

using Routers;

using NUnit.Framework;
using System.IO;

public class Tests
{
    private bool FileCompare(string filePath1, string filePath2)
    {
        int file1Byte;
        int file2Byte;
        FileStream fileStream1;
        FileStream fileStream2;

        if (filePath1 == filePath2)
        {
            return true;
        }

        fileStream1 = new FileStream(filePath1, FileMode.Open);
        fileStream2 = new FileStream(filePath2, FileMode.Open);

        if (fileStream1.Length != fileStream2.Length)
        {
            fileStream1.Close();
            fileStream2.Close();

            return false;
        }

        do
        {
            file1Byte = fileStream1.ReadByte();
            file2Byte = fileStream2.ReadByte();
        }
        while ((file1Byte == file2Byte) && (file1Byte != -1));

        fileStream1.Close();
        fileStream2.Close();

        return ((file1Byte - file2Byte) == 0);
    }

    [Test]
    public void StandardConfigurationTest()
    {
        var initialGraph = Program.MakeGraphByFile("../../../Standard Test Input.txt");
        var resultGraph = Graph.GetMaximalSpanningTree(initialGraph);
        Program.WriteGraphToFile("../../../Standard Test Output.txt", resultGraph!);

        Assert.IsTrue(FileCompare("../../../Standard Test Output.txt", "../../../Standard Test Correct.txt"));
    }

    [Test]
    public void LargeConfigurationTest()
    {
        var initialGraph = Program.MakeGraphByFile("../../../Large Test Input.txt");
        var resultGraph = Graph.GetMaximalSpanningTree(initialGraph);
        Program.WriteGraphToFile("../../../Large Test Output.txt", resultGraph!);

        Assert.IsTrue(FileCompare("../../../Large Test Output.txt", "../../../Large Test Correct.txt"));
    }

    [Test]
    public void EmptyConfigurationTest()
    {
        var initialGraph = Program.MakeGraphByFile("../../../Empty File Test.txt");
        Assert.IsTrue(initialGraph.Count == 0);
    }

    [Test]
    public void NotCoherenceConfigurationTest()
    {
        var initialGraph = Program.MakeGraphByFile("../../../Not Coherence Configuration Test.txt");
        var resultGraph = Graph.GetMaximalSpanningTree(initialGraph);
        Assert.IsTrue(resultGraph == null);
    }
}