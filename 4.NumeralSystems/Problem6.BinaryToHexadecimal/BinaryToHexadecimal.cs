using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

internal class BinaryToHexadecimal
{
    // Write a program to convert binary numbers to hexadecimal numbers (directly).
    private static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        Console.Write("Please enter a valid binary number: ");
        string binaryStr = Console.ReadLine();

        ConvertBinaryToHex(binaryStr);
    }

    private static void ConvertBinaryToHex(string binaryStr)
    {
        binaryStr = Validate(binaryStr);
        string hex = "";

        for (int i = 0, j = 0; i < binaryStr.Length; i += 4)
        {
            string fourBits = "";
            while (fourBits.Length < 4)
            {
                fourBits += binaryStr[j++];
            }
            hex += GetTableValue(fourBits);
        }

        Console.WriteLine("{0} in binary system is\n{1} in hexadecimal system", binaryStr, hex);
    }

    private static string Validate(string binaryStr)
    {
        bool validBinary = false;
        while (!validBinary)
        {
            foreach (char symbol in binaryStr)
            {
                if (symbol != '0' && symbol != '1')
                {
                    validBinary = false;
                    Console.WriteLine("Binary system can contain only 0s and 1s\nTry again: ");
                    binaryStr = Console.ReadLine();
                    break;
                }
                else
                {
                    validBinary = true;
                }
            }
        }
        // ако дължината на въведеният binary стринг не е кратна на 4 то ще се добавят толкова нули в началото, така че да стане кратна
        // на 4.Това е необходима валидация тъй като ключовете на речника са съставени от по 4 символа
        if (binaryStr.Length % 4 != 0)
        {
            while (binaryStr.Length % 4 != 0)
            {
                binaryStr = binaryStr.Insert(0, "0");
            }
        }
        return binaryStr;
    }

    private static char GetTableValue(string key)
    {
        var hexToBinaryTable = new Dictionary<string, char>();
        hexToBinaryTable.Add("0000", '0');
        hexToBinaryTable.Add("0001", '1');
        hexToBinaryTable.Add("0010", '2');
        hexToBinaryTable.Add("0011", '3');
        hexToBinaryTable.Add("0100", '4');
        hexToBinaryTable.Add("0101", '5');
        hexToBinaryTable.Add("0110", '6');
        hexToBinaryTable.Add("0111", '7');
        hexToBinaryTable.Add("1000", '8');
        hexToBinaryTable.Add("1001", '9');
        hexToBinaryTable.Add("1010", 'A');
        hexToBinaryTable.Add("1011", 'B');
        hexToBinaryTable.Add("1100", 'C');
        hexToBinaryTable.Add("1101", 'D');
        hexToBinaryTable.Add("1110", 'E');
        hexToBinaryTable.Add("1111", 'F');

        return hexToBinaryTable[key];
    }
}