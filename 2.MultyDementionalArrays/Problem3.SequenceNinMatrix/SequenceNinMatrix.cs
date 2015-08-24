using System;
using System.Globalization;
using System.Threading;

namespace Problem3.SequenceNinMatrix
{
    class SequenceNinMatrix
    {
        // We are given a matrix of strings of size N x M. 
        // Sequences in the matrix we define as sets of several neighbor elements located on the same line, column or diagonal.
        // Write a program that finds the longest sequence of equal strings in a matrix.

        // Логика: ще вземем първият елемент и ще срявняваме следващият до него,ако са равни имаме поредица,проверяваме следващият, ако
        // пак са равни, увеличаваме дължината на поредицата,ако пък не са,връщаме се на началният ни елемент и го сравняваме с този под
        // него, пак същата идея-ако са равни, имаме поредица,проверяваме следващият, ако пак са равни увеличаваме дължината на 
        // поредицата,ако пък не са, връщаме се на началният ни елемент и го сравняваме с този по диагонала съответно пак същата идея (
        // сравняваме ако = увеличаваме дължината, ако не връщаме се на началният елемент),така ще сме проверили за първият елемент 
        // всички варианти за поредици започващи от него на дясно,на долу и по диагонал и съответно минаваме на следващият елемент.Така
        // ще проверим за всички елементи от матрицата ни като намерената най-голяма дължина ще записваме заедно с ред и колона където 
        // започва.Накрая ще отпечатаме най-голямата намерена поредица,като просто отпечатаме елемента в началото й,толкова пъти колкото
        // е дължината й.
        // P.S. да се внимава за излизане от рамките на матрицата при търсенето на поредици надясно, надолу и по диагонал

        // тъй като се очаква да има доста повтарящи се действия ще си направим отделни методи за всяко действие,започваме с някои 
        // глобални променливи до които всеки метод ще има видимост
        static int length = 1;
        static int bestRow = 0;
        static int bestCol = 0;

        // тук ще се случва търсенето за поредица надясно
        static int FindSequenceRight(string[,] matrix, int row, int col)
        {
            // зануляваме текущата дължина
            length = 1;
            // ако си на последният елемент,не прави нищо - върни дължината
            // така се  избягва излизане от границите на матрицата
            if (col != matrix.GetLength(1) - 1)
            {
                // проверяваме двата съседни елемента дали са равни,ако да увеличаваме дължината(имаме поредица) и пускаме цикъл да 
                // проверява така до края на колоните в матрицата, т.е. надясно;ако пък не са равни връщаме текущата дължина
                if (matrix[row, col] == matrix[row, col + 1])
                {
                    length++;
                    int tempCol = col;
                    tempCol++;
                    while (tempCol < matrix.GetLength(1) - 1)
                    {
                        if (matrix[row, tempCol] == matrix[row, tempCol + 1])
                        {
                            length++;
                        }
                        else
                        {
                            // ако поредният елемент не е равен няма смисъл от продължаване затова:
                            break;
                        }
                        tempCol++;
                    }
                }
            }
            return length;
        }

        // тук ще се случва търсенето за поредица надолу
        static int FindSequenceDown(string[,] matrix, int row, int col)
        {
            // зануляваме текущата дължина
            length = 1;
            // ако си на последният елемент,не прави нищо - върни дължината
            // така се  избягва излизане от границите на матрицата
            if (row != matrix.GetLength(0) - 1)
            {
                // проверяваме двата съседни елемента дали са равни,ако да увеличаваме дължината(имаме поредица) и пускаме цикъл да 
                // проверява така до края на редовете в матрицата, т.е. надолу;ако пък не са равни връщаме текущата дължина
                if (matrix[row, col] == matrix[row + 1, col])
                {
                    length++;
                    int tempRow = row;
                    tempRow++;
                    while (tempRow < matrix.GetLength(0) - 1)
                    {
                        if (matrix[tempRow, col] == matrix[tempRow + 1, col])
                        {
                            length++;
                        }
                        else
                        {
                            // ако поредният елемент не е равен няма смисъл от продължаване затова:
                            break;
                        }
                        tempRow++;
                    }
                }
            }
            return length;
        }

        // тук ще се случва търсенето за поредица по диагонал
        static int FindSequenceDiagonal(string[,] matrix, int row, int col)
        {
            // зануляваме текущата дължина
            length = 1;
            // ако си на последният елемент,не прави нищо - върни дължината
            // така се  избягва излизане от границите на матрицата
            if (row != matrix.GetLength(0) - 1 && col != matrix.GetLength(1) - 1)
            {
                // проверяваме двата съседни елемента дали са равни,ако да увеличаваме дължината(имаме поредица) и пускаме цикъл да 
                // проверява така до края на клетките по диагонал в матрицата;ако пък не са равни връщаме текущата дължина
                if (matrix[row, col] == matrix[row + 1, col + 1])
                {
                    length++;
                    int tempRow = row;
                    int tempCol = col;
                    tempRow++;
                    tempCol++;
                    while (tempRow < matrix.GetLength(0) - 1 && tempCol < matrix.GetLength(1) - 1)
                    {
                        if (matrix[tempRow, tempCol] == matrix[tempRow + 1, tempCol + 1])
                        {
                            length++;
                        }
                        else
                        {
                            // ако елемента по диагонал не е равен няма смисъл от продължаване затова:
                            break;
                        }
                        tempRow++;
                        tempCol++;
                    }
                }
            }
            return length;
        }

        // тук ще се проверява ако има намерени поредици, коя е най-голяма
        static int BestLength(string[,] matrix)
        {
            int bestLength = 1;

            // двата вложени цикъла ще взимат поредно елементите на матрицата
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    // за всеки елемент ще се извиква метод за намиране на поредица надясно, надолу и по диагонал като след приключване 
                    // на съответният метод ще се проверява ако има намерена такава дали тя е най-голямата и ако "да" ще се запишат 
                    // редът и колоната където започва
                    FindSequenceRight(matrix, row, col);
                    if (length > bestLength)
                    {
                        bestLength = length;
                        bestRow = row;
                        bestCol = col;
                    }
                    FindSequenceDown(matrix, row, col);
                    if (length > bestLength)
                    {
                        bestLength = length;
                        bestRow = row;
                        bestCol = col;
                    }
                    FindSequenceDiagonal(matrix, row, col);
                    if (length > bestLength)
                    {
                        bestLength = length;
                        bestRow = row;
                        bestCol = col;
                    }
                }
            }
            // накрая метода ще върне намерената най-голяма дължина
            return bestLength;
        }

        // тук ще се извършва финалното подреждане на най-дългата поредица и ще се подава в Main() за отпечатване на потребителя
        static string LongestSequenceInMatrix(string[,] matrix, int bestLength)
        {
            // тук ще сглобим крайният резултат 
            string result = "";

            // просто ще долепим елемента който е начален за най-голямата поредица,толкова на брой пъти,колкото е дължината й
            for (int i = 0; i < bestLength; i++)
            {
                if (i == bestLength - 1)// така се избягва разделителя ", " след последният елемент
                {
                    result += matrix[bestRow, bestCol];
                }
                else
                {
                    result += matrix[bestRow, bestCol] + ", ";
                }
            }
            return result;
        }

        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            // предварително сетнати матрици за по-лесно тестване 

            string[,] matrix =
            {
                {"ha","fifi","ho","hi"},
                {"fo","ha","hi","xx"},
                {"xxx","ho","ha","xx"}
            };

            //string[,] matrix =
            //{
            //    {"s","qq","s"},
            //    {"pp","pp","s"},
            //    {"pp","qq","s"}
            //};

            //string[,] matrix =
            //{
            //    {"ha","fifi","xix","xix","xix"},
            //    {"fo","ha","hi","xx","xix"},
            //    {"xxx","ho","hu","xx","xyx"}
            //};

            // подаваме резултата да се отпечата на потребителя
            Console.WriteLine(LongestSequenceInMatrix(matrix, BestLength(matrix)));
        }
    }
}
