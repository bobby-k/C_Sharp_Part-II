using System;
using System.Numerics;

internal class HelpDoge
{
    private const int InitialDogePosX = 0;
    private const int InitialDogePosY = 0;
    private static BigInteger[,] matrix;

    private static void Main()
    {
        //// input below

        string[] size = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int rows = int.Parse(size[0]);
        int cols = int.Parse(size[1]);

        // set the grid
        matrix = new BigInteger[rows, cols];

        string[] foodCoordinatesXY = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int foodX = int.Parse(foodCoordinatesXY[0]);
        int foodY = int.Parse(foodCoordinatesXY[1]);

        // set dog position
        matrix[InitialDogePosX, InitialDogePosY] = 1;

        int numOfEnemies = int.Parse(Console.ReadLine());

        // set the enemies
        for (int i = 0; i < numOfEnemies; i++)
        {
            string[] enemyXY = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int enemyX = int.Parse(enemyXY[0]);
            int enemyY = int.Parse(enemyXY[1]);

            matrix[enemyX, enemyY] = -1;
        }

        BigInteger possibleWays = CountPossibleWays(foodX, foodY);
        Console.WriteLine(possibleWays);
    }

    private static BigInteger CountPossibleWays(int foodX, int foodY)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (i == 0 && j == 0)
                {
                    // doge init.pos.
                    continue;
                }

                if (matrix[i, j] == -1) // i.e. ENEMY
                {
                    matrix[i, j] = 0;
                    continue;
                }

                BigInteger up = GetUpValue(i, j);
                BigInteger left = GetLeftValue(i, j);

                matrix[i, j] = up + left;

                if (i == foodX && j == foodY)
                {
                    // when you reach the food stop and give result
                    return matrix[foodX, foodY];
                }
            }
        }

        return matrix[foodX, foodY];
    }

    private static BigInteger GetLeftValue(int row, int col)
    {
        col--;
        if (col < 0)
        {
            return 0;
        }

        return matrix[row, col];
    }

    private static BigInteger GetUpValue(int row, int col)
    {
        row--;
        if (row < 0)
        {
            return 0;
        }

        return matrix[row, col];
    }
}