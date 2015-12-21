using System.Collections.Generic;
using System.IO;

internal class SaveSortedNames
{
    // Write a program that reads a text file containing a list of strings, sorts them and saves them to another text file.
    private static void Main()
    {
        string pathIn = @"..\..\Files\input.txt";
        string pathOut = @"..\..\Files\output.txt";
        var fileContent = GetFileContent(pathIn);
        var sortedContent = SortFileContent(fileContent);
        PrintToFile(pathOut, sortedContent);
    }

    private static List<string> GetFileContent(string path)
    {
        var fileContent = new List<string>();
        var reader = new StreamReader(path);

        using (reader)
        {
            string line = reader.ReadLine();
            while (line != null)
            {
                fileContent.Add(line);

                line = reader.ReadLine();
            }
        }

        return fileContent;
    }

    private static List<string> SortFileContent(List<string> content)
    {
        content.Sort();

        return content;
    }

    private static void PrintToFile(string path, List<string> content)
    {
        var writer = new StreamWriter(path);

        using (writer)
        {
            for (int i = 0; i < content.Count; i++)
            {
                writer.WriteLine(content[i]);
            }
        }
    }
}