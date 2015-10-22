using System;
using System.Linq;
using System.Text;

internal class ReverseSentence
{
    // Write a program that reverses the words in given sentence.
    private static void Main()
    {
        Console.WriteLine("Type some sentence here:");
        string sentence = Console.ReadLine();

        char[] signs = { ' ', '.', ',', '-', '!', '?', ';', ':' };

        // find all words in the sentence
        string[] words = sentence.Split(signs, StringSplitOptions.RemoveEmptyEntries);

        // find all punctuation marks in the sentence(when the splitter is string[] that doesn't include space as element in it, it
        // will give the result with the spaces as separate elements)
        string[] sentenceTemplate = sentence.Split(words, StringSplitOptions.RemoveEmptyEntries); // this will include the spaces

        words = words.Reverse().ToArray();

        // construct the reversed sentence
        var reversedSentence = new StringBuilder();
        for (int i = 0; i < sentenceTemplate.Length; i++)
        {
            reversedSentence.Append(words[i]);
            reversedSentence.Append(sentenceTemplate[i]);
        }

        Console.WriteLine(reversedSentence);
    }
}