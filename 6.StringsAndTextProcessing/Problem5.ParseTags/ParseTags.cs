using System;
using System.Text;

internal class ParseTags
{
    // You are given a text. Write a program that changes the text in all regions surrounded by the tags
    // <upcase>and</upcase>
    // to upper-case. The tags cannot be nested.

    private static void Main()
    {
        string text = "We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";

        text = GetTagsDone(text);
        Console.WriteLine(text);
    }

    private static string GetTagsDone(string text)
    {
        StringBuilder modifiedText = new StringBuilder();

        string openingTag = "<upcase>";
        string closingTag = "</upcase>";

        for (int i = 0; i < text.Length; i++) // go through the whole text
        {
            if (text[i] == '<')
            {
                if (text.Substring(i, openingTag.Length) == openingTag) // if this is the opening tag collect the text until the closing tag
                {
                    StringBuilder textInTag = new StringBuilder();

                    i += openingTag.Length;
                    while (text[i] != '<' && text.Substring(i, closingTag.Length) != closingTag)
                    {
                        textInTag.Append(text[i]);
                        i++;
                    }

                    modifiedText.Append(textInTag.ToString().ToUpper());// add collected text to the rest - in upper case
                    i += closingTag.Length - 1; // -1 gets us back on the wright position having in mind that 'i' will increase in the 'for' cycle block
                }
            }
            else modifiedText.Append(text[i]);
        }

        return modifiedText.ToString();
    }
}