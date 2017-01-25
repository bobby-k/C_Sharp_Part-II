using System;
using System.Linq;

namespace problem3
{
    internal class Program3
    {
        private static void Main()
        {
            // input
            int entranceIndex = 0;
            int[] rc = Console.ReadLine().Split('x').Select(int.Parse).ToArray();
            int numbOfRows = rc[0];
            int numbOfCols = rc[1];

            char[,] den = new char[numbOfRows, numbOfCols];
            for (int i = 0; i < numbOfRows; i++)
            {
                string currentLine = Console.ReadLine();
                if (i == 0)
                {
                    entranceIndex = currentLine.IndexOf('s');
                }

                for (int j = 0; j < numbOfCols; j++)
                {
                    den[i, j] = currentLine[j];
                }
            }

            string[] directions = Console.ReadLine().Split(',');

            // solution
            int sneakyLength = 3;
            int numberOfMoves = 0;
            int currentRow = 0;
            int currentCol = entranceIndex;
            for (int i = 0; i < directions.Length; i++)
            {
                if (sneakyLength <= 0)
                {
                    Console.WriteLine("Snacky will starve at [{0},{1}]", currentRow, currentCol);
                    return;
                }

                numberOfMoves++;
                if (numberOfMoves % 5 == 0)
                {
                    sneakyLength--;
                }

                string currentDirection = directions[i];
                switch (currentDirection)
                {
                    case "u":
                        currentRow--;
                        if (den[currentRow, currentCol] == '*')
                        {
                            sneakyLength++;
                            den[currentRow, currentCol] = '.';
                        }
                        else if (den[currentRow, currentCol] == '#')
                        {
                            Console.WriteLine("Snacky will hit a rock at [{0},{1}]", currentRow, currentCol);
                            return;
                        }
                        else if (den[currentRow, currentCol] == 's')
                        {
                            Console.WriteLine("Snacky will get out with length {0}", sneakyLength);
                            return;
                        }
                        break;

                    case "d":
                        currentRow++;
                        if (currentRow >= numbOfRows)
                        {
                            Console.WriteLine("Snacky will be lost into the depths with length {0}", sneakyLength);
                            return;
                        }
                        else if (den[currentRow, currentCol] == '*')
                        {
                            sneakyLength++;
                            den[currentRow, currentCol] = '.';
                        }
                        else if (den[currentRow, currentCol] == '#')
                        {
                            Console.WriteLine("Snacky will hit a rock at [{0},{1}]", currentRow, currentCol);
                            return;
                        }
                        break;

                    case "l":
                        currentCol--;
                        if (currentCol < 0)
                        {
                            currentCol = numbOfCols - 1;
                        }

                        if (den[currentRow, currentCol] == '*')
                        {
                            sneakyLength++;
                            den[currentRow, currentCol] = '.';
                        }
                        else if (den[currentRow, currentCol] == '#')
                        {
                            Console.WriteLine("Snacky will hit a rock at [{0},{1}]", currentRow, currentCol);
                            return;
                        }
                        break;

                    case "r":
                        currentCol++;
                        if (currentCol >= numbOfCols)
                        {
                            currentCol = 0;
                        }

                        if (den[currentRow, currentCol] == '*')
                        {
                            sneakyLength++;
                            den[currentRow, currentCol] = '.';
                        }
                        else if (den[currentRow, currentCol] == '#')
                        {
                            Console.WriteLine("Snacky will hit a rock at [{0},{1}]", currentRow, currentCol);
                            return;
                        }
                        break;
                }
            }

            Console.WriteLine("Snacky will be stuck in the den at [{0},{1}]", currentRow, currentCol);
        }
    }
}