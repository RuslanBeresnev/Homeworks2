namespace LZW;

internal class Program
{
    /// <summary>
    /// Вывести коэффициент сжатия без использования/с использованием BWT
    /// </summary>
    private static void CompareResultsWithAndWithoutBWT()
    {
        var filePaths = new string[2] { "..//..//..//TextFile.txt", "..//..//..//BinaryFile.bin" };
        for (int i = 0; i < filePaths.Length; i++)
        {
            var filePath = filePaths[i];

            // Сжатие без BWT
            var fileInfo = new FileInfo(filePath);
            LZW.Compress(filePath);
            LZW.Decompress(filePath + ".zipped");
            var compressedFileInfo = new FileInfo(filePath + ".zipped");
            float compressionFactorWithoutBWT = compressedFileInfo.Length / (float)fileInfo.Length;

            // Сжатие с BWT
            fileInfo = new FileInfo(filePath);
            var endPosition = BWT.DirectBWTInFile(filePath);
            LZW.Compress(filePath);
            LZW.Decompress(filePath + ".zipped");
            BWT.InverseBWTInFile(filePath, endPosition);
            compressedFileInfo = new FileInfo(filePath + ".zipped");
            float compressionFactorWithBWT = compressedFileInfo.Length / (float)fileInfo.Length;

            Console.WriteLine($"Сжатый файл типа {filePath.Split(".")[1]} составляет {compressionFactorWithoutBWT * 100}% от исходного" +
                $"без использования BWT и {compressionFactorWithBWT * 100}% с использованием BWT");
        }
    }

    private static void Main(string[] args)
    {
        if (args.Length == 1 && args[0] == "-t")
        {
            CompareResultsWithAndWithoutBWT();
            return;
        }

        if (args.Length != 2 || !File.Exists(args[0]) || (args[1] != "-c" && args[1] != "-u"))
        {
            Console.WriteLine("Ввод некорректен ...");
            return;
        }

        if (args[1] == "-c")
        {
            LZW.Compress(args[0]);

            var fileInfo = new FileInfo(args[0]);
            var compressedFileInfo = new FileInfo(args[0] + ".zipped");
            float compressionFactor = compressedFileInfo.Length / (float)fileInfo.Length;

            Console.WriteLine("Сжатый файл с расширением .zipped создан");
            Console.WriteLine($"Объём сжатого файла составляет {compressionFactor * 100}% от объёма исходного");
        }
        else if (args[1] == "u")
        {
            var isDecompressCorrect = LZW.Decompress(args[0]);
            if (!isDecompressCorrect)
            {
                Console.WriteLine("Сжатый файл оказался некорректным ...");
                return;
            }
            Console.WriteLine("Разжатый файл создан");
        }
    }
}