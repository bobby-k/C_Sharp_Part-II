using System;
using System.IO;
using System.Linq;

internal class SingingCats
{
    private static void Main()
    {
        //var reader = new StreamReader(@"D:\C#2\Variant 4 (2015-03-06, Evening)\Problem 5\Tests\test.002.in.txt");
        // reader
        string[] line1 = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int numOfCats = int.Parse(line1[0]);

        string[] line2 = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int numOfSongs = int.Parse(line2[0]);

        int[,] matrix = new int[numOfCats, numOfSongs];

        string[] nextLine = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        while (nextLine[0] != "Mew!")
        {
            int catNum = int.Parse(nextLine[1]);
            int songNum = int.Parse(nextLine[4]);

            matrix[catNum - 1, songNum - 1] = 1;    // -1 because matrix starts with index 0

            nextLine = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }

        int minNumOfSongs = GetMinNumOfSongs(matrix);
        if (minNumOfSongs == 0)
        {
            Console.WriteLine("No concert!");
        }
        else
        {
            Console.WriteLine(minNumOfSongs);
        }
    }

    private static int GetMinNumOfSongs(int[,] matrix)
    {
        int minNumOfSongs = 0;

        if (!EveryCatHasASong(matrix))   // not every cat has a song to sing
        {
            return minNumOfSongs;
        }
        else
        {
            // count minimum number of songs to be sung

            // if there are songs that everybody know count them(all columns with only 1s) this is minNumOfSongs
            int songsEveryBodyKnow = FindHowManySongsEverybodyKnow(matrix);

            if (songsEveryBodyKnow > 0)
            {
                minNumOfSongs = songsEveryBodyKnow;
            }
            else
            {
                // else count number of songs until all cats get a song and this will be the minimum number
                bool[] catHasSong = new bool[matrix.GetLength(0)];

                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                    for (int j = 0; j < matrix.GetLength(0); j++)
                    {
                        if (matrix[j, i] == 1)
                        {
                            catHasSong[j] = true;
                        }

                        if (catHasSong.All(e => e == true))
                        {
                            return i + 1;
                        }
                    }
                }
            }
        }

        return minNumOfSongs;
    }

    private static int FindHowManySongsNobodyKnow(int[,] matrix)
    {
        int number = 0;

        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                if (matrix[j, i] == 1)
                {
                    break;
                }
                else if (j == matrix.GetLength(0) && matrix[j, i] == 0)
                {
                    number++;
                }
            }
        }

        return number;
    }

    private static int FindHowManySongsEverybodyKnow(int[,] matrix)
    {
        int number = 0;

        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                if (matrix[j, i] == 0)
                {
                    break;
                }
                else if (j == matrix.GetLength(0) - 1 && matrix[j, i] == 1)
                {
                    number++;
                }
            }
        }

        return number;
    }

    private static bool EveryCatHasASong(int[,] matrix)
    {
        bool[] cat = new bool[matrix.GetLength(0)];

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] == 1)
                {
                    cat[i] = true;
                }
            }
        }

        for (int i = 0; i < cat.Length; i++)
        {
            if (!cat[i])
            {
                return false;
            }
        }

        return true;
    }
}