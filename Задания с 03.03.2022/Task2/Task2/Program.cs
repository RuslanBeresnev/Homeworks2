namespace LZW;

internal class Program
{
    private static void Main(string[] args)
    {
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
            long compressionFactor = compressedFileInfo.Length / fileInfo.Length;

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