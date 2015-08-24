using System;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace Problem9.SortingArray
{
    class SortingArray
    {
        // Write a method that return the maximal element in a portion of array of integers starting at given index.
        // Using it write another method that sorts an array in ascending / descending order.

        // P.S. Имената на методите и съдържанието им са достатъчно описателни и няма нужда от допълнителни пояснения
        static int GetMaxElementIndexInRange(int[] array, int startIndex, int endIndex)
        {
            int maxElement = array[startIndex];
            int maxElementIndex = startIndex;

            for (int i = startIndex; i <= endIndex; i++)
            {
                if (array[i] > maxElement)
                {
                    maxElement = array[i];
                    maxElementIndex = i;
                }
            }

            return maxElementIndex;
        }

        static void SortAscending(int[] array)
        {
            int endIndex = array.Length - 1;

            for (int i = endIndex; i >= 0; i--)
            {
                int maxElementIndex = GetMaxElementIndexInRange(array, 0, i);
                int maxElement = array[maxElementIndex];

                int temp = array[i];
                array[i] = maxElement;
                array[maxElementIndex] = temp;
            }

        }

        static void SortDescending(int[] array)
        {
            int endIndex = array.Length - 1;

            for (int i = 0; i < endIndex; i++)
            {
                int maxElementIndex = GetMaxElementIndexInRange(array, i, endIndex);
                int maxElement = array[maxElementIndex];

                int temp = array[i];
                array[i] = maxElement;
                array[maxElementIndex] = temp;
            }
        }

        static void Print(int[] array)
        {
            string arr = string.Join(", ", array);
            Console.WriteLine(arr);
        }

        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            int[] arr1 = { 1, 2, 32, 9, 4, 89, 6, 7, 78, 11 };

            Console.WriteLine("The maximal element is: {0}", arr1[GetMaxElementIndexInRange(arr1, 0, arr1.Length - 1)]);

            SortDescending(arr1);
            Console.WriteLine(string.Join(", ", arr1));

            SortAscending(arr1);
            Console.WriteLine(string.Join(", ", arr1));
        }
    }
}
