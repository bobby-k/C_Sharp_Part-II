using System.IO;

internal class ConcatenateTextFiles
{
    // Write a program that concatenates two text files into another text file.
    private static void Main()
    {
        var reader = new StreamReader(@"..\..\Files\someText.txt");
        var anotherReader = new StreamReader(@"..\..\Files\anotherText.txt");
        var writer = new StreamWriter(@"..\..\Files\concatenatedText.txt");

        using (writer)
        {
            string line = string.Empty;

            using (reader)
            {
                while (line != null)
                {
                    line = reader.ReadLine();
                    writer.WriteLine(line);
                }
            }

            line = string.Empty;

            using (anotherReader)
            {
                while (line != null)
                {
                    line = anotherReader.ReadLine();
                    writer.WriteLine(line);
                }
            }
        }
    }
}