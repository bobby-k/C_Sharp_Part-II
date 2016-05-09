using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class FeaturingWithGrisko
{
    static void Main()
    {
        string letters = Console.ReadLine();

        var generatedWords = GenerateWords(letters);
        var wordsWithNoTwoConsecutiveLetters = GetWordsNeeded(generatedWords);

        Console.WriteLine(wordsWithNoTwoConsecutiveLetters.Count);
    }

    private static List<string> GenerateWords(string letters)
    {
        //var generatedWords = new List<string>();
        HashSet<string> generatedWords = new HashSet<string>();

        for (int i = 0; i < letters.Length; i++)
        {
            StringBuilder currentWord = new StringBuilder(letters);
            char currentChar = letters[i];
            currentWord.Remove(i, 1);
            int index = 0;
            while (index < letters.Length)
            {
                currentWord.Insert(index, currentChar);
                generatedWords.Add(currentWord.ToString());
                currentWord.Remove(index, 1);
                index++;
            }
        }
        return generatedWords.ToList();
    }

    private static List<string> GetWordsNeeded(List<string> generatedWords)
    {
        var wordsNeeded = new List<string>();

        for (int i = 0; i < generatedWords.Count; i++)
        {
            string currentWord = generatedWords[i];
            int index = 0;
            while (index < currentWord.Length - 1)
            {
                if (currentWord[index] == currentWord[index + 1])
                {
                    break;
                }
                else if (index == currentWord.Length - 2 && currentWord[index] != currentWord[index + 1])
                {
                    wordsNeeded.Add(currentWord);
                    index++;
                }
                else
                {
                    index++;
                }
            }
        }

        return wordsNeeded;
    }
}
