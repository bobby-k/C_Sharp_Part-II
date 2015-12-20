using System;
using System.Collections.Generic;
using System.IO;

internal class CompareTextFiles
{
    // Write a program that compares two text files line by line and prints the number of lines that are the same and the number of
    // lines that are different. Assume the files have equal number of lines.
    private static void Main()
    {
        var reader = new StreamReader(@"..\..\Files\someTextFile.txt");
        var otherReader = new StreamReader(@"..\..\Files\anotherTextFile.txt");

        List<int> sameLines = new List<int>();
        List<int> differentLines = new List<int>();

        using (reader)
        {
            using (otherReader)
            {
                string lineFromText1 = reader.ReadLine();
                string lineFromText2 = otherReader.ReadLine();
                int lineNumber = 1;

                while (lineFromText1 != null)   // can be either of the text files because they have equal number of lines.
                {
                    if (lineFromText1 == lineFromText2)
                    {
                        sameLines.Add(lineNumber);
                    }
                    else
                    {
                        differentLines.Add(lineNumber);
                    }

                    lineNumber++;

                    lineFromText1 = reader.ReadLine();
                    lineFromText2 = otherReader.ReadLine();
                }
            }
        }

        PrintResult(sameLines, differentLines);
    }

    private static void PrintResult(List<int> sameLines, List<int> differentLines)
    {
        Console.WriteLine(new string('*', 29));
        Console.WriteLine("*File comparison finished...*");
        Console.WriteLine(new string('*', 29));

        if (differentLines.Count == 0)
        {
            Console.WriteLine("\nAll lines are the same...");
        }
        else if (sameLines.Count > 0)
        {
            Console.WriteLine("\nLines {0} are the same", string.Join(", ", sameLines));
            Console.WriteLine("\nLines {0} are different", string.Join(", ", differentLines));
        }
        else
        {
            Console.WriteLine("\nAll lines are different...");
        }
    }
}