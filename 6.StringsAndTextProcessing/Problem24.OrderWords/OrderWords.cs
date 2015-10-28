using System;

internal class OrderWords
{
    // Write a program that reads a list of words, separated by spaces and prints the list in an alphabetical order.
    private static void Main()
    {
        Console.WriteLine("Enter a list of words, separated by spaces");
        string listOfWords = Console.ReadLine();

        string[] words = listOfWords.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        Array.Sort(words);

        foreach (var word in words)
        {
            Console.WriteLine(word);
        }
    }
}