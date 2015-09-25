using System;
using System.Globalization;
using System.Threading;

public static class SumIntegers
{
    // You are given a sequence of positive integer values written into a string, separated by spaces. Write a function that reads
    // these values from given string and calculates their sum.
    private static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        string sequence = "43 68 9 23 318";
        int sum = Sum(sequence);
        Console.WriteLine("The sum of {0} is {1}", sequence, sum);
    }

    public static int Sum(string sequence)
    {
        string[] sequenceMembers = sequence.Split(' ');
        int sum = 0;

        foreach (string member in sequenceMembers)
        {
            sum += int.Parse(member);
        }

        return sum;
    }
}