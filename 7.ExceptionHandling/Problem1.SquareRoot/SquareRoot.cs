using System;

internal class SquareRoot
{
    // Write a program that reads an integer number and calculates and prints its square root. If the number is invalid or negative,
    // print Invalid number. In all cases finally print Good bye. Use try-catch-finally block.
    private static void Main()
    {
        //Console.Write("Please enter an integer number here: ");

        try
        {
            int num = int.Parse(Console.ReadLine());
            if (num < 0)
            {
                throw new ArgumentException();
            }
            else
            {
                double result = Math.Sqrt(num);
                Console.WriteLine("{0:N3}",result);
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid number");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("Invalid number");
        }
        finally
        {
            Console.WriteLine("Good bye");
        }
    }
}