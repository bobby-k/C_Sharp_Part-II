namespace DogeCoin
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class DogeCoin
    {
        static void Main()
        {
            // input
            int[] sizes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = sizes[0];
            int cols = sizes[1];

            int[,] matrix = new int[rows, cols];
            int numbOfCoins = int.Parse(Console.ReadLine());
            for (int i = 0; i < numbOfCoins; i++)
            {
                int[] coinCoords = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                matrix[coinCoords[0], coinCoords[1]]++;
            }

            // solution
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    int biggerUp = 0;
                    int biggerLeft = 0;

                    if (i - 1 >= 0)
                    {
                        biggerUp = matrix[i - 1, j];
                    }

                    if (j - 1 >= 0)
                    {
                        biggerLeft = matrix[i, j - 1];
                    }

                    matrix[i, j] = Math.Max(biggerUp, biggerLeft) + matrix[i, j];
                }
            }

            Console.WriteLine(matrix[rows-1,cols-1]);
        }
    }
}
