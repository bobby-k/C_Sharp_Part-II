using System;
using System.Collections;
using System.Globalization;
using System.Threading;

namespace Problem7.LargestAreaInMatrix
{
    class LargestAreaInMatrix
    {
        // Write a program that finds the largest area of equal neighbor elements in a rectangular matrix and prints its size.
        // Hint: you can use the algorithm Depth-first search or Breadth-first search.

        // Логика: Ще взимаме всеки елемент на матрицата и ще проверяваме рекурсивно дали има съседен равен на него, ако да увеличаваме 
        // текущата поредица и отбелязваме че вече сме проверили този елемент по някакъв начин.След като имаме дължина на текуща поредица 
        // ще я сравняваме с най-голямата дължина намерена до момента(първоначално тя ще е 0) и ако е по-голяма, най-голямата поредица 
        // ще става текущата, тогава ще си отбележим и кой е елемента който я съставя...

        // декларираме си глобални променливи които всеки метод ще ползва 
        static int[,] matrix;
        static int currentLength = 0, currentElement = 0;

        // с този метод ще търсим най-голямата поредица от съседни равни елементи
        static void FindLargestAreaLength(int[,] matrix)
        {
            int bestLength = 0, bestNumber = 0;
            // ще вземаме поредният елемент, и за всеки такъв ще извикваме метода който ще намира текущата дължина на поредицата
            // след това имайки текущата дължина ще проверим дали тя е най-голяма, ако да си записваме текущият елемент който 
            // изгражда поредицата
            for (int row = 0; row < matrix.GetLongLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLongLength(1); col++)
                {
                    currentElement = matrix[row, col];
                    currentLength = 0;

                    GetCurrentAreaLength(row, col);

                    if (currentLength > bestLength)
                    {
                        bestLength = currentLength;
                        bestNumber = currentElement;
                    }
                }
            }
            // на края показваме на потребителя колко е дълга най-голямата поредица от съседни равни елементи и кой е този елемент
            Console.WriteLine("Largest area's number {0} --> {1} times", bestNumber, bestLength);
        }

        // с този метод ще получаваме дължината на текущата поредица
        static void GetCurrentAreaLength(int row, int col)
        {
            // Aко се намираме извън матрицата или на елемент който вече е бил проверен за съседност метода се прекратява.Това ще бъде
            // дъното на рекурсията с помощта на която ще намираме всички съседни равни елементи.
            if (row < 0 || row >= matrix.GetLength(0) ||
                col < 0 || col >= matrix.GetLength(1) ||
                matrix[row, col] == int.MinValue) return;

            // ако елемента в матрицата е равен на текущия
            if (matrix[row, col] == currentElement)// това първоначално ще сравнява текущият елемент със себе си, но ще е от полза при рекурсията тъй като тя ще проверява за елемента отгоре, долу, ляво или дясно 
            {
                // ще го отбелязваме, че е съседен, равен и проверен като го променим на минималната за типа стойност
                matrix[row, col] = int.MinValue;

                currentLength++;

                // рекурсивно проверяваме за равни елементи нагоре от текущия
                GetCurrentAreaLength(row - 1, col);    // up

                // рекурсивно проверяваме за равни елементи надолу от текущия
                GetCurrentAreaLength(row + 1, col);    // down
                
                // рекурсивно проверяваме за равни елементи наляво от текущия
                GetCurrentAreaLength(row, col - 1);    // left
                
                // рекурсивно проверяваме за равни елементи надясно от текущия
                GetCurrentAreaLength(row, col + 1);    // right
            }
        }

        // този метод ще принтира матрицата за да се убеди потребителя във верността на получените данни
        static void Print(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("{0} ", matrix[row, col]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void Main()
        {
            matrix = new int[,]
		    {
			    { 1, 3, 2, 2, 2, 4 },
			    { 3, 3, 3, 2, 4, 4 },
			    { 4, 3, 1, 2, 3, 3 },
			    { 4, 3, 1, 3, 3, 1 },
			    { 4, 3, 3, 3, 1, 1 }
		    };

            Print(matrix);
            FindLargestAreaLength(matrix);
        }

        // с помощта на lnikod4s
    }
}
