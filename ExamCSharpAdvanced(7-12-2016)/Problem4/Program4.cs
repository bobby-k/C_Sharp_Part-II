using System;
using System.Collections.Generic;
using System.Text;

namespace Problem4
{
    internal class Program4
    {
        private static void Main()
        {
            StringBuilder text = new StringBuilder();
            string code = string.Empty;

            // input
            string keyword = Console.ReadLine();
            int numOfLines = int.Parse(Console.ReadLine());

            // collect all text in one place
            for (int i = 0; i < numOfLines; i++)
            {
                string line = Console.ReadLine();
                if (line[line.Length - 1] != '.' || line[line.Length - 1] != '?')
                {
                    text.Append(line + " ");
                }
                else
                {
                    text.Append(line);
                }
            }

            // extract all words
            string[] words = text.ToString().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // find all sentences and all questions
            List<string> sentences = new List<string>();
            List<string> questions = new List<string>();

            StringBuilder currentSentence = new StringBuilder();
            for (int i = 0; i < words.Length; i++)
            {
                int lastCharInd = words[i].Length - 1;
                if (words[i][lastCharInd] == '.')
                {
                    currentSentence.Append(words[i]);
                    sentences.Add(currentSentence.ToString());
                    currentSentence.Clear();
                }
                else if (words[i][lastCharInd] == '?')
                {
                    currentSentence.Append(words[i]);
                    questions.Add(currentSentence.ToString());
                    currentSentence.Clear();
                }
                else
                {
                    currentSentence.Append(words[i] + " ");
                }
            }

            // find the sentence with the keyword
            string keySentence = string.Empty;
            for (int i = 0; i < sentences.Count; i++)
            {
                if (sentences[i].Contains(keyword))
                {
                    keySentence = sentences[i];
                }
            }

            if (keySentence == string.Empty)
            {
                for (int i = 0; i < questions.Count; i++)
                {
                    if (questions[i].Contains(keyword))
                    {
                        keySentence = questions[i];
                    }
                }
            }

            // get the code
            code = GetCode(keySentence, keyword);

            // sum the characters value's
            Summary(code);
        }

        private static string GetCode(string keySentence, string keyword)
        {
            string code = string.Empty;

            switch (keySentence[keySentence.Length - 1])
            {
                case '.':
                    int length = keySentence.IndexOf(keyword);
                    code = keySentence.Substring(0, length);
                    break;

                case '?':
                    int start = keySentence.IndexOf(keyword) + keyword.Length;
                    code = keySentence.Substring(start);
                    code = code.Remove(code.Length - 1);
                    break;
            }

            return code;
        }

        private static void Summary(string theCode)
        {
            int sum = 0;
            string temp = theCode.ToUpper();

            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] != ' ')
                {
                    sum += temp[i];
                }
            }

            Console.WriteLine(sum);
        }
    }
}