using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ExtractTextFromHTML
{
    // Write a program that extracts from given HTML file its title (if available), and its body text without the HTML tags.
    static void Main()
    {
        string titleOpnTag = "<title>";
        string titleClsTag = "</title>";
        string bodyOpnTag = "<body>";
        string bodyClsTag = "</body>";
        string html = "<html><head><title>News</title></head><body><p><a href=\"http://academy.telerik.com\">Telerik Academy</a>aims to provide free real-world practical training for young people who want to turn into skilful .NET software engineers.</p></body></html>";

        StringBuilder title = new StringBuilder();
        StringBuilder textFromBody = new StringBuilder(html.Length);

        int indexTitleStart = html.IndexOf(titleOpnTag);
        int indexTitleEnd = html.IndexOf(titleClsTag);


        if (indexTitleStart < 0 || html.Substring(indexTitleStart + 7, titleClsTag.Length) == titleClsTag)
        {
            title.Append("No Title");
        }
        else
        {
            for (int i = indexTitleStart + 7; i < indexTitleEnd; i++)
            {
                title.Append(html[i]);
            }
        }
    }
}
