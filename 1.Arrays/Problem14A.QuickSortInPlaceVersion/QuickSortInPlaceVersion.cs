using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace Problem14A.QuickSortInPlaceVersion
{
    class QuickSortInPlaceVersion
    {
        // Write a program that sorts an array of integers using the Quick sort algorithm.

        // Логика - In-Place Version: Този вариант е оптимизация на Simple version.Тук ще работим със самия масив без да заделяме нова 
        // памет за допълнителни масиви, в които да пазим по-малките и по-големите от главния елементи.
        // Ще имаме два метода:

        // ==> QuickSort метод ще избира главен елемент.Извиквайки Partition метод-а ще получава новият индекс на главният елемент и ще 
        // се повтаря рекурсивно след това за лявата си половина и за дясната си такава, а тези две половини ще се определят от новият
        // индекс върнат от Partition метод-а.

        // ==> Partition - ще разменя главният елемент с последния в масива, после ще сравнява всички останали елементи започвайки от 
        // най-левият и ако текущият елемент е по-малък от главния ще го разменяме с най-левият.На всяка такава стъпка (текущият
        // елемент е по-малък от главния) ще преместваме най-левият елемент с една позиция на дясно.Накрая ще разменим главният елемент
        // (последният) с най-левият, който вече не е найстина най-ляв и така ще получим същият масив но почти сортиран,т.е. от ляво на
        // главният елемент ще са всички по-малки от него а отдясно - всички по-големи.Като резултат Partition метод-а ще връща новият 
        // индекс на главният елемент.
        
        static int Partition(int[] array, int left, int right, int pivotIndex)
        {
            int pivotValue = array[pivotIndex];
            // преместваме "главния" елемент в края
            int temp = array[right];
            array[right] = array[pivotIndex];
            array[pivotIndex] = temp;
            
            for (int i = left; i < array.Length - 1; i++)
            {
                if (array[i] < pivotValue)
                {//размени array[i] и array[left]
                    temp = array[left];
                    array[left] = array[i];
                    array[i] = temp;
                    left++;
                }
            }
            // размени array[left] и array[right] , т.е. сложи "главния" елемент така че да разделя по-малките от него и по-големите
            temp = array[right];
            array[right] = array[left];
            array[left] = temp;

            return left;
        }

        static int[] QuickSort(int[] array, int left, int right) 
        {
            if (left < right)
            {
                int pivotIndex = left + ((right - left) / 2);
                int pivotNewINdex = Partition(array, left, right, pivotIndex);

                QuickSort(array, left, pivotNewINdex - 1); // сортиране на лявата "половина"
                QuickSort(array, pivotNewINdex + 1, right); // сортиране на дясната "половина"

            }

            return array;
        }

        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            //int[] arr = { 3, 7, 8, 5, 2, 1, 9, 5, 4 };
            //int[] arr = { 6, 5, 3, 1, 8, 7, 2, 4 };
            int[] arr = { 5, 3, 2, 8, 7, 6, 1, 9, 4 };

            Console.WriteLine("Before: " + string.Join(", ", arr));
            Console.WriteLine(" After: " + string.Join(", ", QuickSort(arr, 0, arr.Length - 1)));
        }
    }
}
