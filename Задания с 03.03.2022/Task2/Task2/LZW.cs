using System.Collections;

namespace Task2;

internal static class LZW
{
    public static void Compress(string inputFileName)
    {
        var table = new Dictionary<string, char>();
        int newRecordsCount = 0;
        for (int i = 0; i < 256; i++)
        {
            table[((char)i).ToString()] = (char)i;
        }

        byte[] inputData = File.ReadAllBytes(inputFileName);

        string[] splittedFileName = inputFileName.Split('.');
        string newFileName = "";
        for (int i = 0; i < splittedFileName.Length - 1; i++)
        {
            newFileName += (splittedFileName[i] + ".");
        }
        newFileName += "zipped";

        FileStream fileStream = new FileStream(newFileName, FileMode.Create, FileAccess.Write);
        StreamWriter streamWriter = new StreamWriter(fileStream);

        string fileExtension = "." + splittedFileName[splittedFileName.Length - 1];
        streamWriter.WriteLine(fileExtension);

        string currentPhrase = "";
        for (int i = 0; i < inputData.Length; i++)
        {
            char symbol = (char)inputData[i];

            if (table.ContainsKey(currentPhrase + symbol))
            {
                currentPhrase += symbol;
            }
            else
            {
                streamWriter.Write(table[currentPhrase]);
                newRecordsCount++;
                table[currentPhrase + symbol] = (char)(255 + newRecordsCount);
                currentPhrase = symbol.ToString();
            }

            if (newRecordsCount == 65536 - 255)
            {
                streamWriter.Write(table[currentPhrase]);
                table = new Dictionary<string, char>();
                newRecordsCount = 0;
                currentPhrase = "";
                for (int j = 0; j < 256; j++)
                {
                    table[((char)j).ToString()] = (char)j;
                }
            }
        }
        streamWriter.Write(table[currentPhrase]);

        streamWriter.Close();
        fileStream.Close();
    }

    public static void Decompress(string inputFileName)
    {
        var table = new Dictionary<char, string>();
        int newRecordsCount = 0;
        for (int i = 0; i < 256; i++)
        {
            table[(char)i] = ((char)i).ToString();
        }

        string[] data = File.ReadAllLines(inputFileName);
        string fileExtension = data[0];
        string encodedData = "";
        for (int i = 1; i < data.Length; i++)
        {
            encodedData += data[i];
            if (i != data.Length - 1)
            {
                encodedData += "\r\n";
            }
        }

        int lastDotindex = inputFileName.LastIndexOf(".");
        string newFileName = inputFileName.Substring(0, lastDotindex) + fileExtension;

        FileStream fileStream = new FileStream(newFileName, FileMode.Create, FileAccess.Write);
        StreamWriter streamWriter = new StreamWriter(fileStream);

        string previousDecodedValue = "";
        for (int i = 0; i < encodedData.Length; i++)
        {
            char currentCode = encodedData[i];
            if (table.ContainsKey(currentCode))
            {
                streamWriter.Write(table[currentCode]);
                if (previousDecodedValue != "")
                {
                    newRecordsCount++;
                    table[(char)(255 + newRecordsCount)] = previousDecodedValue + table[currentCode].Substring(0, 1);
                }
                previousDecodedValue = table[currentCode];
            }
            else
            {
                string createdValue = previousDecodedValue + previousDecodedValue.Substring(0, 1);
                streamWriter.Write(createdValue);
                newRecordsCount++;
                table[(char)(255 + newRecordsCount)] = createdValue;
                previousDecodedValue = table[currentCode];
            }

            if (newRecordsCount == 65536)
            {
                table = new Dictionary<char, string>();
                newRecordsCount = 0;
                previousDecodedValue = "";
                for (int j = 0; j < 256; j++)
                {
                    table[(char)i] = ((char)i).ToString();
                }
            }
        }

        streamWriter.Close();
        fileStream.Close();
    }

    public static void Main(string[] args)
    {
        /*  Compress("C:/Users/User/source/repos/Homeworks2/Задания с 03.03.2022/Task2/Task2/bin/Debug/net6.0/Task10.exe");
          Decompress("C:/Users/User/source/repos/Homeworks2/Задания с 03.03.2022/Task2/Task2/bin/Debug/net6.0/Task10.zipped");*/
/*        Compress("C:/Users/User/source/repos/Homeworks2/Задания с 03.03.2022/Task2/Task2/test.txt");
        Decompress("C:/Users/User/source/repos/Homeworks2/Задания с 03.03.2022/Task2/Task2/test.zipped");*/
    }
}