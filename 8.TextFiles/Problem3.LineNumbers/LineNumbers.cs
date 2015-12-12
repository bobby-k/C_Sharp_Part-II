using System.IO;
using System.Text;

internal class LineNumbers
{
    // Write a program that reads a text file and inserts line numbers in front of each of its lines. The result should be written to
    // another text file.
    private static void Main()
    {
        StreamReader reader = new StreamReader(@"..\..\Files\text.txt", Encoding.Default);
        StreamWriter writer = new StreamWriter(@"..\..\Files\updatedText.txt");

        using (writer)
        {
            using (reader)
            {
                int lineNumber = 1;
                string line = reader.ReadLine();

                while (line != null)
                {
                    writer.WriteLine("{0:D2}|{1}", lineNumber, line);

                    line = reader.ReadLine();
                    lineNumber++;
                }
            }
        }
    }
}