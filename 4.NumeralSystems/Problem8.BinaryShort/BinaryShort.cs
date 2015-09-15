using System;
using System.Globalization;
using System.Threading;

internal class BinaryShort
{
    // Write a program that shows the binary representation of given 16-bit signed integer number (the C# type short).
    private static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        Console.Write("Please enter any value from the C# short type range to see its binary representation: ");
        short number = short.Parse(Console.ReadLine());

        ConvertToBynary(number);
    }

    private static void ConvertToBynary(short number)
    {
        int remain = 0;
        string tempBinaryRepr = "";
        string binaryRepr = "";

        // когато подаденото число е в отрицателният диапазон, двойчното му представяне е най-ляв бит 1, а останалите 15 бита са
        // всъщност разликата на най-голямата за типа стойност и подаденото число плюс 1, превърнато в двойчен вид и залепено за тази
        // единица която показва знака(най-левият бит)
        if (number < 0)
        {
            binaryRepr += '1';
            short temp = (short)(short.MaxValue + number + 1);
            for (int i = temp; i > 0; i /= 2)
            {
                remain = i % 2;
                tempBinaryRepr += remain;
            }
        }
        // когато подаденото число е в положителният диапазон, двойчното му представяне е най-ляв бит 0, а останалите 15 бита са
        // двойчното представяне на самото подадено число
        else
        {
            binaryRepr += '0';
            for (int i = number; i > 0; i /= 2)
            {
                remain = i % 2;
                tempBinaryRepr += remain;
            }
        }

        // reversing
        for (int i = tempBinaryRepr.Length - 1; i >= 0; i--)
        {
            binaryRepr += tempBinaryRepr[i];
        }

        // в случай че двойчното представяне има по-малко на брой битове от 15(тъй като най-левият е за знака) ще добавяме нули след
        // най-левият бит до достигане на общ брой битове 16, така ще се отпечатва правилното представяне на двойчният вид на
        // подаденото число
        while (binaryRepr.Length < 16)
        {
            binaryRepr = binaryRepr.Insert(1, "0");
        }

        Console.WriteLine(new string('*', 45));
        Console.WriteLine(binaryRepr);
    }
}