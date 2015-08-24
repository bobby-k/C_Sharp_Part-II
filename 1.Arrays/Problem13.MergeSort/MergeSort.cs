using System;
using System.Globalization;
using System.Threading;

namespace Problem13.MergeSort
{
    class MergeSort
    {
        // Write a program that sorts an array of integers using the Merge sort algorithm.

        // Логика: създаваме два отделни метода - един който ще разделя масива и друг който ще го съединява вече сортиран.
        // Първият метод (разделящият) ще разцепва по средата масива и ще записва двете половини в нови два масива Ляв и Десен и така ще
        // се повтаря докато масивите станат от по 1 елемент, след което ще ги подава на вторият метод (съединяващият) а той ще ги
        // слепва сортирайки ги.Първо ще се разделят рекурсивно всички леви масиви после ще се мърджнат и след това ще се разделят 
        // рекурсивно всички десни масиви и ще се мърджнат,накрая ще се мърджне първият(при най-първото делене) ляв с първият десен и ще
        // се подаде резултата (вече сортирания масив) за отпечатване
        // За повече подробности виж на http://bg.wikipedia.org/wiki/%D0%A1%D0%BE%D1%80%D1%82%D0%B8%D1%80%D0%B0%D0%BD%D0%B5_%D1%87%D1%80%D0%B5%D0%B7_%D1%81%D0%BB%D0%B8%D0%B2%D0%B0%D0%BD%D0%B5

        // тъй като за момента се предполага, че методи не се знаят е хубаво да се погледне лекцията за методи а също и тази за рекурсия
        // за да се разбере в подробности какво всъщност се случва
        static int[] Split(int[] arr)
        {
            // дъно на рекурсията
            if (arr.Length == 1)
            {
                return arr;
            }

            int middle = arr.Length / 2;
            int[] leftSide = new int[middle];
            int[] rigthSide = new int[arr.Length - middle];

            // запълваме лявата половина
            for (int i = 0; i < leftSide.Length; i++)
            {
                leftSide[i] = arr[i];
            }
            // запълваме дясната половина
            for (int i = middle, j = 0; i < arr.Length; i++, j++)
            {
                rigthSide[j] = arr[i];
            }

            leftSide = Split(leftSide);
            rigthSide = Split(rigthSide);

            return Merge(leftSide, rigthSide);
        }

        static int[] Merge(int[] left, int[] right)
        {
            int leftCounter = 0;
            int rightCounter = 0;
            int[] mergeSortedArray = new int[left.Length + right.Length];

            for (int i = 0; i < mergeSortedArray.Length; i++)
            {
                if (leftCounter == left.Length || ((rightCounter < right.Length) && left[leftCounter] >= right[rightCounter]))
                {
                    mergeSortedArray[i] = right[rightCounter];
                    rightCounter++;
                }
                else if (rightCounter == right.Length || ((leftCounter < left.Length) && left[leftCounter] <= right[rightCounter]))
                {
                    mergeSortedArray[i] = left[leftCounter];
                    leftCounter++;
                }
            }

            return mergeSortedArray;
        }

        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            //int[] arr = { 6, 5, 3, 1, 8, 7, 2, 4 };
            int[] arr = { 9, 6, 3, 1, 5, 2, -1 };


            Console.WriteLine(string.Join(", ", arr));
            Console.WriteLine(string.Join(", ", Split(arr)));

        }
    }
}
