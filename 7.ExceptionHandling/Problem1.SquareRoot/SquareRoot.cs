using System;

internal class SquareRoot
{
    // Write a program that reads a number and calculates and prints its square root. If the number is invalid or
    // negative, print Invalid number. In all cases finally print Good bye. Use try-catch-finally block.
    private static void Main()
    {
        //Console.Write("Please enter a number here: ");

        try
        {
            double num = double.Parse(Console.ReadLine());
            if (num < 0)
            {
                throw new ArgumentException();
            }
            else
            {
                double result = Math.Sqrt(num);
                Console.WriteLine("{0:F3}", result);
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