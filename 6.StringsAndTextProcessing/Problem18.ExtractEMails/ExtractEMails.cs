using System;
using System.Text.RegularExpressions;

internal class ExtractEMails
{
    // Write a program for extracting all email addresses from given text. All sub-strings that match the format
    // <identifier>@<host>.<domain> should be recognized as emails.
    private static void Main()
    {
        string text = "ala bala pesho@gosho.bg, dara bara bla bla bla bla bla gosho@pesho.ru bla dara bara bla bla bla bla bla bla pesho@abv.bg, pesho@gmail.com, pesho@hotmail.eu, baj_ivan@yahoo.co.uk.";
        string anotherText = "Please contact us by phone (+359 222 222 222) or by email at example@abv.bg or at baj.ivan@yahoo.co.uk. This is not email: test@test. This also: @telerik.com. Neither this: a@a.b.";

        string matchEmailPattern = @"(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
        + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
        + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
        + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})";

        var emailAddresses = Regex.Matches(text, matchEmailPattern);
        var emailAddresses1 = Regex.Matches(anotherText, matchEmailPattern);

        // Print(emailAddresses);
        Print(emailAddresses1);
    }

    private static void Print(MatchCollection collection)
    {
        Console.WriteLine("Extracted e-mail addresses:");
        Console.WriteLine(new string('*', 27));

        foreach (var item in collection)
        {
            Console.WriteLine(item);
        }
    }
}