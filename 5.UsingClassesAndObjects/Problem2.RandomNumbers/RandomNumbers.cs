using System;
using System.Globalization;
using System.Threading;

internal class RandomNumbers
{
    // Write a program that generates and prints to the console 10 random values in the range [100, 200].
    private static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        Random generator = new Random();

        for (int i = 0; i < 10; i++)
        {
            Console.Write("{0} ", generator.Next(100, 201));
        }
        Console.WriteLine();
    }
}