using System;
using System.IO;
using System.Text;

internal class OddLines
{
    // Write a program that reads a text file and prints on the console its odd lines.
    private static void Main()
    {
        string path = @"..\..\Files\text.txt";
        var reader = new StreamReader(path, Encoding.Default);

        using (reader)
        {
            int lineCount = 1;
            string line = reader.ReadLine();

            while (line != null)
            {
                if (lineCount % 2 != 0)
                {
                    Console.WriteLine("LINE {0}: {1}", lineCount, line);
                }
                lineCount++;
                line = reader.ReadLine();
            }
        }
    }
}