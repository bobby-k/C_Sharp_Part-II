using System;
using System.Globalization;
using System.Threading;

namespace Problem5.LargerThanNeighbors
{
    class LargerThanNeighbors
    {
        //  Write a method that checks if the element at given position in given array of integers is larger than its two neighbors 
        // (when such exists).

        static bool CheckIfLarger(int position, int[] array)
        {
            bool isLarger = false;

            // if it's not the very first position and the very last position
            if (position > 0 && position < array.Length - 1)
            {
                // check the two neighbors (left and right)
                if (array[position] > array[position - 1] && array[position] > array[position + 1])
                {
                    isLarger = true;
                }
            }
            // otherwise 
            else
            {
                // if it's the very first position
                if (position == 0)
                {
                    // check just the neighbor on the right
                    if (array[position] > array[position + 1])
                    {
                        isLarger = true;
                    }
                }
                // or if it's the very last position
                else if (position == array.Length - 1)
                {
                    // check just the neighbor on the left
                    if (array[position] > array[position - 1])
                    {
                        isLarger = true;
                    }
                }
            }

            return isLarger;
        }
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            int[] someArray = { 7, 1, 3, 3, 2, 1, 6, 5, 8, 9, 3, 1, 4, 6, 7, 9, 1, 0 };

            Console.Write("Please specify the position you want to check: ");
            int position = int.Parse(Console.ReadLine());

            // validation
            while (position < 0 || position > someArray.Length - 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect position!!!\nPosition must be within the range of the array!\nTry again!");
                
                Console.ForegroundColor = ConsoleColor.Yellow;
                position = int.Parse(Console.ReadLine());
            }

            Console.Clear();
            Console.ResetColor();
            Console.WriteLine(CheckIfLarger(position, someArray));
        }
    }
}
