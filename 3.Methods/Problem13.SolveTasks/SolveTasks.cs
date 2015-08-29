using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


class SolveTasks
{
    // Write a program that can solve these tasks:
    // - Reverses the digits of a number
    // - Calculates the average of a sequence of integers
    // - Solves a linear equation a * x + b = 0
    // Create appropriate methods.
    // Provide a simple text-based menu for the user to choose which task to solve.
    // Validate the input data:
    // - The decimal number should be non-negative
    // - The sequence should not be empty
    // - a should not be equal to 0


    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        ReverseDigits();
        CalculateAverage();
    }

    private static void CalculateAverage()
    {
        Console.Write("Please enter some sequence of integers: ");
        int userInput = int.Parse(Console.ReadLine());

        var sequence = new List<int>();
        sequence.Add(userInput);
        while (true)
        {
            sequence.Add(userInput);
        }


    }

    private static void ReverseDigits()
    {
        Console.Write("Please enter the number you want to reverse: ");
        decimal number = decimal.Parse(Console.ReadLine());

        string numberToStr = Convert.ToString(number);
        string numberTostrReversed = "";
        for (int i = numberToStr.Length - 1; i >= 0; i--)
        {
            numberTostrReversed += numberToStr[i];
        }

        decimal numberReversed = decimal.Parse(numberTostrReversed);
        Console.WriteLine("Here it is {0}", numberReversed);
    }


}
