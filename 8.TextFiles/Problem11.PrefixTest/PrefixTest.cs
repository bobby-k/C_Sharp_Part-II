using System;
using System.IO;
using System.Text;

internal class PrefixTest
{
    // Write a program that deletes from a text file all words that start with the prefix test. Words contain only the symbols 0...9,
    // a...z, A...Z, _.
    private static void Main()
    {
        string pathIn = @"..\..\Files\testPrefix.txt";
        string pathOut = @"..\..\Files\output.txt";

        var reader = new StreamReader(pathIn);
        var writer = new StreamWriter(pathOut);

        Console.WriteLine("Deleting...");
        try
        {
            string line = reader.ReadLine();

            using (reader)
            {
                using (writer)
                {
                    while (line != null)
                    {
                        string[] words = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        StringBuilder corectedText = new StringBuilder();

                        for (int i = 0; i < words.Length; i++)
                        {
                            if (!words[i].StartsWith("test") && i == words.Length - 1)
                            {
                                corectedText.Append(words[i]);
                            }
                            else if (!words[i].StartsWith("test"))
                            {
                                corectedText.Append(words[i] + " ");
                            }
                        }

                        writer.WriteLine(corectedText.ToString());

                        line = reader.ReadLine();
                    }
                }
            }

            Console.WriteLine("Done!!!");
            Console.WriteLine("The output was saved in {0}", Path.GetFullPath(pathOut));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Job was aborted and result is incomplete...\nPlease debug to find the problem." + "\n\nHint: {0}" + "\n\n{1}", ex.Message, ex.StackTrace);
        }
    }
}