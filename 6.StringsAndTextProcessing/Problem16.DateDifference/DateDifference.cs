using System;
using System.Globalization;
using System.Threading;

internal class DateDifference
{
    // Write a program that reads two dates in the format: day.month.year and calculates the number of days between them.
    private static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("bg-BG");

        DateTime fromDate = GetDate(); 
        DateTime toDate = GetDate(); // if GetDate(); returns DateTime.MinValue that means one or both dates didn't parse successful

        while (fromDate == DateTime.MinValue || toDate == DateTime.MinValue)
        {
            if (fromDate == DateTime.MinValue)
            {
                Console.WriteLine("The first date you entered is wrong!!!\nMake sure it matches the format dd.mm.yyyy");
                fromDate = GetDate();
            }
            else
            {
                Console.WriteLine("The second date is wrong!!!\nMake sure it matches the format dd.mm.yyyy");
                toDate = GetDate();
            }
        }

        toDate = ValidateToDate(fromDate, toDate);

        Console.Clear();
        Console.WriteLine("From: " + fromDate.ToString("dd/MM/yyyy"));
        Console.WriteLine("To: " + toDate.ToString("dd/MM/yyyy"));
        TimeSpan days = toDate - fromDate;
        Console.WriteLine("There are {0} days past between the two dates.", days.Days);
    }

    private static DateTime GetDate()
    {
        Console.Write("Enter a date in the following format 'dd.mm.yyyy': ");
        string inputDate = Console.ReadLine();

        DateTime date;
        if (DateTime.TryParse(inputDate, out date))
        {
            Console.WriteLine("Entered date: " + date.ToString("dd/MM/yyyy"));
        }

        return date;
    }

    private static DateTime ValidateToDate(DateTime dateFrom, DateTime dateTo)
    {
        while (dateTo < dateFrom)
        {
            Console.WriteLine("NOTICE:The second date must be a period after the first date!\nPlease enter a date after {0}", dateFrom.ToString("dd/MM/yyyy"));
            dateTo = GetDate();
        }

        return dateTo;
    }
}