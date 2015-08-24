using System;
using System.Globalization;
using System.Threading;

namespace Problem4.BinarySearch
{
    class BinarySearch
    {
        // Write a program, that reads from the console an array of N integers and an integer K, 
        // sorts the array and using the method Array.BinSearch() finds the largest number in the array which is <= K.

        // Логика:Според MSDN, Array.BinarySearch() връща индекса на търсеният елемент, ако е намерен.Но ако не е и търсеният елемент е 
        // по-малък от един или повече елемента на масива, връща отрицателно число което представлява индекса(побитово обърнат,т.е. 0-те
        // са 1-ци,а 1-ците са 0-и, чрез "~" оператора) на първият елемент който е по-голям от търсения.Ако пък тръсената стойност е 
        // по-голяма от който и да е елемент на масива връща отрицателно число което представлява побитово обърнат индекса на последния
        // елемент + 1.Изхождайки от това след като сме извикали метода Array.BinarySearch() ще проверяваме резултата който ни се връща.
        // Ако е положителен даваме съответният индекс на който се намира елемента, но ако е отрицателен ще правим една допълнителна 
        // проверка дали индекса е 0, тъй като ако е нула(т.е. първият елемент на масива) а ние търсим елемента който е по-малък то  
        // значи че такъв няма.Във всички други случаи значи сме след първият елемент и можем да върнем елемента който е по-малък от 
        // НЕ НАМЕРЕНИЯ такъв
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;


            Console.Write("Please enter a number for size of the array: ");
            int N = int.Parse(Console.ReadLine());

            // инициализираме масива
            int[] arr = new int[N];
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("arr[{0}] = ", i);
                arr[i] = int.Parse(Console.ReadLine());
            }

            // сортираме 
            Array.Sort(arr);

            // изчистваме екрана 
            Console.Clear();

            Console.Write("Please enter value you want to find: ");
            int K = int.Parse(Console.ReadLine());

            // търсим въведената ст-ст
            int index = Array.BinarySearch(arr, K);

            if (index < 0)
            {
                // ако върнатият резултат е отрицателен,значи е побитово обърната стойност на реален индекс, за да получим този индекс 
                // ние трябва да обърнем битовете му, така ще стане положително число представляващо индекса на стойността която е 
                // първата по-голяма от търсената

                index = ~index;

                Console.WriteLine("The value you're looking for does not exist...");

                if (index == 0)
                {
                    Console.WriteLine("...and there is no value in this array that is lower than the value you just looked up!");
                }
                else
                {
                    // изваждаме 1 от index понеже търсим първата по-малка стойност от НЕ НАМЕРЕНАТА такава
                    Console.WriteLine("...but the closest value lower than it, is: {0} and it is at index {1}", arr[index - 1], index - 1);
                }

            }
            else
            {
                Console.WriteLine("The value you're looking up is at index {0}", index);
            }
        }
    }
}
