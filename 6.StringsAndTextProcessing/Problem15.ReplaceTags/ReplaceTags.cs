using System;
using System.Text;

internal class ReplaceTags
{
    // Write a program that replaces in a HTML document given as string all the tags
    // <a href="URL">TEXT</a>
    // with corresponding markdown notation [TEXT](URL).
    private static void Main()
    {
        string html = Console.ReadLine();

        html = TagsReplace(html);
        Console.WriteLine(html);
    }

    private static string TagsReplace(string someHTML)
    {
        string openingTagOld1 = "<a href=\"";
        string openingTagOld2 = "\">";
        string closingTagOld = "</a>";

        string openingTagNew = "[";
        string closingTagNew = "]";

        someHTML = someHTML.Replace(openingTagOld1, openingTagNew);
        someHTML = someHTML.Replace(closingTagOld, closingTagNew);

        int positionCounter = 0;
        for (int i = positionCounter; i < someHTML.Length; i++)
        {
            StringBuilder url = new StringBuilder();
            int startIndex = someHTML.IndexOf(openingTagNew, positionCounter);
            int endIndex = someHTML.IndexOf(openingTagOld2, positionCounter);
            for (int j = startIndex + 1; j < endIndex; j++)
            {
                url.Append(someHTML[j]);
            }

            someHTML = someHTML.Remove(startIndex + 1, url.Length + openingTagOld2.Length);
            int insertPosition = someHTML.IndexOf(closingTagNew,positionCounter);
            someHTML = someHTML.Insert(insertPosition + 1, string.Format("({0})", url));
            positionCounter = insertPosition + url.Length;
            i += positionCounter;
        }

        return someHTML;
    }
}