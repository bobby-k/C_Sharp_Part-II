using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

class DateDifference
{
    // Write a program that reads two dates in the format: day.month.year and calculates the number of days between them.
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        DateTime fromDate = GetDate();// make these global
        DateTime toDate = GetDate();// make these global

        while (fromDate == DateTime.MinValue || toDate == DateTime.MinValue)
        {
            if (fromDate == DateTime.MinValue)
            {
                Console.WriteLine("The first date you entered is wrong!!!\nMake sure it matches the format mm/dd/yyyy");
                fromDate = GetDate();
            }
            else
            {
                Console.WriteLine("The second date is wrong!!!\nMake sure it matches the format mm/dd/yyyy");
                toDate = GetDate();
            }
        }

        ValidateToDate(fromDate, toDate);

        Console.Clear();
        Console.WriteLine("From: " + fromDate.ToString("dd/MM/yyyy"));
        Console.WriteLine("To: " + toDate.ToString("dd/MM/yyyy"));
        TimeSpan days = toDate - fromDate;
        Console.WriteLine("There are {0} days past between the two dates.", days.Days);


    }

    static DateTime GetDate()
    {
        Console.Write("Enter a date in the following format 'mm/dd/yyyy': ");
        string inputDate = Console.ReadLine();

        DateTime date;
        if (DateTime.TryParse(inputDate, out date))
        {
            Console.WriteLine("Entered date: " + date.ToString("dd/MM/yyyy"));
        }

        return date;
    }

    static void ValidateToDate(DateTime dateFrom,DateTime dateTo)
    {
        while (dateTo < dateFrom)
        {
            Console.WriteLine("NOTICE:The second date must be a period after the first date!\nPlease enter a date after {0}", dateFrom.ToString("dd/MM/yyyy"));
            dateTo = GetDate();
        }
    }
}
