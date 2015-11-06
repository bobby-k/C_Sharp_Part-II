using System;
using System.Text;

internal class ExtractTextFromHTML
{
    // Write a program that extracts from given HTML file its title (if available), and its body text without the HTML tags.
    private static void Main()
    {
        string html = "<html><head><title>News</title></head><body><p><a href=\"http://academy.telerik.com\">Telerik Academy</a> aims to provide free real-world practical training</p><p>for young people who want to turn into skilful <a href=\"#\">.NET</a> software engineers.</p></body></html>";
        // TODO: Throw exceptions if any tag is not opened/closed properly or missing
        string title = GetTitleContent(html);
        string textFromBody = GetTextFromBody(html);

        Console.WriteLine(title);
        Console.WriteLine(ReplaceInlineTags(textFromBody));
    }

    private static string GetTitleContent(string html)
    {
        string titleOpnTag = "<title>";
        string titleClsTag = "</title>";

        StringBuilder title = new StringBuilder();

        int indexTitleStart = html.IndexOf(titleOpnTag);
        int indexTitleEnd = html.IndexOf(titleClsTag);

        // check if title tag doesn't exist or it's empty
        if (indexTitleStart < 0 || html.Substring(indexTitleStart + titleOpnTag.Length, titleClsTag.Length) == titleClsTag)
        {
            title.Append("No Title");
        }
        else
        {
            for (int i = indexTitleStart + titleOpnTag.Length; i < indexTitleEnd; i++)
            {
                title.Append(html[i]);
            }
        }

        return title.ToString();
    }

    private static string GetTextFromBody(string html)
    {
        StringBuilder textFromBody = new StringBuilder(html.Length);

        string bodyOpnTag = "<body>";
        string bodyClsTag = "</body>";
        string pOpnTag = "<p>";
        string pClsTag = "</p>";

        int indexBodyStart = html.IndexOf(bodyOpnTag);
        int indexBodyEnd = html.IndexOf(bodyClsTag);

        int newPTagIndex = indexBodyStart + bodyOpnTag.Length;
        for (int i = indexBodyStart + bodyOpnTag.Length; i < indexBodyEnd; i++)
        {
            StringBuilder textFromParagraph = new StringBuilder();
            int pTagIndexStart = html.IndexOf(pOpnTag, newPTagIndex);
            int pTagIndexEnd = html.IndexOf(pClsTag, newPTagIndex);

            for (int j = pTagIndexStart + pOpnTag.Length; j < pTagIndexEnd; j++)
            {
                textFromParagraph.Append(html[j]);
            }

            // separates text from all paragraphs by new line
            if (textFromBody.Length != 0)
            {
                textFromBody.Append("\r\n");
                textFromBody.Append(textFromParagraph);
            }
            else
            {
                textFromBody.Append(textFromParagraph);
            }

            i = pTagIndexEnd;
            newPTagIndex = html.IndexOf(pOpnTag, i);
            if (newPTagIndex == -1)
            {
                break;
            }
        }

        return textFromBody.ToString();
    }

    private static string ReplaceInlineTags(string text)
    {
        string aOpnTag = "<a"; // opening tag must be only '<a' to collect any attributes in the tag
        string aOpnTag1 = ">";
        string aClsTag = "</a>";
        StringBuilder planeText = new StringBuilder();

        // find 'a' tags
        int aOpnIndex = text.IndexOf(aOpnTag);
        int aOpnIndex1 = text.IndexOf(aOpnTag1);

        // add to planeText everything without the in-line tags and their attributes
        if (aOpnIndex == -1)
        {
            return text;
        }
        else
        {
            for (int i = 0; i < text.Length; i++)
            {
                if (i == text.IndexOf(aOpnTag, i))
                {
                    i = text.IndexOf(aOpnTag1, i) + aOpnTag1.Length;
                }

                planeText.Append(text[i]);
            }

            planeText.Replace(aClsTag, string.Empty);
        }

        return planeText.ToString();
    }
}