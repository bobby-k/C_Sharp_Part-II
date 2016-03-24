using System;
using System.Collections.Generic;
using System.Text;

internal class MagicWords
{
    private static List<string> listOfWords = new List<string>();

    private static void Main()
    {
        int numOfLines = int.Parse(Console.ReadLine());

        for (int i = 0; i < numOfLines; i++)
        {
            string word = Console.ReadLine();
            listOfWords.Add(word);
        }

        Reorder(listOfWords, numOfLines);
        Print(listOfWords);
    }

    private static void Print(List<string> listOfWords)
    {
        int maxLenght = GetMaxLengt(listOfWords);
        int charNum = 0;
        StringBuilder result = new StringBuilder();
        while (charNum <= maxLenght)
        {
            for (int i = 0; i < listOfWords.Count; i++)
            {
                if (listOfWords[i].Length > charNum)
                {
                    result.Append(listOfWords[i][charNum]);
                }
            }

            charNum++;
        }

        Console.WriteLine(result);
    }

    private static int GetMaxLengt(List<string> listOfWords)
    {
        int maxLenght = 0;
        foreach (var item in listOfWords)
        {
            if (item.Length > maxLenght)
            {
                maxLenght = item.Length;
            }
        }

        return maxLenght;
    }

    private static void Reorder(List<string> listOfWords, int n)
    {
        for (int i = 0; i < listOfWords.Count; i++)
        {
            string currentWord = listOfWords[i];
            int position = currentWord.Length % (n + 1);
            listOfWords[i] = null;
            listOfWords.Insert(position, currentWord);
            listOfWords.Remove(null);
        }
    }
}