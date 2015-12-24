using System;
using System.IO;

internal class ReplaceSubString
{
    // Write a program that replaces all occurrences of the sub-string start with the sub-string finish in a text file. Ensure it will
    // work with large files (e.g. 100 MB).
    private static void Main()
    {
        string pathIn = @"..\..\Files\input.txt";
        string pathOut = @"..\..\Files\output.txt";

        string oldSubStr = "start";
        string newSubStr = "finish";

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
                        line = line.Replace(oldSubStr, newSubStr);  // replace all occurrences of the oldSubStr with newSubStr within the current line read
                        writer.WriteLine(line); // write the replaced line into a new file

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