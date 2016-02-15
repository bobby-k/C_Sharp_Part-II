using System;

internal class LoverOf3
{
    private static void Main()
    {
        string[] dimensions = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        // initialize matrix
        int rows = int.Parse(dimensions[0]);
        int cols = int.Parse(dimensions[1]);

        int[,] matrix = new int[rows, cols];

        int cell = 0;
        for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = cell;
                cell += 3;
            }

            cell = matrix[i, 1];
        }

        int numberOfDirections = int.Parse(Console.ReadLine());

        bool[,] boolMatrix = new bool[rows, cols];
        bool collected = true;
        int sum = 0;

        int row = matrix.GetLength(0) - 1;
        int col = 0;

        for (int i = 0; i < numberOfDirections; i++)
        {
            string[] instructions = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            switch (instructions[0])
            {
                // UR RU
                case "UR":
                    for (int j = 0; j < int.Parse(instructions[1]); j++)
                    {
                        if (col < 0 || col > cols - 1 || row < 0 || row > rows - 1)
                        {
                            break;
                        }
                        if (boolMatrix[row, col] != collected)
                        {
                            sum += matrix[row, col];
                            boolMatrix[row, col] = collected;
                        }
                        row--;
                        col++;
                    }
                    row++;
                    col--;
                    break;

                case "RU":
                    for (int j = 0; j < int.Parse(instructions[1]); j++)
                    {
                        if (col < 0 || col > cols - 1 || row < 0 || row > rows - 1)
                        {
                            break;
                        }
                        if (boolMatrix[row, col] != collected)
                        {
                            sum += matrix[row, col];
                            boolMatrix[row, col] = collected;
                        }
                        row--;
                        col++;
                    }
                    row++;
                    col--;
                    break;
                // UL LU
                case "UL":
                    for (int j = 0; j < int.Parse(instructions[1]); j++)
                    {
                        if (col < 0 || col > cols - 1 || row < 0 || row > rows - 1)
                        {
                            break;
                        }
                        if (boolMatrix[row, col] != collected)
                        {
                            sum += matrix[row, col];
                            boolMatrix[row, col] = collected;
                        }
                        row--;
                        col--;
                    }
                    row++;
                    col++;
                    break;

                case "LU":
                    for (int j = 0; j < int.Parse(instructions[1]); j++)
                    {
                        if (col < 0 || col > cols - 1 || row < 0 || row > rows - 1)
                        {
                            break;
                        }
                        if (boolMatrix[row, col] != collected)
                        {
                            sum += matrix[row, col];
                            boolMatrix[row, col] = collected;
                        }
                        row--;
                        col--;
                    }
                    row++;
                    col++;
                    break;
                // DL LD
                case "DL":
                    for (int j = 0; j < int.Parse(instructions[1]); j++)
                    {
                        if (col < 0 || col > cols - 1 || row < 0 || row > rows - 1)
                        {
                            break;
                        }
                        if (boolMatrix[row, col] != collected)
                        {
                            sum += matrix[row, col];
                            boolMatrix[row, col] = collected;
                        }
                        row++;
                        col--;
                    }
                    row--;
                    col++;
                    break;

                case "LD":
                    for (int j = 0; j < int.Parse(instructions[1]); j++)
                    {
                        if (col < 0 || col > cols - 1 || row < 0 || row > rows - 1)
                        {
                            break;
                        }
                        if (boolMatrix[row, col] != collected)
                        {
                            sum += matrix[row, col];
                            boolMatrix[row, col] = collected;
                        }
                        row++;
                        col--;
                    }
                    row--;
                    col++;
                    break;
                // DR RD
                case "DR":
                    for (int j = 0; j < int.Parse(instructions[1]); j++)
                    {
                        if (col < 0 || col > cols - 1 || row < 0 || row > rows - 1)
                        {
                            break;
                        }
                        if (boolMatrix[row, col] != collected)
                        {
                            sum += matrix[row, col];
                            boolMatrix[row, col] = collected;
                        }
                        row++;
                        col++;
                    }
                    row--;
                    col--;
                    break;

                case "RD":
                    for (int j = 0; j < int.Parse(instructions[1]); j++)
                    {
                        if (col < 0 || col > cols - 1 || row < 0 || row > rows - 1)
                        {
                            break;
                        }
                        if (boolMatrix[row, col] != collected)
                        {
                            sum += matrix[row, col];
                            boolMatrix[row, col] = collected;
                        }
                        row++;
                        col++;
                    }
                    row--;
                    col--;
                    break;

                default:
                    break;
            }
        }

        Console.WriteLine(sum);
    }
}