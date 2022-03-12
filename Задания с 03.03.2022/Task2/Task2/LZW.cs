using System;

namespace Task2;

internal static class LZW
{
    const int CodeLength = 4;

    private static string AddLeadingZeros(int number, int newNumberLength)
    {
        string newNumber = "";
        for (int i = 0; i < newNumberLength - number.ToString().Length; i++)
        {
            newNumber += "0";
        }
        newNumber += number.ToString();
        return newNumber;
    }

    public static void Compress(string inputFileName)
    {
        var table = new Dictionary<string, string>();
        int newRecordsCount = 0;
        for (int i = 0; i < 256; i++)
        {
            table[((char)i).ToString()] = AddLeadingZeros(i, CodeLength);
        }

        byte[] inputData = File.ReadAllBytes(inputFileName);

        string[] splittedFileName = inputFileName.Split('.');
        string newFileName = "";
        for (int i = 0; i < splittedFileName.Length - 1; i++)
        {
            newFileName += (splittedFileName[i] + ".");
        }
        newFileName += "zipped";

        FileStream fileStream = new FileStream(newFileName, FileMode.OpenOrCreate, FileAccess.Write);
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
                table[currentPhrase + symbol] = AddLeadingZeros(255 + newRecordsCount, CodeLength);
                currentPhrase = symbol.ToString();
            }
        }
        streamWriter.Write(table[currentPhrase]);

        streamWriter.Close();
        fileStream.Close();
    }

    public static void Decompress(string inputFileName)
    {
        var table = new Dictionary<string, string>();
        int newRecordsCount = 0;
        for (int i = 0; i < 256; i++)
        {
            table[AddLeadingZeros(i, CodeLength)] = ((char)i).ToString();
        }

        string[] data = File.ReadAllLines(inputFileName);
        string fileExtension = data[0];
        string encodedData = data[1];

        int lastDotindex = inputFileName.LastIndexOf(".");
        string newFileName = inputFileName.Substring(0, lastDotindex) + fileExtension;

        FileStream fileStream = new FileStream(newFileName, FileMode.OpenOrCreate, FileAccess.Write);
        StreamWriter streamWriter = new StreamWriter(fileStream);

        string previousDecodedValue = "";
        for (int i = 0; i < encodedData.Length; i += CodeLength)
        {
            string currentCode = encodedData.Substring(i, CodeLength);
            if (table.ContainsKey(currentCode))
            {
                streamWriter.Write(table[currentCode]);
                if (previousDecodedValue != "")
                {
                    newRecordsCount++;
                    table[AddLeadingZeros(255 + newRecordsCount, CodeLength)] = previousDecodedValue + table[currentCode].Substring(0, 1);
                }
                previousDecodedValue = table[currentCode];
            }
            else
            {
                string createdValue = previousDecodedValue + previousDecodedValue.Substring(0, 1);
                streamWriter.Write(createdValue);
                newRecordsCount++;
                table[AddLeadingZeros(255 + newRecordsCount, CodeLength)] = createdValue;
                previousDecodedValue = table[currentCode];
            }
        }

        streamWriter.Close();
        fileStream.Close();
    }

    public static void Main(string[] args)
    {
        /*Compress("C:/Users/User/source/repos/Homeworks2/Задания с 03.03.2022/Task2/Task2/bin/Debug/net6.0/Task10.exe");
        Decompress("C:/Users/User/source/repos/Homeworks2/Задания с 03.03.2022/Task2/Task2/bin/Debug/net6.0/Task10.zipped");
        Compress("C:/Users/User/source/repos/Homeworks2/Задания с 03.03.2022/Task2/Task2/test.txt");
        Decompress("C:/Users/User/source/repos/Homeworks2/Задания с 03.03.2022/Task2/Task2/test.zipped");*/
    }
}