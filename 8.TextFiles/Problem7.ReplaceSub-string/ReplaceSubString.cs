using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

class ReplaceSubString
{
    // Write a program that replaces all occurrences of the sub-string start with the sub-string finish in a text file. Ensure it will
    // work with large files (e.g. 100 MB).
    static void Main()
    {
        string path = @"..\..\Files\input.txt";

        string old = "start";
        string _new = "finish";

        var reader = new StreamReader(path);

        using (reader)
        {
            string line = reader.ReadLine();

            while (line != null)
            {
                line.Replace()

                line = reader.ReadLine();
            }
        }
    }


}
