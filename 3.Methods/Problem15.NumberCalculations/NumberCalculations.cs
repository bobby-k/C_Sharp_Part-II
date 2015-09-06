using System;
using System.Globalization;
using System.Threading;

internal class NumberCalculations
{
    // Modify your last program and try to make it work for any number type, not just integer (e.g. decimal, float, byte, etc.) Use
    // generic method (read in Internet about generic methods in C#).
    private static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        
        GetMin(9, 1, 7, -11, 6, 0, -3, 2);
        GetMin(9, 1.2, 3.5, 7, -1);
        Console.WriteLine(new string('*', 55));
        GetMax(9, 1, 6, 0, -3, 2);
        GetMax(9, 1.2, 3.5, 7, -1);
        Console.WriteLine(new string('*', 55));
        Average(9.5f, 11.1f, 5.5f, 1.2f, -7f, -11f, 0.9f, -1.7f);
        Average(9.5m, 11.1m, 5.5m, 1.2m, -7m, -11m, 0.9m, -1.7m);
        Average(9.5, 11.1, 5.5, 1.2, -7, -11, 0.9, -1.7);
        Average(9, 1, 7, -11, 6, 0, -3, 2, 1, 4);
        Console.WriteLine(new string('*', 55));
        Sum(9, 1, 7, -11, 6, 0, -3, 2);
        Sum(9, 1.2, 3.5, 7, -1);
        Console.WriteLine(new string('*', 55));
        Product(9, 1, 7, -11, 6, -3, 2);
        Product(9, 1.2, 3.5, 7, -1);
    }

    private static void GetMin<T>(params T[] numbers)
    {
        dynamic min = numbers[0];
        foreach (var number in numbers)
        {
            if (number < min)
            {
                min = number;
            }
        }
        Console.WriteLine(string.Join(", ", numbers));
        Console.WriteLine("The minimal number among the given numbers is: {0}", min);
    }

    private static void GetMax<T>(params T[] numbers)
    {
        dynamic max = numbers[0];
        foreach (var number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }
        Console.WriteLine(string.Join(", ", numbers));
        Console.WriteLine("The maximal number among the given numbers is: {0}", max);
    }

    private static void Average<T>(params T[] numbers)
    {
        dynamic sum = 0;
        foreach (var number in numbers)
        {
            sum += number;
        }

        dynamic average = (decimal)sum / numbers.Length;
        Console.WriteLine(string.Join(", ", numbers));
        Console.WriteLine("The average of the given numbers is: {0}", average);
    }

    private static void Sum<T>(params T[] numbers)
    {
        dynamic sum = 0;
        foreach (var number in numbers)
        {
            sum += number;
        }
        Console.WriteLine(string.Join(", ", numbers));
        Console.WriteLine("The sum of the given numbers is: {0}", sum);
    }

    private static void Product<T>(params T[] numbers)
    {
        dynamic product = 1;
        foreach (var number in numbers)
        {
            product *= number;
        }
        Console.WriteLine(string.Join(", ", numbers));
        Console.WriteLine("The product of the given numbers is: {0}", product);
    }
}