using System;
using System.Collections.Generic;

internal class IncreasingAbsoluteDifferences
{
    private static void Main()
    {
        int totalNumOfSeq = int.Parse(Console.ReadLine());

        for (int currentSeq = 0; currentSeq < totalNumOfSeq; currentSeq++)
        {
            string sequence = Console.ReadLine();

            bool isIncreasingSeq = CheckIfIsIncreasingSeq(sequence);

            Console.WriteLine("{0}", isIncreasingSeq);
        }
    }

    private static bool CheckIfIsIncreasingSeq(string sequence)
    {
        var listOfAbsoluteDifferences = GetListOfAbsoluteDifferences(sequence);
        int difference = 0;

        for (int i = 0; i < listOfAbsoluteDifferences.Count; i++)
        {
            if (i == listOfAbsoluteDifferences.Count - 1)
            {
                break;
            }
            else if (listOfAbsoluteDifferences[i] <= listOfAbsoluteDifferences[i + 1])
            {
                difference = listOfAbsoluteDifferences[i + 1] - listOfAbsoluteDifferences[i];
                if (difference == 0 || difference == 1)
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }
            else if (listOfAbsoluteDifferences[i] > listOfAbsoluteDifferences[i + 1])
            {
                return false;
            }
        }

        return true;
    }

    private static List<int> GetListOfAbsoluteDifferences(string sequence)
    {
        var list = new List<int>();
        string[] seqNumsAsStr = sequence.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int[] seqNums = new int[seqNumsAsStr.Length];

        for (int i = 0; i < seqNumsAsStr.Length; i++)
        {
            seqNums[i] = int.Parse(seqNumsAsStr[i]);
        }

        for (int i = 1; i < seqNums.Length; i++)
        {
            if (seqNums[i - 1] > seqNums[i])
            {
                list.Add(seqNums[i - 1] - seqNums[i]);
            }
            else
            {
                list.Add(seqNums[i] - seqNums[i - 1]);
            }
        }

        return list;
    }
}