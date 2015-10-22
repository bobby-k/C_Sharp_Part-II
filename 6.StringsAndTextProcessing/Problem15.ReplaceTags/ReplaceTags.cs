using System;

internal class ReplaceTags
{
    // Write a program that replaces in a HTML document given as string all the tags
    // <a href="...">...</a>
    // with corresponding tags [URL=...]...[/URL].
    private static void Main()
    {
        string html = "<p>Please visit <a href=\"http://academy.telerik. com\">our site</a> to choose a training course. Also visit <a href=\"www.devbg.org\">our forum</a> to discuss the courses.</p>";

        html = TagsReplace(html);
        Console.WriteLine(html);
    }

    private static string TagsReplace(string someHTML)
    {
        string openingTagOld1 = "<a href=\"";
        string openingTagOld2 = "\">";
        string closingTagOld = "</a>";

        string openingTagNew1 = "[URL=";
        string openingTagNew2 = "]";
        string closingTagNew = "[/URL]";

        someHTML = someHTML.Replace(openingTagOld1, openingTagNew1);
        someHTML = someHTML.Replace(openingTagOld2, openingTagNew2);
        someHTML = someHTML.Replace(closingTagOld, closingTagNew);

        return someHTML;
    }
}