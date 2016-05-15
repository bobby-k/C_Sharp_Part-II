using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;

internal class HexadecimalToBinary
{
    // Write a program to convert hexadecimal numbers to binary numbers (directly).
    private static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        Console.Write("Please enter a valid hex number: ");
        string hex = Console.ReadLine().ToUpper();

        ConvertHexToBinary(hex);
    }

    private static void ConvertHexToBinary(string hex)
    {
        hex = Validate(hex);
        string binaryRepr = "";
        foreach (char symbol in hex)
        {
            // can be used Dictionary<char,string> instead of the switch construction in that case use 
            // binaryRepr += hexToBinTable[symbol];
            switch (symbol)
            {
                case '0': binaryRepr += "0000";
                    break;

                case '1': binaryRepr += "0001";
                    break;

                case '2': binaryRepr += "0010";
                    break;

                case '3': binaryRepr += "0011";
                    break;

                case '4': binaryRepr += "0100";
                    break;

                case '5': binaryRepr += "0101";
                    break;

                case '6': binaryRepr += "0110";
                    break;

                case '7': binaryRepr += "0111";
                    break;

                case '8': binaryRepr += "1000";
                    break;

                case '9': binaryRepr += "1001";
                    break;

                case 'A': binaryRepr += "1010";
                    break;

                case 'B': binaryRepr += "1011";
                    break;

                case 'C': binaryRepr += "1100";
                    break;

                case 'D': binaryRepr += "1101";
                    break;

                case 'E': binaryRepr += "1110";
                    break;

                case 'F': binaryRepr += "1111";
                    break;
            }
        }

        binaryRepr = RemoveLeadingZeroes(binaryRepr);
        Console.WriteLine("{0} in hexadecimal system is\n{1} in binary system", hex, binaryRepr);
    }

    private static string RemoveLeadingZeroes(string binaryRepr)
    {
        StringBuilder binary = new StringBuilder(binaryRepr);

        int index = 0;
        int length = 0;
        while (binary[index] != '1')
        {
            length++;
            index++;
        }

        binary.Remove(0, length);
        return binary.ToString();
    }

    private static string Validate(string hex)
    {
        bool validHexChar = false;
        char[] validHexChars = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f', 'A', 'B', 'C', 'D', 'E', 'F' };
        while (!validHexChar)
        {
            foreach (char symbol in hex)
            {
                if (validHexChars.Contains(symbol))
                {
                    validHexChar = true;
                }
                else
                {
                    validHexChar = false;
                    Console.Write("The hex string you entered has some invalid chars!!!\nTry another: ");
                    hex = Console.ReadLine();
                    break;
                }
            }
        }
        return hex;
    }
}