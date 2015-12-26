using System;
using System.IO;

internal class ReplaceWholeWord
{
    // Modify the solution of the previous problem to replace only whole words (not strings).
    private static void Main()
    {
        string pathIn = @"..\..\Files\input.txt";
        string pathOut = @"..\..\Files\output.txt";

        string oldWord = "start";
        string newWord = "finish";

        var reader = new StreamReader(pathIn);
        var writer = new StreamWriter(pathOut);

        Console.WriteLine("Replacing...");
        try
        {
            using (reader)
            {
                using (writer)
                {
                    string line = reader.ReadLine();

                    while (line != null)
                    {
                        string[] words = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                        for (int i = 0; i < words.Length; i++)
                        {
                            if (words[i] == oldWord)
                            {
                                words[i] = newWord;
                            }
                        }

                        line = string.Join(" ", words);

                        writer.WriteLine(line);

                        line = reader.ReadLine();
                    }
                }
            }

            Console.WriteLine("Job completed successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Job was aborted and result is incomplete...\nPlease debug to find the problem." + "\n\nHint: {0}" + "\n\n{1}", ex.Message, ex.StackTrace);
        }
    }
}