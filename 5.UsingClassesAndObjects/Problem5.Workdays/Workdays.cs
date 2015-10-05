using System;
using System.Globalization;
using System.Linq;
using System.Threading;

internal class Workdays
{
    // Write a method that calculates the number of workdays between currentDay and given date, passed as parameter. Consider that
    // workdays are all days from Monday to Friday except a fixed list of public holidays specified preliminary as array.

    // P.S.Използвана е актуална информация за официалните празници и дните които ще се отработват през 2015г.

    private static DateTime currentDay = DateTime.Now;

    private static DateTime endDate;

    private static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        GetEndDate();

        int workingDays = 0;
        // определя периода от време м/у текущият ден и зададената крайна дата
        int numberOfDays = (endDate.DayOfYear - currentDay.DayOfYear) + 1;   // +1 включва и текущият ден
        while (numberOfDays > 0)
        {
            // All Mondays - Fridays except if it's a public holiday
            if (currentDay.DayOfWeek != DayOfWeek.Saturday
                && currentDay.DayOfWeek != DayOfWeek.Sunday
                && !IsPublicHoliday(currentDay))
            {
                workingDays++;
            }
            // All Saturdays except those that are working
            if (currentDay.DayOfWeek == DayOfWeek.Saturday)
            {
                if (IsWorkingSaturday(currentDay))
                {
                    workingDays++;
                }
            }
            currentDay = currentDay.AddDays(1);
            numberOfDays--;
        }

        // TODO: намери как да се отпечата само датата (DD/MM/YYYY) на обект от DateTime до тогава ще използваме нашият string date
        string date = endDate.Day.ToString() + "/" + endDate.Month + "/" + endDate.Year;
        Console.WriteLine("There are {0} working days from today to {1} including", workingDays, date);
        // вместо string date може да използваме endDate.Date.ToString("dd-MM-yyyy")
    }

    private static void GetEndDate()
    {
        Console.WriteLine("Please enter a date until which you want to count the working days: ");

        while (true)
        {
            if (DateTime.TryParse(Console.ReadLine(), out endDate))
            {
                if (endDate < currentDay)
                {
                    Console.Write("Invalid date\nYou can check days only in the future\nTry again: ");
                    continue;
                }
                else if (endDate.Year > currentDay.Year)
                {
                    Console.Write("Invalid date\nYou can check days only for the CURRENT year!!!\nTry again: ");
                    continue;
                }
                else break;
            }
            else
            {
                Console.Write("Invalid date\nUse this format MM/DD/YYYY\nTry again: ");
            }
        }
    }

    private static bool IsPublicHoliday(DateTime date)
    {
        DateTime[] publicHolidays =
        {
            new DateTime(2015,1,1),new DateTime(2015,1,2),
            new DateTime(2015,3,2),new DateTime(2015,3,3),
            new DateTime(2015,4,10),new DateTime(2015,4,13),
            new DateTime(2015,5,1),new DateTime(2015,5,6),
            new DateTime(2015,9,21),new DateTime(2015,9,22),
            new DateTime(2015,12,24),new DateTime(2015,12,25),
            new DateTime(2015,12,31)
        };

        // при проверката трябва да се проверява само частта с датата,тъй като масива publicHolidays е съставен само от дати, затова на
        // подаденият параметър date, който е обекта с текущият ден, му вземаме само датата чрез date.Date
        if (publicHolidays.Contains(date.Date))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private static bool IsWorkingSaturday(DateTime date)
    {
        DateTime[] workingSaturdays =
        {
            new DateTime(2015,1,24),new DateTime(2015,3,21),
            new DateTime(2015,9,12),new DateTime(2015,12,12)
        };

        // при проверката трябва да се проверява само частта с датата,тъй като масива workingSaturdays е съставен само от дати, затова
        // на подаденият параметър date, който е обекта с текущият ден, му вземаме само датата чрез date.Date
        if (workingSaturdays.Contains(date.Date))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}