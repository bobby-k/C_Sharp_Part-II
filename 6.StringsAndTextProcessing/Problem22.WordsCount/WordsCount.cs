using System;
using System.Collections.Generic;

internal class WordsCount
{
    // Write a program that reads a string from the console and lists all different words in the string along with information how many
    // times each word is found.
    private static Dictionary<string, int> wordsCount = new Dictionary<string, int>();

    private static void Main()
    {
        Console.WriteLine("Enter some text here");
        string text = Console.ReadLine();

        string[] separateWords = text.Split(new char[] { ' ', '.', ',', '-', '!', '?', ';', ':', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);

        CountWordsOccurance(separateWords);
        Print(wordsCount);
    }

    private static void CountWordsOccurance(string[] separateWords)
    {
        for (int i = 0; i < separateWords.Length; i++)
        {
            if (wordsCount.ContainsKey(separateWords[i]))
            {
                string word = separateWords[i];
                wordsCount[word]++;
            }
            else
            {
                wordsCount.Add(separateWords[i], 1);
            }
        }
    }

    private static void Print(Dictionary<string, int> collection)
    {
        Console.WriteLine(new string('*', 25));
        Console.WriteLine("Words counted as follows:");
        foreach (var item in collection)
        {
            Console.WriteLine("{0} - {1}", item.Key, item.Value);
        }
    }
}