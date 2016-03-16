using System;
using System.Numerics;

internal class LoverOf2
{
    private static BigInteger[,] matrix;
    private static bool[,] checkMatrix;
    private static BigInteger sum;
    private static int currentCol;
    private static int currentRow;

    private static void Main()
    {
        // var reader = new StreamReader(@"D:\C#2\Variant 3 (2015-03-06, Morning)\Problem 3\Lover-of-2-tests\test.020.in.txt");
        int totalNumRows = int.Parse(Console.ReadLine());   // reader
        int totalNumCols = int.Parse(Console.ReadLine());

        // initialize values for matrices, sum, currentRow, currentCol
        Initialization(totalNumRows, totalNumCols);

        int numOfMoves = int.Parse(Console.ReadLine());
        string[] codes = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        int coefficient = Math.Max(totalNumRows, totalNumCols);
        for (int currentCodeIndex = 0; currentCodeIndex < codes.Length; currentCodeIndex++)
        {
            int row = int.Parse(codes[currentCodeIndex]) / coefficient;
            int col = int.Parse(codes[currentCodeIndex]) % coefficient;

            // determine which direction to go
            string upOrDown = CheckUpOrDown(row);
            switch (upOrDown)
            {
                case "down":
                    GoDown(row);
                    break;

                default:
                    GoUp(row);
                    break;
            }

            string leftOrRight = CheckLeftOrRight(col);
            switch (leftOrRight)
            {
                case "left":
                    GoLeft(col);
                    break;

                default:
                    GoRight(col);
                    break;
            }
        }

        Console.WriteLine(sum);
    }

    private static string CheckLeftOrRight(int col)
    {
        if (col < currentCol)
        {
            return "left";
        }
        else
        {
            return "right";
        }
    }

    private static string CheckUpOrDown(int row)
    {
        if (row > currentRow)
        {
            return "down";
        }
        else
        {
            return "up";
        }
    }

    private static void GoUp(int toRow)
    {
        // check for cases when row is outside the matrix by the upper margin
        if (toRow < 0)
        {
            toRow = 0;
        }

        for (int i = currentRow; i >= toRow; i--)
        {
            if (checkMatrix[i, currentCol] == false)
            {
                sum += matrix[i, currentCol];
                checkMatrix[i, currentCol] = true;
            }

            currentRow = i;
        }
    }

    private static void GoDown(int toRow)
    {
        // check for cases when row is outside the matrix by the down margin
        int maxRow = matrix.GetLength(0) - 1;
        if (toRow > maxRow)
        {
            toRow = maxRow;
        }

        for (int i = currentRow; i <= toRow; i++)
        {
            if (checkMatrix[i, currentCol] == false)
            {
                sum += matrix[i, currentCol];
                checkMatrix[i, currentCol] = true;
            }

            currentRow = i;
        }
    }

    private static void GoLeft(int toCol)
    {
        // check for cases when row is outside the matrix on the left
        if (toCol < 0)
        {
            toCol = 0;
        }

        for (int i = currentCol; i >= toCol; i--)
        {
            if (checkMatrix[currentRow, i] == false)
            {
                sum += matrix[currentRow, i];
                checkMatrix[currentRow, i] = true;
            }

            currentCol = i;
        }
    }

    private static void GoRight(int toCol)
    {
        // check for cases when row is outside the matrix on the right
        int maxCol = matrix.GetLength(1) - 1;
        if (toCol > maxCol)
        {
            toCol = maxCol;
        }

        for (int i = currentCol; i <= toCol; i++)
        {
            if (checkMatrix[currentRow, i] == false)
            {
                sum += matrix[currentRow, i];
                checkMatrix[currentRow, i] = true;
            }

            currentCol = i;
        }
    }

    private static void Initialization(int totalNumRows, int totalNumCols)
    {
        checkMatrix = new bool[totalNumRows, totalNumCols];
        sum = 0;
        matrix = new BigInteger[totalNumRows, totalNumCols];
        currentCol = 0;
        currentRow = matrix.GetLength(0) - 1;

        BigInteger currentCell = 1;
        for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = currentCell;
                currentCell *= 2;
            }

            currentCell = matrix[i, 1];
        }
    }
}