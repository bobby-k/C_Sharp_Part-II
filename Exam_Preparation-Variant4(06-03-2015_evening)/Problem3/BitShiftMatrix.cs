using System;
using System.Numerics;

internal class BitShiftMatrix
{
    // static StreamReader reader = new StreamReader(@"D:\C#2\Variant 4 (2015-03-06, Evening)\Problem 3\Bit-Shift-Matrix-tests\test.005.in.txt");
    private static int rows = int.Parse(Console.ReadLine());    // reader

    private static int cols = int.Parse(Console.ReadLine());
    private static int numOfMoves = int.Parse(Console.ReadLine());
    private static string[] codes = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
    private static bool[,] checkMatrix = new bool[rows, cols];
    private static BigInteger[,] matrix = new BigInteger[rows, cols];
    private static BigInteger sum = 0L;
    private static int currentPositionRow = matrix.GetLength(0) - 1;
    private static int currentPositionCol = 0;

    private static void Main()
    {
        InitializeMatrix();
        int coeff = Math.Max(rows, cols);

        for (int currentMove = 0; currentMove < numOfMoves; currentMove++)
        {
            int row = int.Parse(codes[currentMove]) / coeff;
            int col = int.Parse(codes[currentMove]) % coeff;

            if (col > currentPositionCol)
            {
                // go to the right
                CollectRight(col);
            }
            else if (col < currentPositionCol)
            {
                // go to the left
                CollectLeft(col);
            }

            if (row > currentPositionRow)
            {
                // go down
                CollectDown(row);
            }
            else if (row < currentPositionRow)
            {
                // go up
                CollectUp(row);
            }
        }

        Console.WriteLine("{0}", sum);
    }

    private static void CollectDown(int row)
    {
        for (int i = currentPositionRow; i <= row; i++)
        {
            if (i <= matrix.GetLength(0) - 1 && !checkMatrix[i, currentPositionCol])
            {
                sum += matrix[i, currentPositionCol];
                checkMatrix[i, currentPositionCol] = true;
            }
            else if (i == matrix.GetLength(0))
            {
                break;
            }

            currentPositionRow = i;
        }
    }

    private static void CollectLeft(int col)
    {
        for (int i = currentPositionCol; i >= col; i--)
        {
            if (i >= 0 && !checkMatrix[currentPositionRow, i])
            {
                sum += matrix[currentPositionRow, i];
                checkMatrix[currentPositionRow, i] = true;
            }
            else if (currentPositionCol < 0)
            {
                break;
            }

            currentPositionCol = i;
        }
    }

    private static void CollectUp(int row)
    {
        for (int i = currentPositionRow; i >= row; i--)
        {
            if (i >= 0 && !checkMatrix[i, currentPositionCol])
            {
                sum += matrix[i, currentPositionCol];
                checkMatrix[i, currentPositionCol] = true;
            }
            else if (i < 0)
            {
                break;
            }

            currentPositionRow = i;
        }
    }

    private static void CollectRight(int col)
    {
        for (int i = currentPositionCol; i <= col; i++)
        {
            if (i <= matrix.GetLength(1) - 1 && !checkMatrix[currentPositionRow, i])
            {
                sum += matrix[currentPositionRow, i];
                checkMatrix[currentPositionRow, i] = true;
            }
            else if (i == matrix.GetLength(1))
            {
                break;
            }

            currentPositionCol = i;
        }
    }

    private static void InitializeMatrix()
    {
        BigInteger cellVallue = 1;
        for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = cellVallue;
                cellVallue *= 2;
            }

            cellVallue = matrix[i, 1];
        }
    }
}