using System;
using System.Globalization;
using System.Threading;

namespace Problem7.SelectionSort
{
    class SelectionSort
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            // Write a program to sort an array.
            // Use the Selection sort algorithm: Find the smallest element, move it at the first position, 
            // find the smallest from the rest, move it at the second position, etc

            // Подробно обяснение съм дал в решението на задачата за MaximalKSum

            // масиви за тестване
            int[] arr1 = { 1, 9, -7, -4, 11, 3, -4, -1, 8, 0, -17 };
            //int[] arr1 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
            //int[] arr1 = { 0,-1,-2,-3,-4,-5,-6,-7,-8,-9,-10,-11 };

            int smallestElementIndex = 0;
            int smallestEllement = arr1[smallestElementIndex];
            int arr1Index = 1;
            int initialIndex = 0;

            while (arr1Index < arr1.Length)
            {
                for (int i = arr1Index; i < arr1.Length; i++)
                {
                    if (arr1[i] < smallestEllement)
                    {
                        smallestEllement = arr1[i];
                        smallestElementIndex = i;
                    }
                }

                int temp = arr1[initialIndex];
                arr1[initialIndex] = smallestEllement;
                arr1[smallestElementIndex] = temp;

                initialIndex++;
                smallestElementIndex = initialIndex;
                smallestEllement = arr1[initialIndex];

                arr1Index++;
            }

            // принтира сортираният масив 
            string sortedArray = string.Join(", ", arr1);
            Console.WriteLine(sortedArray);
        }
    }
}
