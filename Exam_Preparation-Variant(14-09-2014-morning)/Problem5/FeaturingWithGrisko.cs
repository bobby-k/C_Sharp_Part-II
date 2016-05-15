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
        HashSet<string> generatedWords = new HashSet<string>();

        

        return generatedWords.ToList();
    }

    private static List<string> GetWordsNeeded(List<string> generatedWords)
    {
        var wordsNeeded = new List<string>();

        

        return wordsNeeded;
    }
}
