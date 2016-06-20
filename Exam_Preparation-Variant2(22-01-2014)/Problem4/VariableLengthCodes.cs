using System;
using System.Collections.Generic;
using System.Text;

internal class VariableLengthCodes
{
    private static int[] encodedSymbolsAsInt;
    private static string[] encodedSymbolsAsStr;

    private static void Main()
    {
        // input
        GetEncodedText();
        int numOfLines = int.Parse(Console.ReadLine());
        string[] codeTable = GetCodeTable(numOfLines);

        ConvertInputToBytes();
        string encodedTextBits = string.Join(string.Empty, encodedSymbolsAsStr);

        // parse the code table
        var codeTableParsed = ParseCodeTable(codeTable);

        // decode
        string decodedText = Decode(encodedTextBits, codeTableParsed);

        Console.WriteLine(decodedText);
    }

    private static string Decode(string bitsSeq, Dictionary<int, string> codeTable)
    {
        StringBuilder decodedText = new StringBuilder();

        int count = 0;
        for (int i = 0; i < bitsSeq.Length; i++)
        {
            if (bitsSeq[i] == '1')
            {
                count++;
            }
            else if (bitsSeq[i] == '0' && count == 0)
            {
                break;
            }
            else
            {
                decodedText.Append(codeTable[count]);
                count = 0;
            }
        }

        return decodedText.ToString();
    }

    private static void ConvertInputToBytes()
    {
        // get numbers as bits sequences
        for (int i = 0; i < encodedSymbolsAsInt.Length; i++)
        {
            encodedSymbolsAsStr[i] = Convert.ToString(encodedSymbolsAsInt[i], 2);
            if (encodedSymbolsAsStr[i].Length < 8)
            {
                encodedSymbolsAsStr[i] = encodedSymbolsAsStr[i].Insert(0, "0");
            }
        }
    }

    private static string[] GetCodeTable(int numOfLines)
    {
        string[] codeTable = new string[numOfLines];
        for (int i = 0; i < numOfLines; i++)
        {
            codeTable[i] = Console.ReadLine();
        }

        return codeTable;
    }

    private static void GetEncodedText()
    {
        encodedSymbolsAsStr = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        encodedSymbolsAsInt = new int[encodedSymbolsAsStr.Length];
        for (int i = 0; i < encodedSymbolsAsStr.Length; i++)
        {
            encodedSymbolsAsInt[i] = int.Parse(encodedSymbolsAsStr[i]);
        }
    }

    private static Dictionary<int, string> ParseCodeTable(string[] codeTable)
    {
        var codeTableParsed = new Dictionary<int, string>();

        for (int i = 0; i < codeTable.Length; i++)
        {
            int index = int.Parse(codeTable[i].Substring(1));
            string symbol = codeTable[i].Substring(0, 1);

            codeTableParsed[index] = symbol;
        }

        return codeTableParsed;
    }
}