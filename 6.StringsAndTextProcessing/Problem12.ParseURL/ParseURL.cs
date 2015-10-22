using System;

internal class ParseURL
{
    // Write a program that parses an URL address given in the format: [protocol]://[server]/[resource] and extracts from it the
    // [protocol], [server] and [resource] elements.
    private static void Main()
    {
        string url = @"http://telerikacademy.com/Courses/Courses/Details/212";
        string otherURL = @"file:///C:/Users/BOSS/Desktop/StringsAndTextProcessing.html";
        string anotherURL = @"http://markovood.eu/";

        Console.WriteLine(url);
        Console.WriteLine(new string('-', 25));
        PrintURLInfo(url);

        Console.WriteLine(new string('*', 25));

        Console.WriteLine(otherURL);
        Console.WriteLine(new string('-', 25));
        PrintURLInfo(otherURL);

        Console.WriteLine(new string('*', 25));

        Console.WriteLine(anotherURL);
        Console.WriteLine(new string('-', 25));
        PrintURLInfo(anotherURL);
    }

    private static void PrintURLInfo(string url)
    {
        string protocol = url.Substring(0, url.IndexOf(':'));
        Console.WriteLine("{0,9} {1}", "PROTOCOL:", protocol);

        int serverStrStart = protocol.Length + 3;   // +3 comes from '://'
        int serverStrEnd = url.IndexOf('/', serverStrStart);
        string server = url.Substring(serverStrStart, serverStrEnd - serverStrStart);

        if (server == string.Empty)    // this handles some special cases 
        {
            server = "local host";
        }

        Console.WriteLine("{0,9} {1}", "SERVER:", server);

        string resource = url.Substring(serverStrEnd);

        if (resource == "/")    // this handles some special cases 
        {
            resource = "index file/page";
        }

        Console.WriteLine("{0,9} {1}", "RESOURCE:", resource);
    }
}