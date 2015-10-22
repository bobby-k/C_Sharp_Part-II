using System;

internal class ForbiddenWords
{
    // We are given a string containing a list of forbidden words and a text containing some of these words. Write a program that
    // replaces the forbidden words with asterisks.
    private static string[] forbidenWords = { "PHP", "CLR", "Microsoft" };
    private static string text = "Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.";

    private static void Main()
    {
        for (int i = 0; i < forbidenWords.Length; i++)
        {
            text = text.Replace(forbidenWords[i], new string('*', forbidenWords[i].Length));
        }

        Console.WriteLine(text);
    }
}