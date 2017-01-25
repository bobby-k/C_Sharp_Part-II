namespace Temp
{
    using System;

    public class Digits
    {
        private static int[,] matrix;
        private static int sizeOfMatrix;

        private static void Main()
        {
            // input
            int sum = 0;
            sizeOfMatrix = int.Parse(Console.ReadLine());
            matrix = new int[sizeOfMatrix, sizeOfMatrix];
            string[] currentLine;

            for (int i = 0; i < sizeOfMatrix; i++)
            {
                currentLine = Console.ReadLine().Split(' ');
                Initialize(currentLine, i);
            }

            const int paternRows = 5;
            const int paternCols = 3;
            for (int i = 0; i < matrix.GetLength(0) - paternRows + 1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - paternCols + 1; j++)
                {
                    sum += CountOnes(i, j);
                    sum += CountTwos(i, j);
                    sum += CountThrees(i, j);
                    sum += CountFours(i, j);
                    sum += CountFives(i, j);
                    sum += CountSixes(i, j);
                    sum += CountSevens(i, j);
                    sum += CountEights(i, j);
                    sum += CountNines(i, j);
                }
            }
            
            Console.WriteLine(sum);
        }

        private static void Initialize(string[] line, int row)
        {
            for (int col = 0; col < sizeOfMatrix; col++)
            {
                matrix[row, col] = int.Parse(line[col]);
            }
        }

        private static int CountOnes(int i, int j)
        {
            if (matrix[i, j + 2] == 1 &&
                        matrix[i + 1, j + 1] == 1 && matrix[i + 1, j + 2] == 1 &&
                        matrix[i + 2, j] == 1 && matrix[i + 2, j + 2] == 1 &&
                        matrix[i + 3, j + 2] == 1 &&
                        matrix[i + 4, j + 2] == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        private static int CountTwos(int i, int j)
        {
            if (matrix[i, j + 1] == 2 &&
                        matrix[i + 1, j] == 2 && matrix[i + 1, j + 2] == 2 &&
                        matrix[i + 2, j + 2] == 2 &&
                        matrix[i + 3, j + 1] == 2 &&
                        matrix[i + 4, j] == 2 && matrix[i + 4, j + 1] == 2 && matrix[i + 4, j + 2] == 2)
            {
                return 2;
            }
            else
            {
                return 0;
            }
        }

        private static int CountThrees(int i, int j)
        {
            if (matrix[i, j + 1] == 3 && matrix[i, j] == 3 && matrix[i, j + 2] == 3 &&
                        matrix[i + 1, j + 2] == 3 &&
                        matrix[i + 2, j + 1] == 3 && matrix[i + 2, j + 2] == 3 &&
                        matrix[i + 3, j + 2] == 3 &&
                        matrix[i + 4, j] == 3 && matrix[i + 4, j + 1] == 3 && matrix[i + 4, j + 2] == 3)
            {
                return 3;
            }
            else
            {
                return 0;     
            }
        }

        private static int CountFours(int i, int j)
        {
            if (matrix[i, j] == 4 && matrix[i, j + 2] == 4 &&
                        matrix[i + 1, j] == 4 && matrix[i + 1, j + 2] == 4 &&
                        matrix[i + 2, j] == 4 && matrix[i + 2, j + 1] == 4 && matrix[i + 2, j + 2] == 4 &&
                        matrix[i + 3, j + 2] == 4 &&
                        matrix[i + 4, j + 2] == 4)
            {
                return 4;
            }
            else
            {
                return 0;
            }
        }

        private static int CountFives(int i, int j)
        {
            if (matrix[i, j] == 5 && matrix[i, j + 1] == 5 && matrix[i, j + 2] == 5 &&
                        matrix[i + 1, j] == 5 &&
                        matrix[i + 2, j] == 5 && matrix[i + 2, j + 1] == 5 && matrix[i + 2, j + 2] == 5 &&
                        matrix[i + 3, j + 2] == 5 &&
                        matrix[i + 4, j] == 5 && matrix[i + 4, j + 1] == 5 && matrix[i + 4, j + 2] == 5)
            {
                return 5;
            }
            else
            {
                return 0;

            }
        }

        private static int CountSixes(int i, int j)
        {
            if (matrix[i, j] == 6 && matrix[i, j + 1] == 6 && matrix[i, j + 2] == 6 &&
                        matrix[i + 1, j] == 6 &&
                        matrix[i + 2, j] == 6 && matrix[i + 2, j + 1] == 6 && matrix[i + 2, j + 2] == 6 &&
                        matrix[i + 3, j] == 6 && matrix[i + 3, j + 2] == 6 &&
                        matrix[i + 4, j] == 6 && matrix[i + 4, j + 1] == 6 && matrix[i + 4, j + 2] == 6)
            {
                return 6;
            }
            else
            {
                return 0;
            }
        }

        private static int CountSevens(int i, int j)
        {
            if (matrix[i, j] == 7 && matrix[i, j + 1] == 7 && matrix[i, j + 2] == 7 &&
                        matrix[i + 1, j + 2] == 7 &&
                        matrix[i + 2, j + 1] == 7 &&
                        matrix[i + 3, j + 1] == 7 &&
                        matrix[i + 4, j + 1] == 7)
            {
                return 7;
            }
            else
            {
                return 0;
            }
        }

        private static int CountEights(int i, int j)
        {
            if (matrix[i, j] == 8 && matrix[i, j + 1] == 8 && matrix[i, j + 2] == 8 &&
                        matrix[i + 1, j] == 8 && matrix[i + 1, j + 2] == 8 &&
                        matrix[i + 2, j + 1] == 8 &&
                        matrix[i + 3, j] == 8 && matrix[i + 3, j + 2] == 8 &&
                        matrix[i + 4, j] == 8 && matrix[i + 4, j + 1] == 8 && matrix[i + 4, j + 2] == 8)
            {
                return 8;
            }
            else
            {
                return 0;
            }
        }

        private static int CountNines(int i, int j)
        {
            if (matrix[i, j] == 9 && matrix[i, j + 1] == 9 && matrix[i, j + 2] == 9 &&
                        matrix[i + 1, j] == 9 && matrix[i + 1, j + 2] == 9 &&
                        matrix[i + 2, j + 1] == 9 && matrix[i + 2, j + 2] == 9 &&
                        matrix[i + 3, j + 2] == 9 &&
                        matrix[i + 4, j] == 9 && matrix[i + 4, j + 1] == 9 && matrix[i + 4, j + 2] == 9)
            {
                return 9;
            }
            else
            {
                return 0;
            }
        }
    }
}