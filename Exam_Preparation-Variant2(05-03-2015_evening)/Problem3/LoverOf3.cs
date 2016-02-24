using System;

internal class LoverOf3
{
    private static void Main()
    {
        // var reader = new StreamReader(@"D:\C#2\Variant 2 (2015-03-05, Evening)\Problem 3\Lover-of-3-tests\test.000.001.in.txt");

        string[] dimensions = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int rows = int.Parse(dimensions[0]);
        int cols = int.Parse(dimensions[1]);
        int[,] matrix = new int[rows, cols];
        bool[,] checkMatrix = new bool[rows, cols];

        // initialize matrix
        int initialValue = 0;
        for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = initialValue;
                initialValue += 3;
            }

            initialValue = matrix[row, 1];
        }

        int numberOfMovesAndDirct = int.Parse(Console.ReadLine());
        int currentRow = matrix.GetLength(0) - 1;
        int currentCol = 0;
        long sum = 0;

        for (int i = 0; i < numberOfMovesAndDirct; i++)
        {
            string[] directionAndNum = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string direction = directionAndNum[0];
            int numberOfTimes = int.Parse(directionAndNum[1]);

            switch (direction)
            {
                case "UR":
                    for (int j = 0; j < numberOfTimes; j++)
                    {
                        if (!checkMatrix[currentRow, currentCol])
                        {
                            sum += matrix[currentRow, currentCol];
                            checkMatrix[currentRow, currentCol] = true;
                        }

                        currentRow--;
                        currentCol++;

                        if (currentRow < 0 || currentCol > matrix.GetLength(1) - 1)
                        {
                            break;
                        }
                    }
                    currentRow++;
                    currentCol--;
                    break;

                case "RU":
                    for (int j = 0; j < numberOfTimes; j++)
                    {
                        if (!checkMatrix[currentRow, currentCol])
                        {
                            sum += matrix[currentRow, currentCol];
                            checkMatrix[currentRow, currentCol] = true;
                        }

                        currentRow--;
                        currentCol++;

                        if (currentRow < 0 || currentCol > matrix.GetLength(1) - 1)
                        {
                            break;
                        }
                    }
                    currentRow++;
                    currentCol--;
                    break;

                case "DR":
                    for (int j = 0; j < numberOfTimes; j++)
                    {
                        if (!checkMatrix[currentRow, currentCol])
                        {
                            sum += matrix[currentRow, currentCol];
                            checkMatrix[currentRow, currentCol] = true;
                        }
                        currentRow++;
                        currentCol++;
                        if (currentRow > matrix.GetLength(0) - 1 || currentCol > matrix.GetLength(1) - 1)
                        {
                            break;
                        }
                    }
                    currentRow--;
                    currentCol--;
                    break;

                case "RD":
                    for (int j = 0; j < numberOfTimes; j++)
                    {
                        if (!checkMatrix[currentRow, currentCol])
                        {
                            sum += matrix[currentRow, currentCol];
                            checkMatrix[currentRow, currentCol] = true;
                        }
                        currentRow++;
                        currentCol++;
                        if (currentRow > matrix.GetLength(0) - 1 || currentCol > matrix.GetLength(1) - 1)
                        {
                            break;
                        }
                    }
                    currentRow--;
                    currentCol--;
                    break;

                case "DL":
                    for (int j = 0; j < numberOfTimes; j++)
                    {
                        if (!checkMatrix[currentRow, currentCol])
                        {
                            sum += matrix[currentRow, currentCol];
                            checkMatrix[currentRow, currentCol] = true;
                        }
                        currentRow++;
                        currentCol--;
                        if (currentRow > matrix.GetLength(0) - 1 || currentCol < 0)
                        {
                            break;
                        }
                    }
                    currentRow--;
                    currentCol++;
                    break;

                case "LD":
                    for (int j = 0; j < numberOfTimes; j++)
                    {
                        if (!checkMatrix[currentRow, currentCol])
                        {
                            sum += matrix[currentRow, currentCol];
                            checkMatrix[currentRow, currentCol] = true;
                        }
                        currentRow++;
                        currentCol--;
                        if (currentRow > matrix.GetLength(0) - 1 || currentCol < 0)
                        {
                            break;
                        }
                    }
                    currentRow--;
                    currentCol++;
                    break;

                case "UL":
                    for (int j = 0; j < numberOfTimes; j++)
                    {
                        if (!checkMatrix[currentRow, currentCol])
                        {
                            sum += matrix[currentRow, currentCol];
                            checkMatrix[currentRow, currentCol] = true;
                        }
                        currentRow--;
                        currentCol--;
                        if (currentRow < 0 || currentCol < 0)
                        {
                            break;
                        }
                    }
                    currentRow++;
                    currentCol++;
                    break;

                case "LU":
                    for (int j = 0; j < numberOfTimes; j++)
                    {
                        if (!checkMatrix[currentRow, currentCol])
                        {
                            sum += matrix[currentRow, currentCol];
                            checkMatrix[currentRow, currentCol] = true;
                        }
                        currentRow--;
                        currentCol--;
                        if (currentRow < 0 || currentCol < 0)
                        {
                            break;
                        }
                    }
                    currentRow++;
                    currentCol++;
                    break;
            }
        }

        Console.WriteLine("{0}", sum);
    }
}