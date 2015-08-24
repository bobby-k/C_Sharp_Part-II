using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace Problem9.FrequentNumber
{
    class FrequentNumber
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            // Write a program that finds the most frequent number in an array.

            // Примерни масиви за сравняване
            //int[] arr = { 4, 4, 4, 4, 4, 4, 4, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            int[] arr = { 4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3 };
            //int[] arr = { 3, 3, 5, 4, 3, 4, 4, 4, 5, 3, 2, 2, 5, 5 };
            //int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };

            // Логика: Ще сортираме масива, така всички равни ст-ти ще се подредят от ляво на дясно по големина.След това ще пребройм 
            // всички редици и ще запишем в List всеки повтарящ се елемент и колко пъти се повтаря.След това ще намерим най-много 
            // повтарящият се и ще проверим за други елементи които да се повтарят същият брой пъти.Накрая ще отпечатаме съответното 
            // съобщение на конзолата

            // ще копираме масива в нов такъв за да може накрая да изкараме на екрана първоначалния масив 
            int[] arr1 = (int[])arr.Clone();

            // сортираме
            Array.Sort(arr1);

            // тук ще записваме всеки повтарящ се елемент и колко пъти се повтаря
            List<int> countedElements = new List<int>();

            // започваме с добавяне на нулевият елемент в List-а, тъй като цикъла който ще обхожда масива ще започва от първият елемент
            // за да може да сравнява предходния такъв
            countedElements.Add(arr1[0]);

            // тук ще бройм колко пъти се среща дадения елемент
            int count = 1;
            for (int i = 1; i < arr1.Length; i++)
            {
                // ако текущия и предходния елемент са равни 
                if (arr1[i] == arr1[i - 1])
                {
                    // увеличаваме броя срещания
                    count++;
                }
                // иначе, значи сме започнали с друг елемент
                else
                {
                    // записваме текущия брой повторения
                    countedElements.Add(count);
                    // записваме новият елемент 
                    countedElements.Add(arr1[i]);
                    // нулираме брояча и започваме да бройм наново
                    count = 1;
                }
            }

            // след като пребройм и последния елемент излизаме от цикъла.Трябва да запишем и последното преброяване
            countedElements.Add(count);

            // започваме да търсим най-много повтарящият се елемент
            int biggestLength = 0;
            int mostFrequentNumber = 0;
            for (int i = 1; i < countedElements.Count; i += 2)
            {
                if (countedElements[i] > biggestLength)
                {
                    biggestLength = countedElements[i];
                    mostFrequentNumber = countedElements[i - 1];
                }
            }

            // следва проверка за други елементи със същият брой повторения, ако има такива се сравнява с най-многото намерени повторения
            bool moreEqualLengths = false;

            for (int i = 1; i < countedElements.Count - 2; i += 2)
            {
                if (countedElements[i] == countedElements[i + 2])
                {
                    if (countedElements[i] >= biggestLength)
                    {
                        moreEqualLengths = true;
                    }
                }
            }

            // накрая последни проверки
            // ако най-големият брой повторения е 1, значи няма често повтарящ се елемент
            if (biggestLength == 1)
            {
                Console.WriteLine(string.Join(", ", arr));
                Console.WriteLine("There are no frequent numbers in the array above.");
                Console.WriteLine("All numbers appear only once...");
            }
            // иначе ако най-големият брой повторения е повече проверяваме дали има други елементи със същият брой повторения
            else if (biggestLength > 1)
            {
                // ако да просто отпечатваме колко е най-голямата честота 
                if (moreEqualLengths)
                {
                    Console.WriteLine(string.Join(", ", arr));
                    Console.WriteLine("There is more than one number that appears frequently.");
                    Console.WriteLine("The biggest frequency is: {0} times", biggestLength);
                }
                // иначе печатаме най-срещания елемент и колко пъти е намерен
                else
                {
                    Console.WriteLine(string.Join(", ", arr));
                    Console.WriteLine("The most frequent number in the array above is: {0} ({1} times)", mostFrequentNumber, biggestLength);
                }
            }
        }
    }
}
