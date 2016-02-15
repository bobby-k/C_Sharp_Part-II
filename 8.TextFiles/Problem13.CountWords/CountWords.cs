using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

internal class CountWords
{
    // Write a program that reads a list of words from the file words.txt and finds how many times each of the words is contained in
    // another file test.txt. The result should be written in the file result.txt and the words should be sorted by the number of their
    // occurrences in descending order. Handle all possible exceptions in your methods.
    private static void Main()
    {
        string pathIn = @"..\..\Files\words.txt";
        string pathTargetToCount = @"..\..\Files\test.txt";
        string pathOut = @"..\..\Files\result.txt";

        try
        {
            Console.WriteLine("Initializing words...");
            string[] words = InitialiseWords(pathIn);
            Console.WriteLine("Counting words...");
            var countedWords = CountWordsOccurence(words, pathTargetToCount);
            Console.WriteLine("Printing to file...");
            PrintOutputToFile(countedWords, pathOut);
            Console.WriteLine("Done!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Job was aborted...\nResult is incomplete!\nDebug to find the problem!\nHint: {0}\n\n{1}", ex.Message, ex.StackTrace);
        }
    }

    private static string[] InitialiseWords(string path)
    {
        var reader = new StreamReader(path);
        string[] words;

        using (reader)
        {
            string allWords = reader.ReadToEnd();
            words = allWords.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries); // split by new line
        }

        return words;
    }

    private static Dictionary<string, int> CountWordsOccurence(string[] words, string pathTarget)
    {
        char[] punctuationMarks = { ' ', '.', ',', '!', '?', ':', '-' };
        var resultSummary = new Dictionary<string, int>(words.Length);
        var reader = new StreamReader(pathTarget);

        using (reader)
        {
            string line = reader.ReadLine();

            while (line != null)
            {
                string[] wordsFromLine = line.Split(punctuationMarks, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < wordsFromLine.Length; i++)
                {
                    if (words.Contains(wordsFromLine[i].ToLower())) // case insensitive
                    {
                        if (resultSummary.ContainsKey(wordsFromLine[i].ToLower()))  // case insensitive
                        {
                            resultSummary[wordsFromLine[i]]++;
                        }
                        else
                        {
                            resultSummary.Add(wordsFromLine[i].ToLower(), 1);   // case insensitive
                        }
                    }
                }

                line = reader.ReadLine();
            }
        }

        return resultSummary;
    }

    private static void PrintOutputToFile(Dictionary<string, int> wordsAndNumbersToPrint, string path)
    {
        var writer = new StreamWriter(path);

        using (writer)
        {
            foreach (var pair in wordsAndNumbersToPrint.OrderByDescending(key => key.Value))
            {
                writer.WriteLine("{0,6} - {1:D2}", pair.Key, pair.Value);
            }
        }
    }
}