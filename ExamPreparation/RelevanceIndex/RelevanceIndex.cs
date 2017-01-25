namespace RelevanceIndex
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class RelevanceIndex
    {
        private static void Main()
        {
            // input
            string searchWord = Console.ReadLine().ToLower().Trim();
            int numbOfParagraphs = int.Parse(Console.ReadLine());
            string[] text = new string[numbOfParagraphs];
            for (int i = 0; i < numbOfParagraphs; i++)
            {
                string currentParagraph = Console.ReadLine();
                text[i] = currentParagraph;
            }

            // solution ",", ".", "(", ")", ";", "-", "!", "?"
            SortedDictionary<int, string> textWithRelevanceIndex = new SortedDictionary<int, string>();
            for (int i = 0; i < text.Length; i++)
            {
                string[] paragraphWords = text[i].Split(new[] { ' ', ',', '.', '(', ')', ';', '-', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
                int relevanceIndex = GetRelIndex(searchWord, paragraphWords);
                paragraphWords = ProcessParagraph(paragraphWords, searchWord);
                string processedParagraph = string.Join(" ", paragraphWords);
                textWithRelevanceIndex.Add(relevanceIndex, processedParagraph);
            }

            foreach (var item in textWithRelevanceIndex.Reverse())
            {
                Console.WriteLine(item.Value);
            }
        }

        private static string[] ProcessParagraph(string[] paragraphWords, string searchedWord)
        {
            for (int i = 0; i < paragraphWords.Length; i++)
            {
                if (paragraphWords[i].ToLower() == searchedWord)
                {
                    paragraphWords[i] = searchedWord.ToUpper();
                }
            }

            return paragraphWords;
        }

        private static int GetRelIndex(string searchWord, string[] paragraphWords)
        {
            int counter = 0;
            for (int i = 0; i < paragraphWords.Length; i++)
            {
                if (paragraphWords[i].ToLower() == searchWord)
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}