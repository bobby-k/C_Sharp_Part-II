using System;
using System.Globalization;
using System.Threading;

internal class DecimalToHexadecimal
{
    // Write a program to convert decimal numbers to their hexadecimal representation.
    private static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        Console.Write("Please enter a number in decimal system: ");
        int userInput = int.Parse(Console.ReadLine());

        ConvertDecToHex(userInput);
    }

    private static void ConvertDecToHex(int userInput)
    {
        userInput = Validate(userInput);
        string hexNum = "";
        string tempHex = "";

        for (int i = userInput; i > 0; i /= 16)
        {
            switch (i % 16)
            {
                case 10: tempHex += "A";
                    break;

                case 11: tempHex += "B";
                    break;

                case 12: tempHex += "C";
                    break;

                case 13: tempHex += "D";
                    break;

                case 14: tempHex += "E";
                    break;

                case 15: tempHex += "F";
                    break;

                default: tempHex += (i % 16).ToString();
                    break;
            }
        }

        // reversing
        for (int i = tempHex.Length - 1; i >= 0; i--)
        {
            hexNum += tempHex[i];
        }

        Console.WriteLine("{0} in decimal system is\n{1} in hexadecimal", userInput, hexNum);
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