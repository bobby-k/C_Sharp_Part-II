using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Problem4.AppearanceCount
{
    class AppearanceCount
    {
        // Write a method that counts how many times given number appears in given array.
        // Write a test program to check if the method is working correctly.

        static int CountAppearance(int number, int[] array)
        {
            int count = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == number)
                {
                    count++;
                }
            }

            return count;
        }
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            int[] someArray = { 1, 123, 5, 15, 5, 5, 5, 6, 13, 11, 123, 123, 123, 0, 7, 0, 7, 0, 0, 7, 11 };
            Console.WriteLine(string.Join(", ", someArray));
            Console.WriteLine();
            Console.Write("Please specify which number to count: ");
            int numberToCount = int.Parse(Console.ReadLine());

            Console.WriteLine("number {0} -> {1} times", numberToCount, CountAppearance(numberToCount, someArray));
        }
    }
}
