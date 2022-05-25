namespace LZW;

using System.Collections;
using System.IO;

/// <summary>
/// Реализация алгоритма LZW для сжатия и разжатия файлов
/// </summary>
public static class LZW
{
    /// <summary>
    /// Создать сжатый файл из исходного
    /// </summary>
    public static void Compress(string fileName)
    {
        int currentBitSize = 9;
        var trie = new Trie(-1);

        for (int i = 0; i < 256; i++)
        {
            trie.AddSymbol((char)i);
        }

        byte[] bytesArray = File.ReadAllBytes(fileName);
        int bytesArrayIndex = 0;

        var compressedFileName = new FileInfo(fileName + ".zipped");
        var compressedFile = compressedFileName.Create();

        var buffer = new BitArray(64);
        int  bufferIndex = 0;

        while (bytesArrayIndex < bytesArray.Length)
        {
            (bool isInTrie, int sequenceNumber) = (true, -1);
            int previousSequenceNumber = -1;
            while (isInTrie && bytesArrayIndex < bytesArray.Length)
            {
                previousSequenceNumber = sequenceNumber;
                (isInTrie, sequenceNumber) = trie.AddSymbol((char)bytesArray[bytesArrayIndex]);
                bytesArrayIndex++;
            }

            bytesArrayIndex -= isInTrie && bytesArrayIndex == bytesArray.Length ? 0 : 1;
            if (isInTrie && bytesArrayIndex == bytesArray.Length)
            {
                previousSequenceNumber = sequenceNumber;
            }

            int notNullsCount = 0;
            while (previousSequenceNumber > 0)
            {
                int bit = previousSequenceNumber % 2;
                buffer[bufferIndex] = (bit == 0) ? false : true;
                previousSequenceNumber /= 2;
                bufferIndex++;
                notNullsCount++;
            }

            for (int i = 0; i < currentBitSize - notNullsCount; i++)
            {
                buffer[bufferIndex] = false;
                bufferIndex++;
            }

            if (bytesArrayIndex == bytesArray.Length)
            {
                while (bufferIndex % 8 != 0)
                {
                    buffer[bufferIndex] = false;
                    bufferIndex++;
                }
            }

            while (bufferIndex >= 8)
            {
                byte newByte = 0;
                var multiplier = 1;
                for (int i = 0; i < 8; i++)
                {
                    newByte += (byte)((buffer[i] ? 1 : 0) * multiplier);
                    multiplier *= 2;
                    buffer[i] = false;
                }

                bufferIndex -= 8;
                buffer.RightShift(8);
                compressedFile.WriteByte(newByte);
            }

            if (sequenceNumber == Math.Pow(2, currentBitSize))
            {
                currentBitSize++;
            }
        }

        compressedFile.Close();
    }

    /// <summary>
    /// Разжать ".zipped" файл
    /// </summary>
    /// <returns>true, если сжатый файл корректен</returns>
    public static bool Decompress(string fileName)
    {
        int currentByteSize = 9;

        byte[] bytesArray = File.ReadAllBytes(fileName);
        var dictionary = new Dictionary<int, string>();
        for (int i = 0; i < 256; i++)
        {
            dictionary.Add(i, char.ToString((char)i));
        }

        var decompressedFileName = new FileInfo(fileName.Remove(fileName.Length - 7));
        var decompressedFile = decompressedFileName.Create();

        var bits = new BitArray(bytesArray);
        var bitsIndex = 0;

        string? previousValue = null;
        int currentNumber = 256;
        while (bitsIndex < bits.Length)
        {
            int multiplier = 1;
            int codeNumber = 0;
            for (int i = 0; i < currentByteSize; i++)
            {
                codeNumber += multiplier * (bits[bitsIndex] ? 1 : 0);
                multiplier *= 2;
                bitsIndex++;

                if (bitsIndex >= bits.Length)
                {
                    decompressedFile.Close();
                    return codeNumber == 0;
                }
            }

            var dictionaryValue = dictionary.ContainsKey(codeNumber) ? dictionary[codeNumber]
                : previousValue + previousValue![0];
            for (int i = 0; i < dictionaryValue.Length; i++)
            {
                decompressedFile.WriteByte((byte)dictionaryValue[i]);
            }

            if (previousValue != null)
            {
                dictionary.Add(currentNumber, previousValue + dictionaryValue[0]);
                currentNumber++;

                if (currentNumber == Math.Pow(2, currentByteSize))
                {
                    currentByteSize++;
                }
            }

            previousValue = dictionaryValue;
        }

        decompressedFile.Close();
        return true;
    }
}