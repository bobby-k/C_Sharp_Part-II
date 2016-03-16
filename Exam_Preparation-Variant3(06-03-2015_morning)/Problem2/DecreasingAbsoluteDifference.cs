using System;
using System.Collections.Generic;
using System.IO;

internal class DecreasingAbsoluteDifference
{
    private static void Main()
    {
        // var reader = new StreamReader(@"D:\C#2\Variant 3 (2015-03-06, Morning)\Problem 2\Tests\test.010.in.txt");
        int totalNumOfSeqs = int.Parse(Console.ReadLine()); // reader

        for (int seq = 0; seq < totalNumOfSeqs; seq++)
        {
            string[] numbersInput = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // parse to int32
            int[] numbers = new int[numbersInput.Length];
            for (int i = 0; i < numbersInput.Length; i++)
            {
                numbers[i] = int.Parse(numbersInput[i]);
            }

            var listOfAbsDifferences = GetAbsDiffs(numbers);
            bool listOfAbsDiffsIsDecr = CheckIfListIsDecr(listOfAbsDifferences);
            if (listOfAbsDiffsIsDecr)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
        }
    }

    private static bool CheckIfListIsDecr(List<long> listOfAbsDifferences)
    {
        for (int i = 0; i < listOfAbsDifferences.Count - 1; i++)
        {
            if (listOfAbsDifferences[i] - listOfAbsDifferences[i + 1] != 0 && listOfAbsDifferences[i] - listOfAbsDifferences[i + 1] != 1)
            {
                return false;
            }
        }

        return true;
    }

    private static List<long> GetAbsDiffs(int[] numbers)
    {
        var absDiffs = new List<long>();

        for (int i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] > numbers[i - 1])
            {
                absDiffs.Add(numbers[i] - numbers[i - 1]);
            }
            else
            {
                absDiffs.Add(numbers[i - 1] - numbers[i]);
            }
        }

        return absDiffs;
    }
}