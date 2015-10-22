using System;
using System.Collections.Generic;

internal class ExtractSentences
{
    // Write a program that extracts from a given text all sentences containing given word.Consider that the sentences are separated by
    // . and the words – by non-letter symbols.
    private static void Main()
    {
        Console.WriteLine("Enter some text here:");
        string text = Console.ReadLine();
        Console.WriteLine(new string('*', 25));
        Console.Write("Specify the word to look for in a sentence: ");
        string keyWord = Console.ReadLine();
        Console.WriteLine(new string('*', 25));

        string wordSeparator = " ";
        keyWord = keyWord.Insert(0, wordSeparator);
        keyWord = keyWord.Insert(keyWord.Length, wordSeparator);

        string[] sentences = text.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);

        List<int> indexes = new List<int>();
        for (int i = 0; i < sentences.Length; i++)
        {
            if (sentences[i].IndexOf(keyWord) > 0)
            {
                indexes.Add(i);
            }
        }

        for (int i = 0; i < indexes.Count; i++)
        {
            Console.Write(sentences[indexes[i]] + ".");
        }

        Console.WriteLine();
    }
}