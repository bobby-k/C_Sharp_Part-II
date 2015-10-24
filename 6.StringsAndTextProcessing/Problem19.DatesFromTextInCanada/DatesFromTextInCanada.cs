using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

internal class DatesFromTextInCanada
{
    // Write a program that extracts from a given text all dates that match the format DD.MM.YYYY. Display them in the standard date
    // format for Canada.
    private static void Main()
    {
        string text = "I was born at 14.06.1980. My sister was born at 3.7.1984. In 5/1999 I graduated my high school. The law says (see section 7.3.12) that we are allowed to do this (section 7.4.2.9).";
        string datePattern = @"\d{1,2}\.\d{1,2}\.\d{4}"; // matches all dates in 'dd.MM.yyyy' format

        var dates = Regex.Matches(text, datePattern);

        // parses each match to a DateTime object
        List<DateTime> parsedDates = new List<DateTime>();
        foreach (var date in dates)
        {
            parsedDates.Add(DateTime.Parse(date.ToString()));
        }

        // prints each parsed date with the standard date format for Canada.
        foreach (var parsedDate in parsedDates)
        {
            Console.WriteLine(parsedDate.ToString("d", CultureInfo.CreateSpecificCulture("en-CA")));
        }
    }
}