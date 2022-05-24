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
        int currentByteSize = 9;

        byte[] bytesArray = File.ReadAllBytes(fileName);
        var trie = new Trie(-1);

        for (var i = 0; i < 256; i++)
        {
            trie.AddSymbol((char)i);
            trie.ReturnPointerToRoot();
        }

        var compressedFileName = new FileInfo(fileName + ".zipped");
        var compressedFile = compressedFileName.Create();

        var buffer = new BitArray(64);
        var bufferIndex = 0;

        var bytesArrayIndex = 0;

        while (bytesArrayIndex < bytesArray.Length)
        {
            bool newSequenceAdded = trie.AddSymbol((char)bytesArray[bytesArrayIndex]);
            int previousSequenceNumber = 0;

            while (!newSequenceAdded)
            {
                previousSequenceNumber = trie.GetCurrentNodeNumber();
                bytesArrayIndex++;
                newSequenceAdded = trie.AddSymbol((char)bytesArray[bytesArrayIndex]);

                if (bytesArrayIndex == bytesArray.Length - 1)
                {
                    break;
                }
            }

            if (bytesArrayIndex == bytesArray.Length - 1)
            {
                if (newSequenceAdded)
                {
                    AddByteToBuffer(buffer, previousSequenceNumber, currentByteSize, ref bufferIndex);
                    AddByteToBuffer(buffer, bytesArray[bytesArrayIndex], currentByteSize, ref bufferIndex);
                }
                else
                {
                    AddByteToBuffer(buffer, trie.GetCurrentNodeNumber(), currentByteSize, ref bufferIndex);
                }
            }
            else
            {
                AddByteToBuffer(buffer, previousSequenceNumber, currentByteSize, ref bufferIndex);
            }

            if (bytesArrayIndex == bytesArray.Length - 1)
            {
                PadBufferWithZerosToMultipleOfEight(buffer, ref bufferIndex);
            }

            SplitBufferIntoBytesAndWriteToFile(buffer, ref bufferIndex, compressedFile);

            if (trie.GetCurrentNodeNumber() == Math.Pow(2, currentByteSize))
            {
                currentByteSize++;
            }
        }
    }

    /// <summary>
    /// Разжать ".zipped" файл
    /// </summary>
    public static void Decompress(string fileName)
    {
        // pass
    }

    /// <summary>
    /// Создать по номеру байт и добавить его в битовый буфер
    /// </summary>
    private static void AddByteToBuffer(BitArray buffer, int byteNumber, int currentByteSize, ref int currentBufferIndex)
    {
        int notNullasCount = 0;
        while (byteNumber > 0)
        {
            int bit = byteNumber % 2;
            buffer[currentBufferIndex] = (bit == 0) ? false : true;
            byteNumber /= 2;
            currentBufferIndex++;
            notNullasCount++;
        }

        for (int i = 0; i < currentByteSize - notNullasCount; i++)
        {
            buffer[currentBufferIndex] = false;
            currentBufferIndex++;
        }
    }

    /// <summary>
    /// Дополнить буфер нулями до числа, кратного 8
    /// </summary>
    private static void PadBufferWithZerosToMultipleOfEight(BitArray buffer, ref int currentBufferIndex)
    {
        while (currentBufferIndex % 8 != 0)
        {
            buffer[currentBufferIndex] = false;
            currentBufferIndex++;
        }
    }

    /// <summary>
    /// Разбить буфер на байты и записать каждый байт в сжатый файл
    /// </summary>
    private static void SplitBufferIntoBytesAndWriteToFile(BitArray buffer, ref int currentBufferIndex, FileStream compressedFile)
    {
        while (currentBufferIndex >= 8)
        {
            byte newByte = 0;
            var multiplier = 1;

            for (int i = 0; i < 8; i++)
            {
                newByte += (byte)((buffer[i] ? 1 : 0) * multiplier);
                multiplier *= 2;
                buffer[i] = false;
            }

            currentBufferIndex -= 8;
            buffer.RightShift(8);
            compressedFile.WriteByte(newByte);
        }
    }
}