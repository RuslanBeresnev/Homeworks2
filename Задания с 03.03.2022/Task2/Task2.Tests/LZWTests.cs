namespace LZWTests;

using NUnit.Framework;
using LZW;
using System.IO;

public class LZWTests
{
    [TestCase("..//..//..//TextFile.txt", "..//..//..//TextFileBase.txt")]
    [TestCase("..//..//..//BinaryFile.bin", "..//..//..//BinaryFileBase.bin")]
    [TestCase("..//..//..//EmptyFile.txt", "..//..//..//EmptyFileBase.txt")]
    public void CompressAndDecompressVariousFileTypesTest(string fileToCompress, string fileToCompareWithResult)
    {
        LZW.Compress(fileToCompress);
        if (File.ReadAllBytes(fileToCompress).Length != 0 &&
            File.ReadAllBytes(fileToCompress + ".zipped").Length == File.ReadAllBytes(fileToCompress).Length)
        {
            Assert.Fail();
        }

        bool isDecompressionCorrect = LZW.Decompress(fileToCompress + ".zipped");
        var bytesOfBaseFile = File.ReadAllBytes(fileToCompareWithResult);
        var bytesOfDecompressedFile = File.ReadAllBytes(fileToCompress);

        if (!isDecompressionCorrect || bytesOfDecompressedFile.Length != bytesOfBaseFile.Length)
        {
            Assert.Fail();
        }

        for (int i = 0; i < bytesOfBaseFile.Length; i++)
        {
            if (bytesOfBaseFile[i] != bytesOfDecompressedFile[i])
            {
                Assert.Fail();
            }
        }

        Assert.Pass();
    }
}