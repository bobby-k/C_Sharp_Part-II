using System;
using System.Globalization;
using System.Text;
using System.Threading;

internal class ReverseString
{
    // Write a program that reads a string, reverses it and prints the result at the console.
    private static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        Console.Write("Please enter some text here: ");
        string text = Console.ReadLine();

        text = ReverseText(text);
        Console.WriteLine(text);
    }

    private static string ReverseText(string text)
    {
        StringBuilder reversedText = new StringBuilder();

        for (int i = text.Length - 1; i >= 0; i--)
        {
            reversedText.Append(text[i]);
        }

        return reversedText.ToString();
    }
}