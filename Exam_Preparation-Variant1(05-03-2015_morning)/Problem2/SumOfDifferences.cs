using System;
using System.Numerics;

internal class SumOfDifferences
{
    private static void Main()
    {
        string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        int[] numbers = new int[input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            numbers[i] = int.Parse(input[i]);
        }

        BigInteger sumOddDifferences = 0;

        for (int i = 1; i < numbers.Length; )
        {
            BigInteger difference = FindAbsoluteDifference(numbers[i], numbers[i - 1]);

            if (difference % 2 != 0)
            {
                sumOddDifferences += difference;
                i++;
            }
            else
            {
                i += 2;
            }
        }

        Console.WriteLine("{0}", sumOddDifferences);
    }

    private static BigInteger FindAbsoluteDifference(int num1, int num2)
    {
        BigInteger absoluteDifference = 0;
        BigInteger currentNum = (BigInteger)num1;
        BigInteger previousNum = (BigInteger)num2;

        if (currentNum > previousNum)
        {
            absoluteDifference = currentNum - previousNum; ;
        }
        else
        {
            absoluteDifference = previousNum - currentNum;
        }

        return absoluteDifference;
    }
}