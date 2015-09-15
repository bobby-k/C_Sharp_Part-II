using System;
using System.Globalization;
using System.Threading;

internal class DecimalToBinary
{
    // Write a program to convert decimal numbers to their binary representation.
    private static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        Console.Write("Please enter a number in decimal representation: ");
        int userInput = int.Parse(Console.ReadLine());

        ConvertDecimalToBinary(userInput);
    }

    private static void ConvertDecimalToBinary(int userInput)
    {
        userInput = Validate(userInput);
        int remain = 0;
        string tempBinaryRepr = "";
        string binaryRepr = "";

        for (int i = userInput; i > 0; i /= 2)
        {
            remain = i % 2;
            tempBinaryRepr += remain;
        }

        // reversing
        for (int i = tempBinaryRepr.Length - 1; i >= 0; i--)
        {
            binaryRepr += tempBinaryRepr[i];
        }

        Console.WriteLine("{0} in decimal system is\n{1} in binary system", userInput, binaryRepr);
    }

    private static int Validate(int userInput)
    {
        while (userInput < 0)
        {
            Console.Write("Please enter a non-negative number: ");
            userInput = int.Parse(Console.ReadLine());
        }
        return userInput;
    }
}