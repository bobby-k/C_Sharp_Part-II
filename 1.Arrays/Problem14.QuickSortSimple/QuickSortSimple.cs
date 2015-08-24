using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace Problem14.QuickSortSimple
{
    class QuickSortSimple
    {
        // Write a program that sorts an array of integers using the Quick sort algorithm.

        // Логика-Simple version: много подобно на сортирането със сливане като тук най-важно е определянето на главният елемент - pivot,  
        // в най-добрият случай той е средният по големина елемент на масива.Има различни начини за определяне на главен елемент като 
        // идеята е да се избегне най-малкия или най-големия елемент.Тук ще използваме за главен елемент средата на масива(но той може да
        // е и напълно произволен).

        // сортирането протича по следния начин: вземаме главен елемент и го премахваме от списъка, създаваме нови два списъка където ще 
        // записваме съответно по-малките и по-големите елементи сравнени с pivot-а.Рекурсивно ще повторим това действие докато ни остане
        // само 1 елемент след това ще го подадем на метода който ще съединява вече сортираните по-малки и по-големи елементи
        static List<int> QuickSorting(List<int> array)
        {
            // дъно на рекурсията
            if (array.Count <= 1)
            {
                return array;
            }

            int initialIndex = 0;
            int pivotIndex = initialIndex + ((array.Count - 1) - initialIndex) / 2;
            int pivotElement = array[pivotIndex];

            array.Remove(pivotElement);

            List<int> less = new List<int>();
            List<int> greater = new List<int>();

            foreach (int element in array)
            {
                if (element <= pivotElement)
                {
                    less.Add(element);
                }
                else
                {
                    greater.Add(element);
                }
            }
            
            return Concatenate(QuickSorting(less), pivotElement, QuickSorting(greater));
        }

        static List<int> Concatenate(List<int> less, int pivot, List<int> greater)
        {
            List<int> quickSortedList = new List<int>();
            quickSortedList.AddRange(less);
            quickSortedList.Add(pivot);
            quickSortedList.AddRange(greater);
            quickSortedList.TrimExcess();

            return quickSortedList;
        }

        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            List<int> arr = new List<int>() { 5, 3, 2, 8, 7, 6, 1, 9, 4 };
            arr.TrimExcess();

            Console.WriteLine("Before: " + string.Join(", ", arr));
            Console.WriteLine(" After: " + string.Join(", ", QuickSorting(arr)));

        }
    }
}
