using System;
using System.Collections.Generic;

internal class WordDictionary
{
    // A dictionary is stored as a sequence of text lines containing words and their explanations. Write a program that enters a word
    // and translates it by using the dictionary.
    private static void Main()
    {
        // setting the dictionary up
        Dictionary<string, string> dictionary = new Dictionary<string, string>();

        string text = ".NET-platform for applications from Microsoft,CLR-managed execution environment for .NET,namespace-hierarchical organization of classes";
        string[] keyValuePairs = text.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        string[] keysAndValues = new string[2];

        for (int i = 0; i < keyValuePairs.Length; i++)
        {
            keysAndValues = keyValuePairs[i].Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            dictionary.Add(keysAndValues[0], keysAndValues[1]);
        }

        // waiting for the user to ask for a word
        Console.WriteLine("Enter a word to check its meaning:");
        string input = Console.ReadLine();

        while (input != "exit")
        {
            string value;
            if (dictionary.TryGetValue(input, out value))
            {
                Console.WriteLine(value);
            }
            else
            {
                Console.WriteLine("Word is not in dictionary!");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Enter another word or type exit to close");
            input = Console.ReadLine();
        }
    }
}