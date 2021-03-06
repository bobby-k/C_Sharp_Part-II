﻿using System;
using System.Globalization;
using System.Threading;

internal class BinaryToDecimal
{
    // Write a program to convert binary numbers to their decimal representation.
    private static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        Console.Write("Please enter a number in binary representation: ");
        string userInput = Console.ReadLine();

        ConvertBinaryToDecimal(userInput);
    }

    private static void ConvertBinaryToDecimal(string userInput)
    {
        userInput = Validate(userInput);
        double decimalNum = 0;
        int lastIndex = userInput.Length - 1;
        for (int i = 0; i < userInput.Length; i++)
        {
            decimalNum += (userInput[lastIndex] - '0') * (Math.Pow(2, i));
            lastIndex--;
        }

        Console.Clear();
        Console.WriteLine("{0} in binary system is\n{1} in decimal system", userInput, decimalNum);
    }

    private static string Validate(string userInput)
    {
        bool validInput = false;
        while (!validInput)
        {
            foreach (char symbol in userInput)
            {
                if (symbol != '0' && symbol != '1')
                {
                    validInput = false;
                    Console.Write("Wrong format!!!\nBinary representations can only have \"0\"s or \"1\"s\nTry again: ");
                    userInput = Console.ReadLine();
                    break;
                }
                else
                {
                    validInput = true;
                }
            }
        }
        return userInput;
    }
}