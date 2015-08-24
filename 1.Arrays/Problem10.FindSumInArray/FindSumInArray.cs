using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace Problem10.FindSumInArray
{
    class FindSumInArray
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            // Write a program that finds in given array of integers a sequence of given sum S (if present).

            // Логика:Ще използваме алгоритъма от вариант1 на зад.8 MaximalSum, а именно да намерим всички възможни комбинации,
            // после сумите на всяка една поотделно и накрая ще търсим подадената сума S в списъка със сумите, ако я има ще изпишем
            // комбинацията която дава тази сума, ако я няма ще изпише че не съществува комбинация с такава сума в дадения масив

            Console.Write("Enter the length of the array: ");
            int length = int.Parse(Console.ReadLine());

            int[] numbers = new int[length];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }
            
            Console.Write("Enter the sum you are looking for: ");
            int S = int.Parse(Console.ReadLine());

            // тук ще трупаме текуща сума,която първоначално е само ст-та на нулевият елемент
            int currentSum = numbers[0];
            // тук ще записваме индексите за начало и край на поредицата с най-добра сума
            int startIndex = 0;
            int endIndex = 0;

            #region Записване на индексите за начало и край на всички възможни поредици
            List<int> startAndEndIndexes = new List<int>();

            // добавяме първоначалният индекс
            startAndEndIndexes.Add(startIndex);

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    // към текущата сума добавяме ст-та на поредният елемент
                    currentSum += numbers[j];
                    // записваме текущата итерация на цикъла като индекс за край 
                    endIndex = j;
                    // добавяме го в листа
                    startAndEndIndexes.Add(endIndex);
                    // проверяваме ако индекса за край е равен на индекса на последният елемент в масива
                    if (endIndex == numbers.Length - 1)
                    {
                        // увеличаваме индекса за начало тъй като значи,че започваме нова поредица от комбинации без най-левият елемент
                        startIndex++;
                    }
                    // добавяме го в списъка
                    startAndEndIndexes.Add(startIndex);
                }
                // при всяко излизане от вътрешният цикъл зануляваме текущата сума тъй като започваме нова поредица от комбинации без
                // най-левият елемент
                currentSum = 0;
            }

            // премахваме последният елемент в листа тъй като не ни е необходим и освобождаваме заделената памет която не се използва
            startAndEndIndexes.RemoveAt(startAndEndIndexes.Count - 1);
            startAndEndIndexes.TrimExcess();
            #endregion

            #region Сглобяване на всички поредици
            List<int[]> allSequences = new List<int[]>();

            // тук ще се определя дължината на всеки масив който ще записваме
            int length1 = 2;
            // максимален брой елементи в комбинация
            int maxElementsInComb = numbers.Length;

            // ще минаваме по индексите за начало, които са всеки втори от списъка
            for (int i = 0; i < startAndEndIndexes.Count; i += 2)
            {
                // ще записваме елементите на всяка комбинация в един временен масив
                int[] sequence = new int[length1];
                // на всеки индекс за начало ще тръгва нов цикъл от това начало до съответният край
                int index = 0;
                for (int j = startAndEndIndexes[i]; j <= startAndEndIndexes[i + 1]; j++)
                {
                    // и ще записва елемента от главния масив във временния, така на края на цикъла получаваме цялата комбинация
                    sequence[index] = numbers[j];
                    index++;
                }
                // добавяме я в списъка
                allSequences.Add(sequence);
                // увеличаваме дължината на следващият временен масив с един елемент
                length1++;
                // проверяваме ако дължината е по-голяма от максималният брой елементи в комбинацията
                if (length1 > maxElementsInComb)
                {
                    // зануляваме дължината(тя може да е най-малко два елемента за да има поредица)
                    length1 = 2;
                    // намаляваме макс. брой елементи с 1 тъй като при следващото завъртане на цикъла ще се ползва 1 елемент по-малко
                    maxElementsInComb--;
                }
            }

            // освобождаваме заделената, но неизползвана памет
            allSequences.TrimExcess();
            #endregion

            #region Намиране сумите на всяка поредица по отделно
            List<int> allSums = new List<int>();

            int sum = 0;

            // за всяка поредица/комбинация която сме записали пускаме цикъл който да сумира всички елементи
            foreach (int[] sequence in allSequences)
            {
                for (int i = 0; i < sequence.Length; i++)
                {
                    sum += sequence[i];
                }
                // записваме сумите като елементи в нов списък
                allSums.Add(sum);
                // зануляваме сумата
                sum = 0;
            }

            // накрая освобождаваме заделената но неупотребена памет
            allSums.TrimExcess();
            #endregion

            #region Намиране на поредицата с търсената сума

            int bestSeqIndex = allSums.IndexOf(S);

            #endregion

            // тъй като ако няма индекс със търсената сума S метода IndexOf ще върне -1 затова:
            if (bestSeqIndex > 0)
            {
                Console.WriteLine("{0}", string.Join(", ", allSequences[bestSeqIndex]));
            }
            else
            {
                Console.WriteLine("There is no sequence with the sum you specified!!!");
            }

        }
    }
}
