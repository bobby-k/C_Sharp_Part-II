using System.IO;

internal class MaximalAreaSum
{
    // Write a program that reads a text file containing a square matrix of numbers. Find an area of size 2 x 2 in the matrix, with
    // a maximal sum of its elements. The first line in the input file contains the size of matrix N. Each of the next N lines
    // contain N numbers separated by space. The output should be a single number in a separate text file
    private static void Main()
    {
        int[,] matrix = SetUpMatrix();
        int output = FindMaximalAreaSum(matrix);
        PrintToFile(output);
    }

    private static int[,] SetUpMatrix()
    {
        var reader = new StreamReader(@"..\..\Files\input.txt");
        string line = reader.ReadLine();    // get the matrix size
        int matrixSize = int.Parse(line);
        int[,] matrix = new int[matrixSize, matrixSize];
        int charIndex = 0;
        int row = 0;
        int col = 0;

        using (reader)
        {
            line = reader.ReadLine();   // get the line after the size of matrix

            while (line != null)
            {
                for (int i = 0; i < line.Length; i++)   // get each char from the line
                {
                    if (char.IsDigit(line[charIndex]))  // if it's digit
                    {
                        matrix[row, col] = line[charIndex] - '0'; // add it to the matrix and go to next column
                        col++;
                        charIndex++;
                    }
                    else
                    {
                        charIndex++;    // else just get next char
                    }
                }

                col = 0;    // before read new line go to the first column
                charIndex = 0; // before read new line go to the first char of the line
                row++;  // // before read new line go to the next row of the matrix

                line = reader.ReadLine();
            }
        }

        return matrix;
    }

    private static int FindMaximalAreaSum(int[,] someMatrix)
    {
        int maxSum = 0;

        for (int i = 0; i < someMatrix.GetLength(0) - 1; i++)
        {
            for (int j = 0; j < someMatrix.GetLength(1) - 1; j++)
            {
                int currentSum = someMatrix[i, j] + someMatrix[i, j + 1] + someMatrix[i + 1, j + 1] + someMatrix[i + 1, j];
                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                }
            }
        }

        return maxSum;
    }

    private static void PrintToFile(int output)
    {
        var writer = new StreamWriter(@"..\..\Files\output.txt");

        using (writer)
        {
            writer.WriteLine(output);
        }
    }
}