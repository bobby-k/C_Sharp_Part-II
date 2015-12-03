using System;
using System.Net;

internal class DownloadFile
{
    // Write a program that downloads a file from Internet (e.g. Ninja image) and stores it the current directory. Find in Google how
    // to download files in C#. Be sure to catch all exceptions and to free any used resources in the finally block.
    private static void Main()
    {
        Console.WriteLine("Enter the file (name and extension) to download");
        string file = Console.ReadLine();   // news-img01.png

        Console.WriteLine("Enter the address to that file");
        string URL = Console.ReadLine();    // http://telerikacademy.com/Content/Images/news-img01.png

        WebClient wc = new WebClient();
        try
        {
            wc.DownloadFile(URL, file);

            Console.Clear();
            Console.WriteLine("DONE");
            Console.WriteLine("(file is saved in the application's start directory)");
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("Try again!");
            Main();
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("Try again!");
            Main();
        }
        catch (WebException ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("Try again!");
            Main();
        }
        catch (NotSupportedException ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("Try again!");
            Main();
        }
        finally
        {
            wc.Dispose();
        }
    }
}