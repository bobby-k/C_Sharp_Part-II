using System;
using System.Globalization;
using System.Linq;
using System.Threading;

internal class HexadecimalToDecimal
{
    // Write a program to convert hexadecimal numbers to their decimal representation.
    private static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        Console.Write("Please enter a number in hexadecimal system: ");
        string userInput = Console.ReadLine().ToUpper();

        ConvertHexToDec(userInput);
    }

    private static void ConvertHexToDec(string userInput)
    {
        userInput = Validate(userInput);
        double decimalNum = 0;
        int lastIndex = userInput.Length - 1;
        for (int i = 0; i < userInput.Length; i++)
        {
            switch (userInput[lastIndex])
            {
                case 'a': decimalNum += 10 * Math.Pow(16, i);
                    lastIndex--;
                    break;

                case 'b': decimalNum += 11 * Math.Pow(16, i);
                    lastIndex--;
                    break;

                case 'c': decimalNum += 12 * Math.Pow(16, i);
                    lastIndex--;
                    break;

                case 'd': decimalNum += 13 * Math.Pow(16, i);
                    lastIndex--;
                    break;

                case 'e': decimalNum += 14 * Math.Pow(16, i);
                    lastIndex--;
                    break;

                case 'f': decimalNum += 15 * Math.Pow(16, i);
                    lastIndex--;
                    break;

                case 'A': decimalNum += 10 * Math.Pow(16, i);
                    lastIndex--;
                    break;

                case 'B': decimalNum += 11 * Math.Pow(16, i);
                    lastIndex--;
                    break;

                case 'C': decimalNum += 12 * Math.Pow(16, i);
                    lastIndex--;
                    break;

                case 'D': decimalNum += 13 * Math.Pow(16, i);
                    lastIndex--;
                    break;

                case 'E': decimalNum += 14 * Math.Pow(16, i);
                    lastIndex--;
                    break;

                case 'F': decimalNum += 15 * Math.Pow(16, i);
                    lastIndex--;
                    break;

                default: decimalNum += (userInput[lastIndex] - '0') * Math.Pow(16, i);
                    lastIndex--;
                    break;
            }
        }

        Console.Clear();
        Console.WriteLine("{0} in hexadecimal system is\n{1} in decimal system", userInput, decimalNum);
    }

    private static string Validate(string userInput)
    {
        char[] allowedChars = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
        bool validInput = false;

        while (!validInput)
        {
            foreach (char symbol in userInput)
            {
                if (allowedChars.Contains(symbol))
                {
                    validInput = true;
                }
                else
                {
                    validInput = false;
                    Console.Write("Allowed symbols are 0-9 and A-F/a-f\nPlease try again: ");
                    userInput = Console.ReadLine();
                    break;
                }
            }
        }
        return userInput;
    }
}