using System;
using System.Globalization;
using System.Threading;

internal class LeapYear
{
    // Write a program that reads a year from the console and checks whether it is a leap one. Use System.DateTime
    private static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        Console.Write("Please enter an year to check if it is a leap or not: ");
        ushort year = ushort.Parse(Console.ReadLine());

        Console.WriteLine("Is {0} a leap year? --> {1}", year, DateTime.IsLeapYear(year));
    }
}