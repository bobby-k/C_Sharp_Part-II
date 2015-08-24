using System;
using System.Globalization;
using System.Threading;

namespace Problem2.CompareArrays
{
    class CompareArrays
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            // Write a program that reads two integer arrays from the console and compares them element by element.

            bool identity = true;

            Console.Write("Enter the length of the first array: ");
            int arr1Length = int.Parse(Console.ReadLine());

            int[] arr1 = new int[arr1Length];

            for (int i = 0; i < arr1Length; i++)
            {
                arr1[i] = int.Parse(Console.ReadLine());
            }

            Console.Write("Enter the length of the second array: ");
            int arr2Length = int.Parse(Console.ReadLine());

            int[] arr2 = new int[arr2Length];

            for (int i = 0; i < arr2Length; i++)
            {
                arr2[i] = int.Parse(Console.ReadLine());
            }

            // Два масива са равни когато имат еднаква дължина и всеки елемент от първият масив е равен на съответният елемент със 
            // същият индекс във вторият масив...

            if (arr1.Length == arr2.Length)
            {
                for (int i = 0; i < arr1.Length; i++)
                {
                    if (arr1[i] != arr2[i])
                    {
                        identity = false;
                        Console.WriteLine("Elements in the arrays are not identical!");
                        break;
                    }
                }
                Console.WriteLine("The arrays are identical: {0}", identity);
            }
            else
            {
                Console.WriteLine("The arrays have different lengths so they are not equal...!");
            }

        }
    }
}
