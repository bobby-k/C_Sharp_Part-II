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
        string target = Console.ReadLine();

        Console.Clear();
        int occurrences = CountSubstringOccurrences(target, text);
        Console.WriteLine("The targeted sub-string \"{0}\" was found {1} times", target, occurrences);
    }

    private static int CountSubstringOccurrences(string substring, string text)
    {
        int counter = 0;
        int index = 0;

        for (int i = index; i < text.Length; i += substring.Length)
        {
            index = text.IndexOf(substring, index + substring.Length);
            if (index < 0)
            {
                break;
            }
            else
            {
                counter++;
            }
        }

        return counter;
    }
}