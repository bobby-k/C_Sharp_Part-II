using System;
using System.IO;
using System.Security;
using System.Text;

internal class ReadFileContents
{
    // Write a program that enters file name along with its full file path (e.g. C:\WINDOWS\win.ini), reads its contents and prints it
    // on the console. Find in MSDN how to use System.IO.File.ReadAllText(…). Be sure to catch all possible exceptions and print
    // user-friendly error messages.
    private static void Main()
    {
        Console.WriteLine("Enter the full path to the file including it");
        string path = Console.ReadLine();

        Console.Clear();
        ReadFileContent(path);
    }

    private static void ReadFileContent(string path)
    {
        try
        {
            string content = File.ReadAllText(path, Encoding.Default);
            Console.WriteLine(content);
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
        catch (PathTooLongException ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("Try again!");
            Main();
        }
        catch (DirectoryNotFoundException ex)
        {
            Console.WriteLine(ex.Data);
            Console.WriteLine("Try again!");
            Main();
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("Try again!");
            Main();
        }
        catch (IOException ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("Try again!");
            Main();
        }
        catch (UnauthorizedAccessException ex)
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
        catch (SecurityException ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("Try again!");
            Main();
        }
    }
}