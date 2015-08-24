using System;
using System.Globalization;
using System.Threading;

namespace Problem1.FillTheMatrix
{
    class FillTheMatrix
    {
        // Write a program that fills and prints a matrix of size (n, n) as shown below:

        //     (a)            (b)           (c)             (d*)
        //  1 5  9 13      1 8  9 16     7 11 14 16       1 12 11 10
        //  2 6 10 14      2 7 10 15     4  8 12 15       2 13 16  9
        //  3 7 11 15      3 6 11 14     2  5  9 13       3 14 15  8
        //  4 8 12 16      4 5 12 13     1  3  6 10       4  5  6  7                       

        // Логика: ще създадем отделен метод за всеки един вариант + един метод за принтиране така няма да повтаряме код и няма да има
        // нужда да се закоментирва и после разкоментира всеки отделен вариант, просто ще подаваме в Main-а различните варианти

        // глобална променлива - всички методи ще я ползват
        static int currentInput = 1;
        static void Print(int[,] matrix)
        {
            // При принтиране трябва да се върви първо по редовете, т.е. първо се принтира цял ред и след това се ходи на другия
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    // форматираме за по-добра визуализация
                    Console.Write("{0,4}", matrix[rows, cols]);
                }
                Console.WriteLine();
            }

        }
        static int[,] VariantA(int[,] matrix)
        {
            currentInput = 1;
            // Попълва матрицата като тръгва първо по колоните, и като попълни цяла колона ходи на следващата
            for (int cols = 0; cols < matrix.GetLength(0); cols++)
            {
                for (int rows = 0; rows < matrix.GetLength(1); rows++)
                {
                    matrix[rows, cols] = currentInput;
                    currentInput++;
                }
            }

            return matrix;
        }
        static int[,] VariantB(int[,] matrix)
        {
            currentInput = 1;
            for (int cols = 0; cols < matrix.GetLength(1); cols++)
            {
                if (cols % 2 == 0) // ако е на четна колона
                {// ще се върти нормално 
                    for (int rows = 0; rows < matrix.GetLength(0); rows++)
                    {
                        matrix[rows, cols] = currentInput;
                        currentInput++;
                    }
                }
                else
                {// ще се върти наобратно
                    for (int rows = matrix.GetLength(0) - 1; rows >= 0; rows--)
                    {
                        matrix[rows, cols] = currentInput;
                        currentInput++;
                    }
                }
            }

            return matrix;
        }
        static int[,] VariantC(int[,] matrix)
        {
            currentInput = 1;

            // тук се определя началната позиция на обхождането
            int col = 0;
            int row = matrix.GetLength(0) - 1;
            // тук ще бройм колко реда да скочим нагоре когато попълним текущият диагонал
            int counter = 1;
            // първият диагонал е винаги от 2 елемента и расте с един до средата
            int diagonal = 2;
            // тук ще определим кога сме стигнали средата, за да намаляваме диагонала
            bool middleDiagonal = false;

            // сетваме първият елемент и при всяко сетване увеличаваме текущото число
            matrix[row, col] = currentInput;
            currentInput++;
            // скачаме един ред нагоре и започваме да попълваме диагоналите
            row -= counter;
            // при следващото скачане ще трябва да се качим с 2 реда
            counter++;

            // ще попълваме диагоналите докато не стигнем последният елемент на матрицата които в такъв случай е върхът срещуположен на 
            // началната позиция
            while (col < matrix.GetLength(1) && row >= 0)
            {
                // попълваме диагоналите
                for (int i = 0; i < diagonal; i++)
                {
                    matrix[row, col] = currentInput;
                    currentInput++;
                    row++;
                    col++;
                }

                // след всеки завършен диагонал ще проверяваме дали сме на средата,т.е. диагоналът е равен на която и да е страна на 
                // матрицата тъй като тя е квадратна "a matrix of size (n, n)"
                if (diagonal == matrix.GetLength(0))
                {
                    // ако "да" означаваме че сме стигнали средата
                    middleDiagonal = true;
                    // намаляваме брояча на редовете с 1 понеже той ще се е увеличил на предходното влизане в цикъла,така ще се върнем на последния ред от където ще трябва да скочим на първият,т.е. нулевият
                    counter--;
                    // намаляваме дължината на диагонала
                    diagonal--;
                }
                // иначе ако сме след средата 
                else if (middleDiagonal)
                {
                    // намаляваме броят на редовете с 2 така всеки път ще се връщаме на нулевия ред, но в съответната колона
                    counter -= 2;
                    // диагонала трябва да намалява с 1 на всяко повторение след средата
                    diagonal--;
                }
                // във всички останали случаи значи сме преди средата и диагонала трябва да се увеличава
                else
                {
                    diagonal++;
                }

                // след всички проверки настроиваме следващата позиция на "поредният" елемент
                col -= counter;
                row -= ++counter;
            }

            return matrix;
        }
        static int[,] VariantD(int[,] matrix)
        {
            currentInput = 1;

            // тук сетваме началната позиция на обхождането
            int row = 0;
            int col = 0;
            // тук вземаме страната на матрицата, която и да е тъй като тя е квадратна
            int side = matrix.GetLength(0) - 1; // или matrix.GetLength(1) - 1; все тая те са равни
            // последният допустим индекс е този при който свършва въртенето и започва нова навивка на спиралата
            int lastAllowedIndex = 0;

            // ще се навива докато стигнем последният елемент, т.е. n*n
            while (currentInput <= matrix.Length)
            {
                while (row <= side)      // going down
                {
                    matrix[row, col] = currentInput;
                    currentInput++;
                    row++;
                }
                row--;  // връща на правилната позиция редът тъй като при последното завъртане той се е увеличил с един път повече

                col++;  // отива в поредната колона
                while (col <= side)      // going right
                {
                    matrix[row, col] = currentInput;
                    currentInput++;
                    col++;
                }
                col--;  // връща на правилната позиция колоната тъй като при последното завъртане тя се е увеличила с един път повече

                row--;  // започва от по-горният ред
                while (row >= lastAllowedIndex)        // going up
                {
                    matrix[row, col] = currentInput;
                    currentInput++;
                    row--;
                }
                row++;  // връща на правилната позиция редът тъй като при последното завъртане той се е намалил с един път повече

                col--;  // започва от предходната колона  
                while (col > lastAllowedIndex)        // going left
                {
                    matrix[row, col] = currentInput;
                    currentInput++;
                    col--;
                }
                col++;  // връща на правилната позиция колоната тъй като при последното завъртане тя се е намалила с един път повече

                // вече имаме една пълна навивка трябва да минем на по-долен ред в същата колона където сме приключили за да навиваме отново
                row++;

                // при всяка навивка страната намалява
                side--;
                // при всяка навивка последният допустим индекс се увеличава
                lastAllowedIndex++;
            }

            return matrix;
        }
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            Console.Write("Please enter number for rows and columns in the matrix: ");
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            Console.WriteLine("a)");
            VariantA(matrix);
            Print(matrix);

            Console.WriteLine("b)");
            VariantB(matrix);
            Print(matrix);

            Console.WriteLine("c)");
            VariantC(matrix);
            Print(matrix);

            Console.WriteLine("d)");
            VariantD(matrix);
            Print(matrix);
        }


    }
}
