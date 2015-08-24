using System;
using System.Globalization;
using System.Threading;

namespace Problem2.MaximalSum
{
    class MaximalSum
    {
        // Write a program that reads a rectangular matrix of size N x M and finds in it the square 3 x 3 
        // that has maximal sum of its elements.

        // Логика: ще обходим матрицата вземайки първият елемент и ще го събираме със следващите два,после със трите елемента под тях
        // и накрая с трите елемента под предишните три, получената сума ще сравняваме със текущата най-голяма и по-голямото число ще 
        // бъде най-голямата сума.След като сме намерили най-голяма сума трябва да си отбележим къде започва за да може по-късно да 
        // намерим елементите чиито сбор я съставя.
        // P.S.Обхождането трябва да се случва без последните два елемента за редовете и за колоните, за да се избегне излизане от 
        // границите на матрицата
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            Console.Write("Please enter the width of the matrix: ");
            int M = int.Parse(Console.ReadLine());

            Console.Write("Please enter the height of the matrix: ");
            int N = int.Parse(Console.ReadLine());

            int[,] matrix = new int[N, M];

            // инициализираме матрицата
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("matrix[{0},{1}] = ", row, col);
                    matrix[row, col] = int.Parse(Console.ReadLine());
                }
            }

            // тук ще пишем най-голямата намерена сума, първоначалната и стойност трябва да е такава че да не е по-голяма от нито една 
            // от въведените ст-ти, т.е. минималната за този тип данни ст-ст
            int bestSum = int.MinValue;
            // тук ще пишем къде започва най-голямата ни сума
            int bestSumRow = 0;
            int bestSumCol = 0;
            // тук ще пишем текущата сума
            int sum = 0;

            // тъй като търсим квадрат 3х3(1 елемент+следващите 2) ще проверяваме всички редове и всички колони без последните 2, така 
            // ще имаме всички възможни комбинации от 3х3 и няма да излезем от границите на матрицата в никой случай
            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    sum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] +
                          matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] +
                          matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                    // ако намерим най-голяма сума, записваме къде започва
                    if (sum > bestSum)
                    {
                        bestSum = sum;
                        bestSumRow = row;
                        bestSumCol = col;
                    }
                }
            }

            // зачиства екрана преди да отпечата резултата
            Console.Clear();

            // знаейки къде започва най-голямата сума и факта че търсим 3х3 квадрат можем лесно да намерим съответните елементи за да ги
            // отпечатаме по подходящ начин на потребителя
            Console.WriteLine("Your best 3x3 square is:");
            Console.WriteLine(new string('*', 24));
            Console.WriteLine("{0,4}{1,4}{2,4}", matrix[bestSumRow, bestSumCol], matrix[bestSumRow, bestSumCol + 1], matrix[bestSumRow, bestSumCol + 2]);
            Console.WriteLine("{0,4}{1,4}{2,4}", matrix[bestSumRow + 1, bestSumCol], matrix[bestSumRow + 1, bestSumCol + 1], matrix[bestSumRow + 1, bestSumCol + 2]);
            Console.WriteLine("{0,4}{1,4}{2,4}", matrix[bestSumRow + 2, bestSumCol], matrix[bestSumRow + 2, bestSumCol + 1], matrix[bestSumRow + 2, bestSumCol + 2]);
            Console.WriteLine(new string('*', 24));
            Console.WriteLine("The sum is {0}", bestSum);
        }
    }
}
