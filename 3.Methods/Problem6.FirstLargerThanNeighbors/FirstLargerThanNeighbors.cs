using System;
using System.Globalization;
using System.Threading;

namespace Problem6.FirstLargerThanNeighbors
{
    class FirstLargerThanNeighbors
    {
        // Write a method that returns the index of the first element in array that is larger than its neighbors, 
        // or -1, if there’s no such element.

        static int GetFirstLarger(int[] array)
        {
            // gets all indexes and for each one checks
            for (int i = 0; i < array.Length; i++)
            {
                // if index is not the very first or the very last
                if (i > 0 && i < array.Length - 1)
                {
                    // checks the neighbors on the left and on the right
                    if (array[i] > array[i - 1] && array[i] > array[i + 1])
                    {
                        return i;
                    }
                }
                // otherwise 
                else
                {
                    // if it's the very first
                    if (i == 0)
                    {
                        // checks only the neighbor on the left
                        if (array[i] > array[i + 1])
                        {
                            return i;
                        }
                    }
                    // or if it's the very last
                    else if (i == array.Length - 1)
                    {
                        // checks only the neighbor on the right
                        if (array[i] > array[i - 1])
                        {
                            return i;
                        }
                    }
                }
            }

            // if it doesn't find any number larger than its neighbor
            return -1;
        }

        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            //int[] someArray = { 0, 1, 3, 3, 2, 1, 6, 5, 8, 9, 3, 1, 4, 6, 7, 9, 1, 0 };
            //int[] someArray = { -1, -2, 0, 0, 0, 0, 0 };
            //int[] someArray = { 0, 0, 0, 0, 0, 0 };
            int[] someArray = { 0, 0, 0, 0, 0, 0, 1 };

            Console.WriteLine(GetFirstLarger(someArray));
        }
    }
}
