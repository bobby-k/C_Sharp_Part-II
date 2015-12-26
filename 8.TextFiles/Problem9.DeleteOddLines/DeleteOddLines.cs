using System;
using System.Collections.Generic;
using System.IO;

internal class DeleteOddLines
{
    // Write a program that deletes from given text file all odd lines. The result should be in the same file.
    private static void Main()
    {
        string pathIn = @"..\..\Files\input.txt";

        var fileEvenLines = new List<string>();
        Console.WriteLine("Deleting odd lines...");
        try
        {
            var reader = new StreamReader(pathIn);

            using (reader)
            {
                string line = reader.ReadLine();
                int counter = 1;

                while (line != null)
                {
                    if (counter % 2 == 0)
                    {
                        fileEvenLines.Add(line);
                    }

                    counter++;

                    line = reader.ReadLine();
                }
            }

            var writer = new StreamWriter(pathIn);

            using (writer)
            {
                for (int i = 0; i < fileEvenLines.Count; i++)
                {
                    writer.WriteLine(fileEvenLines[i]);
                }
            }

            Console.WriteLine("Done!!!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Job is incomplete!\nPlease debug to find the problem\n\nHint: {0}\n\n{1}", ex.Message, ex.StackTrace);
        }
    }
}