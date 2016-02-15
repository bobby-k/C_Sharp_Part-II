using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

internal class RemoveWords
{
    // Write a program that removes from a text file all words listed in given another text file. Handle all possible exceptions in
    // your methods.
    private static void Main()
    {
        string pathIn = @"..\..\Files\someText.txt";
        string pathOut = @"..\..\Files\output.txt";
        string pathWords = @"..\..\Files\wordsList.txt";

        try
        {
            Console.WriteLine("Initializing forbidden words...");
            var forbiddenWords = GetWordsFromList(pathWords);
            Console.WriteLine("Removing forbidden words...");
            RemoveForbiddenWords(forbiddenWords, pathIn, pathOut);
            Console.WriteLine("Done!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Job is incomplete...\nPlease debug to isolate the problem...\nHint: {0}\n\n{1}", ex.Message, ex.StackTrace);
        }
    }

    private static List<string> GetWordsFromList(string path)
    {
        var reader = new StreamReader(path, Encoding.Default);
        var words = new List<string>();

        using (reader)
        {
            string line = reader.ReadLine();

            while (line != null)
            {
                string[] wordsFromCurrentLine = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var word in wordsFromCurrentLine)
                {
                    words.Add(word);
                }

                line = reader.ReadLine();
            }
        }

        return words;
    }

    private static void RemoveForbiddenWords(List<string> words, string pathIn, string pathOut)
    {
        var reader = new StreamReader(pathIn, Encoding.Default);
        var writer = new StreamWriter(pathOut);

        char[] punctuationMarks = { ' ', '.', ',', '!', '?', ':', '-' };

        using (reader)
        {
            using (writer)
            {
                string line = reader.ReadLine();

                while (line != null)
                {
                    string[] wordsOfLine = line.Split(punctuationMarks, StringSplitOptions.RemoveEmptyEntries);

                    for (int i = 0; i < wordsOfLine.Length; i++)
                    {
                        if (words.Contains(wordsOfLine[i], StringComparer.InvariantCultureIgnoreCase))
                        {
                            wordsOfLine.SetValue(null, i);
                        }
                    }

                    writer.WriteLine(string.Join(" ", wordsOfLine));

                    line = reader.ReadLine();
                }
            }
        }
    }
}