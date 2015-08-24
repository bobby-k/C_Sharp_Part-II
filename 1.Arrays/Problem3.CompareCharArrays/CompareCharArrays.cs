using System;
using System.Globalization;
using System.Threading;

namespace Problem3.CompareCharArrays
{
    class CompareCharArrays
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            // Write a program that compares two char arrays lexicographically (letter by letter).

            char[] arr1 = { 'а', 'н', 'г', 'л', 'и', 'я' };
            char[] arr2 = { 'а', 'н', 'д', 'о', 'р', 'а' };

            //char[] arr1 = { 'а', 'н', 'г', 'л', 'и', 'я' };
            //char[] arr2 = { 'А', 'н', 'д', 'о', 'р', 'а' };

            // Логика:Подобно на зад.2 за да са равни двата масива - трябва дължините им да са равни и елементите - еднакви, но при 
            // лексикографската подредба в случай, че дължините им са равни се сравняват елементите според номера под който се явяват в
            // ASCII таблицата съответно колкото по-малък номер толкова по-голям елемент

            string biggestArray = "";

            if (arr1.Length == arr2.Length)
            {
                for (int i = 0; i < arr1.Length; i++)
                {
                    if (arr1[i] < arr2[i])
                    {
                        biggestArray = string.Join(", ", arr1);
                        break;
                    }
                    else if (arr1[i] > arr2[i])
                    {
                        biggestArray = string.Join(", ", arr2);
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                Console.WriteLine("The bigger array is \"{0}\"", biggestArray);
            }
            else
            {
                if (arr1.Length > arr2.Length)
                {
                    Console.WriteLine("The bigger array is \"{0}\" because it has bigger length", string.Join(", ", arr1));
                }
                else
                {
                    Console.WriteLine("The bigger array is \"{0}\" because it has bigger length", string.Join(", ", arr2));
                }
            }
        }
    }
}
