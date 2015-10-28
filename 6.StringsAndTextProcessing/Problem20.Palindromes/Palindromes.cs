using System;

internal class Palindromes
{
    // Write a program that extracts from a given text all palindromes, e.g. ABBA, lamal, exe.
    private static void Main()
    {
        string text = "a Honda civic deified deleveled devoved dewed Hannah kayak level madam radar racecar refer rotor solos ABBA exe lamal this is not a palindrome";

        // find every single word by splitting by any punctuation mark + space
        string[] words = text.Split(new char[] { ' ', '.', ',', '-', '!', '?', ';', ':' }, StringSplitOptions.RemoveEmptyEntries);

        Console.WriteLine("Palindromes found:");
        foreach (var word in words)
        {
            if (IsPalindrome(word))
            {
                Console.WriteLine(word);
            }
        }
    }

    private static bool IsPalindrome(string word)
    {
        bool equal = false;
        for (int i = 0, j = word.Length - 1; i < word.Length / 2; i++, j--)
        {
            if (word[i] == word[j]) // this is case sensitive to be insensitive make each char.ToLower()
            {
                equal = true;
            }
            else
            {
                break;
            }
        }

        return equal;
    }
}