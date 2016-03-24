using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

class CatConcert
{
    static int minNumOfSongs = 0;
    static bool[,] matrix;

    static void Main()
    {
        var reader = new StreamReader(@"D:\C#2\Variant 3 (2015-03-06, Morning)\Problem 5\Tests\test.001.in.txt");

        string[] line1 = reader.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);    // Console
        int catsNumber = int.Parse(line1[0]);

        string[] line2 = reader.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int songsNumber = int.Parse(line2[0]);

        InitializeMatrix(catsNumber, songsNumber, reader);

        int songsEverybodyKnow = CheckHowManySongsEverybodyKnow();

        if (CheckIfEveryCatHasASong(catsNumber))
        {
            if (songsEverybodyKnow > 0)
            {
                minNumOfSongs = songsEverybodyKnow;
            }
            else
            {
                CountMinNumOfSongs(catsNumber);
            }
        }

        Printout();
    }

    static void CountMinNumOfSongs(int numberOfCats)
    {
        // find the most known song, check how many cats don't know it and the minNumOfSongs is the most known + the number of cats that don't know it

        int catsThatKnowTheMostKnownSong = TheMostKnownSong();
        int additionalSongs = numberOfCats - catsThatKnowTheMostKnownSong;
        minNumOfSongs = 1 + additionalSongs;
    }

    private static int TheMostKnownSong()
    {
        int[] mostKnownSong = new int[matrix.GetLength(1)];

        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                if (matrix[j, i] == true)
                {
                    mostKnownSong[i]++;
                }
            }
        }

        Array.Sort(mostKnownSong);

        return mostKnownSong[mostKnownSong.Length - 1];
    }

    private static bool CheckIfEveryCatHasASong(int catsNumber)
    {
        bool[] catHasSong = new bool[catsNumber];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] == true)
                {
                    catHasSong[i] = true;
                    break;
                }
            }
        }

        for (int i = 0; i < catHasSong.Length; i++)
        {
            if (catHasSong[i] == false)
            {
                return false;
            }
        }

        return true;
    }

    private static int CheckHowManySongsEverybodyKnow()
    {
        int songs = 0;
        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                if (matrix[j, i] == false)
                {
                    break;
                }
                else if (j == matrix.GetLength(0) - 1)
                {
                    songs++;
                }
            }
        }

        return songs;
    }

    private static void InitializeMatrix(int catsNumber, int songsNumber, StreamReader sr)
    {
        matrix = new bool[catsNumber, songsNumber];
        while (true)
        {
            string nextLine = sr.ReadLine();
            if (nextLine == "Mew!")
            {
                break;
            }

            string[] nextLineWords = nextLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int catNum = int.Parse(nextLineWords[1]);
            int songNum = int.Parse(nextLineWords[4]);

            matrix[catNum - 1, songNum - 1] = true; // matrix starts with index 0 in both directions


        }
    }

    private static void Printout()
    {
        if (minNumOfSongs == 0)
        {
            Console.WriteLine("No concert!");
        }
        else
        {
            Console.WriteLine(minNumOfSongs);
        }
    }
}
