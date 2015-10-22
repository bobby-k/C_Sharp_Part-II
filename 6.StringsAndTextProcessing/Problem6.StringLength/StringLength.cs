using System;

internal class StringLength
{
    // Write a program that reads from the console a string of maximum 20 characters. If the length of the string is less than 20, the
    // rest of the characters should be filled with *. Print the result string into the console.
    private static void Main()
    {
        Console.WriteLine("Enter text with max length of 20 characters!");
        string text = Console.ReadLine();

        if (text.Length > 20) text = text.Substring(0, 20);
        else text = text.PadRight(20, '*');

        Console.WriteLine(text);
    }
}