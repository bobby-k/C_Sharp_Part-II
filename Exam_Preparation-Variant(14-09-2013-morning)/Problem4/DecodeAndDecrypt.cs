using System;
using System.Text;

internal class DecodeAndDecrypt
{
    private static void Main()
    {
        string cypheredTextCompressed = Console.ReadLine();
        int cypherLength = GetCypherLength(cypheredTextCompressed);
        string cypheredTextDecompressed = Decompress(cypheredTextCompressed, cypherLength);
        string encryptedMessage = cypheredTextDecompressed.Substring(0, cypheredTextDecompressed.Length - cypherLength);
        string cypher = cypheredTextDecompressed.Substring(cypheredTextDecompressed.Length - cypherLength);

        string decryptedMessage = Decrypt(encryptedMessage, cypher);
        Console.WriteLine(decryptedMessage);
    }

    private static string Decrypt(string encryptedMessage, string cypher)
    {
        // find longer of message and cypher
        string longerString = GetLonger(encryptedMessage, cypher);

        // loop over the longer of the two above
        string charTable = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        StringBuilder decryptedText = new StringBuilder();
        if (longerString == "message")
        {
            for (int i = 0, j = 0; i < encryptedMessage.Length; i++, j++)
            {
                if (j >= cypher.Length)
                {
                    j = 0;
                }

                int newSymbolCode = encryptedMessage[i] - 'A';
                int cypherCharCode = charTable.IndexOf(cypher[j]);
                int decodedCharCode = newSymbolCode ^ cypherCharCode;
                decryptedText.Append(charTable[decodedCharCode]);
            }
        }
        else
        {
            for (int j = 0, i = 0; j < cypher.Length; j++, i++)
            {
                if (i >= encryptedMessage.Length)
                {
                    i = 0;
                    encryptedMessage = decryptedText.ToString();
                }

                if (j < encryptedMessage.Length)
                {
                    int decodedCharCode = CalculateCharCode(encryptedMessage, cypher, charTable, i, j);
                    decryptedText.Append(charTable[decodedCharCode]);
                }
                else
                {
                    int decodedCharCode = CalculateCharCode(encryptedMessage, cypher, charTable, i, j);
                    decryptedText.Replace(decryptedText[i], charTable[decodedCharCode], i, 1);
                }
            }
        }

        return decryptedText.ToString();
    }

    private static int CalculateCharCode(string encryptedMessage, string cypher, string charTable, int i, int j)
    {
        int newSymbolCode = encryptedMessage[i] - 'A';
        int cypherCharCode = charTable.IndexOf(cypher[j]);
        int decodedCharCode = newSymbolCode ^ cypherCharCode;

        return decodedCharCode;
    }

    private static string GetLonger(string encryptedMessage, string cypher)
    {
        if (encryptedMessage.Length >= cypher.Length)
        {
            return "message";
        }
        else
        {
            return "cypher";
        }
    }

    private static string Decompress(string compressedText, int cypherLength)
    {
        StringBuilder decompressedText = new StringBuilder();

        // loop to the end of compressed text but without the last chars which is/are the cypher length
        for (int i = 0; i < compressedText.Length - cypherLength.ToString().Length; i++)
        {
            if (char.IsDigit(compressedText[i]))
            {
                // get full number
                int repetitionNumber = GetFullNumber(compressedText, ref i);
                for (int j = 0; j < repetitionNumber; j++)
                {
                    decompressedText.Append(compressedText[i]);
                }
            }
            else
            {
                decompressedText.Append(compressedText[i]);
            }
        }

        return decompressedText.ToString();
    }

    private static int GetFullNumber(string text, ref int i)
    {
        StringBuilder number = new StringBuilder();

        for (int index = i; index < text.Length; index++)
        {
            if (char.IsDigit(text[index]))
            {
                number.Append(text[index]);
            }
            else
            {
                i = index;
                break;
            }
        }

        return int.Parse(number.ToString());
    }

    private static int GetCypherLength(string cypheredText)
    {
        StringBuilder length = new StringBuilder();

        for (int i = cypheredText.Length - 1; i >= 0; i--)
        {
            if (!char.IsDigit(cypheredText[i]))
            {
                break;
            }

            length.Insert(0, cypheredText[i]);  // if slow try with reversing the StringBuilder
        }

        return int.Parse(length.ToString());
    }
}