using System;
using System.Numerics;

internal class EvenDifferences
{
    private static void Main()
    {
        // var reader = new StreamReader(@"D:\C#2\Variant 2 (2015-03-05, Evening)\Problem 2\Tests\test.007.in.txt");
        string[] inputString = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int[] input = new int[inputString.Length];

        for (int i = 0; i < inputString.Length; i++)
        {
            input[i] = int.Parse(inputString[i]);
        }

        BigInteger sumOfEvenDifferences = 0;

        for (int i = 1; i < input.Length; i++)
        {
            BigInteger absDifference = FindAbsDifference(input[i - 1], input[i]);
            if (absDifference % 2 == 0)
            {
                i++;
                sumOfEvenDifferences += absDifference;
            }
        }

        Console.WriteLine("{0}", sumOfEvenDifferences);
    }

    private static BigInteger FindAbsDifference(BigInteger element1, BigInteger element2)
    {
        BigInteger difference = 0;
        if (element1 > element2)
        {
            difference = element1 - element2;
        }
        else
        {
            difference = element2 - element1;
        }

        return difference;
    }
}