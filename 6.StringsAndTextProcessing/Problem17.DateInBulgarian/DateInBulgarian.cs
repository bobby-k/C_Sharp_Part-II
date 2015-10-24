using System;
using System.Globalization;
using System.Threading;

internal class DateInBulgarian
{
    // Write a program that reads a date and time given in the format: day.month.year hour:minute:second and prints the date and time
    // after 6 hours and 30 minutes (in the same format) along with the day of week in Bulgarian.
    private static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("bg-BG");

        Console.WriteLine("Enter a date in the following format dd.MM.yyyy hh:mm:ss");
        string date = Console.ReadLine();

        DateTime parsedDate;

        while (true)
        {
            if (DateTime.TryParse(date, out parsedDate))
            {
                parsedDate = parsedDate.AddHours(6).AddMinutes(30);
                break;
            }
            else
            {
                Console.WriteLine("Make sure you follow the format dd.MM.yyyy hh:mm:ss");
                date = Console.ReadLine();
            }
        }

        Console.WriteLine("After 6 hours and 30 minutes will be {0} {1}", parsedDate, parsedDate.ToString("dddd"));
    }
}