using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

internal class ExtractSentences
{
    private static void Main()
    {
        // Write a program that extracts from a given text all sentences containing given word. Sentences are separated by .
        // and the words – by non-letter symbols

        string keyWord = Console.ReadLine();
        string text = Console.ReadLine();

        string[] sentences = text.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();

        List<string> result = new List<string>();
        for (int i = 0; i < sentences.Length; i++)
        {
            List<string> words = new List<string>();
            StringBuilder currentWord = new StringBuilder();
            for (int j = 0; j < sentences[i].Length; j++)
            {
                if (char.IsLetterOrDigit(sentences[i][j]))
                {
                    currentWord.Append(sentences[i][j]);
                }
                else
                {
                    words.Add(currentWord.ToString());
                    currentWord.Clear();
                }
            }

            words.Add(currentWord.ToString());

            if (words.Contains(keyWord))
            {
                result.Add(string.Join(" ", words));
                result.Add(". ");
            }
        }

        Console.WriteLine(string.Join("", result).Trim());
    }
}