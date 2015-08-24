using System;
using System.Globalization;
using System.Threading;
using System.Linq;

namespace Problem5.SortByStringLength
{
    class SortByStringLength
    {
        // You are given an array of strings. 
        // Write a method that sorts the array by the length of its elements (the number of characters composing them).
        static string[] SortByLength(string[] array)
        {
            array = array.OrderBy(t => t.Length).ToArray();

            return array;
        }
        static void Print(string[] array)
        {
            foreach (string text in array)
            {
                Console.WriteLine(text);
            }
        }
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            string[] texts = 
            {
                "abc",
                "ab",
                "a",
                "b"
            };

            texts = SortByLength(texts);

            // принтира вече сортираният масив
            Print(texts);
        }

    }
}
