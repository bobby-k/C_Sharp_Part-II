using System;
using System.IO;
using System.Text;

internal class ExtractTextFromXML
{
    // Write a program that extracts from given XML file all the text without the tags.
    private static void Main()
    {
        string pathIn = @"..\..\Files\test.xml";
        string pathOut = @"..\..\Files\extractedText.txt";

        Console.WriteLine("Extracting...\n");
        try
        {
            var reader = new StreamReader(pathIn);
            var writer = new StreamWriter(pathOut);

            using (writer)
            {
                using (reader)
                {
                    string line = reader.ReadLine();
                    var extractedText = new StringBuilder();

                    while (line != null)
                    {
                        for (int i = 0; i < line.Length; i++)
                        {
                            if (line[i] == '<')
                            {
                                while (line[i] != '>')  // go to the next '>'
                                {
                                    i++;
                                    continue;
                                }

                                if (i + 1 < line.Length && line[i] != '<')  // if next symbol isn't the end of line and isn't '>'
                                {
                                    while (line[i + 1] != '<')    // take all chars to the next '<'
                                    {
                                        i++;
                                        extractedText.Append(line[i]);
                                    }
                                }
                            }
                        }

                        if (extractedText.Length > 0)
                        {
                            writer.WriteLine(extractedText.ToString());
                            extractedText.Clear();
                        }

                        line = reader.ReadLine();
                    }
                }
            }

            Console.WriteLine("Congratulations!!!\n\nFile was extracted to \"{0}\" in \"{1}\"", Path.GetFileName(pathOut), Path.GetFullPath(pathOut));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Job is incomplete...\nPlease DEBUG...\n\nHint: {0}\n{1}", ex.Message, ex.StackTrace);
        }
    }
}