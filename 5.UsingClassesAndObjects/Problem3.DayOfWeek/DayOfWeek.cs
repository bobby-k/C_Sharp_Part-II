using System;
using System.Globalization;
using System.Threading;

internal class DayOfWeek
{
    // Write a program that prints to the console which day of the week is today. Use System.DateTime.
    private static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        Console.WriteLine("Today is {0}.", DateTime.Now.DayOfWeek);
    }
}