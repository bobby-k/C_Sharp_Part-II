using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

class DateInBulgarian
{
    // Write a program that reads a date and time given in the format: day.month.year hour:minute:second and prints the date and time
    // after 6 hours and 30 minutes (in the same format) along with the day of week in Bulgarian.
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("bg-BG");
    }
}