using System;

internal class IntegerCalculations
{
    // Write methods to calculate minimum, maximum, average, sum and product of given set of integer numbers.
    // Use variable number of arguments.

    private static void Main()
    {
        GetMin(9, 1, 7, -11, 6, 0, -3, 2);
        Console.WriteLine(new string('*', 55));
        GetMax(9, 1, 6, 0, -3, 2);
        Console.WriteLine(new string('*', 55));
        Average(9, 1, 7, -11, 6, 0, -3, 2, 18, 4);
        Console.WriteLine(new string('*', 55));
        Sum(9, 1, 7, -11, 6, 0, -3, 2);
        Console.WriteLine(new string('*', 55));
        Product(9, 1, 7, -11, 6, -3, 2);
    }

    private static void GetMin(params int[] numbers)
    {
        int min = numbers[0];
        foreach (int number in numbers)
        {
            if (number < min)
            {
                min = number;
            }
        }
        Console.WriteLine(string.Join(", ", numbers));
        Console.WriteLine("The minimal number among the given integers is: {0}", min);
    }

    private static void GetMax(params int[] numbers)
    {
        int max = numbers[0];
        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }
        Console.WriteLine(string.Join(", ", numbers));
        Console.WriteLine("The maximal number among the given integers is: {0}", max);
    }

    private static void Average(params int[] numbers)
    {
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }
        double average = sum / (double)numbers.Length;
        Console.WriteLine(string.Join(", ", numbers));
        Console.WriteLine("The average of the given integers is: {0}", average);
    }

    private static void Sum(params int[] numbers)
    {
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }
        Console.WriteLine(string.Join(", ", numbers));
        Console.WriteLine("The sum of the given numbers is: {0}", sum);
    }

    private static void Product(params int[] numbers)
    {
        int product = 1;
        foreach (int number in numbers)
        {
            product *= number;
        }
        Console.WriteLine(string.Join(", ", numbers));
        Console.WriteLine("The product of the given integers is: {0}", product);
    }
}