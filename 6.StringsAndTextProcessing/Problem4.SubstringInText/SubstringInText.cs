using System;
using System.Globalization;
using System.Threading;

internal class SubstringInText
{
    // Write a program that finds how many times a sub-string is contained in a given text (perform case insensitive search).
    private static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        Console.WriteLine("Please type some text here:");
        string text = Console.ReadLine().ToLower();

        Console.Clear();
        Console.Write("Please specify the sub-string you want to count: ");
        string target = Console.ReadLine().ToLower();

        Console.Clear();
        int occurrences = CountSubstringOccurrences(target, text);
        Console.WriteLine("\"{0}\" is found at {1} places in the whole text",target , occurrences);
    }

    private static int CountSubstringOccurrences(string substring, string text)
    {
        int counter = 0;
        int index = 0;

        for (int i = 0; i < text.Length;)
        {
            index = text.IndexOf(substring, index, StringComparison.InvariantCultureIgnoreCase);
            if (index < 0)
            {
                break;
            }
            else
            {
                counter++;
            }

            index += substring.Length;
            i = index;
        }

        return counter;
    }
}