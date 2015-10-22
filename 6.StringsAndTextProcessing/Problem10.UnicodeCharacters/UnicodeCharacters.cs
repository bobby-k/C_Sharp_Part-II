using System;
using System.Text;

internal class UnicodeCharacters
{
    // Write a program that converts a string to a sequence of C# Unicode character literals. Use format strings.
    private static void Main()
    {
        Console.WriteLine("Enter some text here:");
        string input = Console.ReadLine();

        var convertedText = new StringBuilder();

        for (int i = 0; i < input.Length; i++)
        {
            convertedText.Append(string.Format("\\u{0:x4}", (int)input[i]));
        }

        Console.WriteLine(convertedText.ToString());
    }
}