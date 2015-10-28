using System;
using System.Text;

internal class SeriesOfLetters
{
    /* Write a program that reads a string from the console
     * and replaces all series of consecutive identical
     * letters with a single one.*/

    private static void Main()
    {
        Console.WriteLine("Enter a string with series of consecutive identical letters:");
        string text = Console.ReadLine();
        
        Console.WriteLine("Before: {0}", text);

        text = ReplaceSameLetters(text);
        Console.WriteLine("After: {0}", text);
    }

    private static string ReplaceSameLetters(string text)
    {
        StringBuilder replacedText = new StringBuilder();
        for (int i = 0; i < text.Length; i++)
        {
            if (i == text.Length - 1)
            {
                replacedText.Append(text[i]);
                break;
            }
            else if (text[i] == text[i + 1])
            {
                continue;
            }
            else
            {
                replacedText.Append(text[i]);
            }
        }

        return replacedText.ToString();
    }
}