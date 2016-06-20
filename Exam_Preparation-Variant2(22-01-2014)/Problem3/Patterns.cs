using System;
using System.Collections.Generic;

internal class Patterns
{
    private const int PATTERN_WIDTH = 4;     // because it starts from 0
    private const int PATTERN_HEIGHT = 2;    // because it starts from 0
    private static int[,] matrix;

    private static void Main()
    {
        int numOfRowsAndCols = int.Parse(Console.ReadLine());
        InitializeMatrix(numOfRowsAndCols);

        long biggestSum = FindBiggestSum();
        PrintResult(biggestSum, numOfRowsAndCols);
    }

    private static void InitializeMatrix(int numOfRowsAndCols)
    {
        matrix = new int[numOfRowsAndCols, numOfRowsAndCols];

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            string[] colsValues = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = int.Parse(colsValues[j]);
            }
        }
    }

    private static long FindBiggestSum()
    {
        var patternsSums = new List<long>();
        long sum = 0L;
        for (int i = 0; i < matrix.GetLength(0) - PATTERN_HEIGHT; i++)
        {
            for (int j = 0; j < matrix.GetLength(1) - PATTERN_WIDTH; j++)
            {
                int A = matrix[i, j];
                int B = matrix[i, j + 1];
                int C = matrix[i, j + 2];
                int D = matrix[i + 1, j + 2];
                int F = matrix[i + 2, j + 2];
                int E = matrix[i + 2, j + 3];
                int G = matrix[i + 2, j + 4];

                if (A == B - 1 &&
                    B == C - 1 &&
                    C == D - 1 &&
                    D == F - 1 &&
                    F == E - 1 &&
                    E == G - 1)
                {
                    sum = A + B + C + D + F + E + G;
                    patternsSums.Add(sum);
                }
                else
                {
                    continue;
                }
            }
        }

        if (patternsSums.Count > 0)
        {
            long[] patternSumsAsArray = patternsSums.ToArray();
            Array.Sort(patternSumsAsArray);

            return patternSumsAsArray[patternsSums.Count - 1];
        }
        else
        {
            return long.MaxValue;
        }
    }

    private static void PrintResult(long biggestSum, int diagonalLength)
    {
        if (biggestSum == long.MaxValue)
        {
            long sumOfMainDiagonal = 0;
            for (int i = 0; i < diagonalLength; i++)
            {
                sumOfMainDiagonal += matrix[i, i];
            }

            Console.WriteLine("NO {0}", sumOfMainDiagonal);
        }
        else
        {
            Console.WriteLine("YES {0}", biggestSum);
        }
    }
}