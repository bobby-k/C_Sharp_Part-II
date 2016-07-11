using System;
using System.Linq;
using System.Numerics;

internal class Porcupines
{
    private const string RABBIT = "R";
    private const string PORCUPINE = "P";
    private const string TOP = "T";
    private const string BOTTOM = "B";
    private const string LEFT = "L";
    private const string RIGHT = "R";
    private static int baseColumnCount;
    private static int rowsCount;
    private static int rabbitX;
    private static int rabbitY;
    private static int porcupineX;
    private static int porcupineY;
    private static BigInteger[][] field;
    private static bool[,] checkField;
    private static BigInteger rabbitPts = 0;
    private static BigInteger porcupinePts = 0;

    private static void Main()
    {
        Input();
        CollectPts(RABBIT);
        CollectPts(PORCUPINE);

        while (true)
        {
            string line = Console.ReadLine();

            if (line == "END")
            {
                break;
            }

            string[] uds = line.Split(' ');
            string unit = uds[0];
            string direction = uds[1];
            int steps = int.Parse(uds[2]);

            ProceedCommand(unit, direction, steps);
        }

        if (rabbitPts > porcupinePts)
        {
            Console.WriteLine("The rabbit WON with {0} points. The porcupine scored {1} points only.", rabbitPts, porcupinePts);
        }
        else if (porcupinePts > rabbitPts)
        {
            Console.WriteLine("The porcupine destroyed the rabbit with {0} points. The rabbit must work harder. He scored {1} points only.", porcupinePts, rabbitPts);
        }
        else
        {
            Console.WriteLine("Both units scored {0} points. Maybe we should play again?", rabbitPts);
        }
    }

    private static void ProceedCommand(string unit, string direction, int steps)
    {
        if (unit == RABBIT)
        {
            // proceed rabbit
            MoveRabbit(direction, steps);
        }
        else
        {
            // proceed porcupine
            MovePorcupine(direction, steps);
        }
    }

    private static void MovePorcupine(string direction, int steps)
    {
        int firstRowOfColumn;
        int lastRowOfColumn;
        int firstColOfRow;
        int lastColOfRow;

        switch (direction)
        {
            case TOP:
                firstRowOfColumn = GetFirstRowOfTheColumn(porcupineY);
                lastRowOfColumn = GetLastRowOfTheColumn(porcupineY);
                for (int i = 0; i < steps; i++)
                {
                    porcupineX--;
                    if (porcupineX < firstRowOfColumn)
                    {
                        porcupineX = lastRowOfColumn;
                    }

                    if (porcupineX == rabbitX && porcupineY == rabbitY)
                    {
                        porcupineX++;
                        if (porcupineX > lastRowOfColumn)
                        {
                            porcupineX = firstRowOfColumn;
                        }

                        break;
                    }

                    CollectPts(PORCUPINE);
                }

                break;

            case BOTTOM:
                firstRowOfColumn = GetFirstRowOfTheColumn(porcupineY);
                lastRowOfColumn = GetLastRowOfTheColumn(porcupineY);
                for (int i = 0; i < steps; i++)
                {
                    porcupineX++;
                    if (porcupineX > lastRowOfColumn)
                    {
                        porcupineX = firstRowOfColumn;
                    }

                    if (porcupineX == rabbitX && porcupineY == rabbitY)
                    {
                        porcupineX--;
                        if (porcupineX < firstRowOfColumn)
                        {
                            porcupineX = lastRowOfColumn;
                        }

                        break;
                    }

                    CollectPts(PORCUPINE);
                }

                break;

            case LEFT:
                firstColOfRow = GetFirstColOfTheRow(porcupineX);
                lastColOfRow = GetLastColOfTheRow(porcupineX);
                for (int i = 0; i < steps; i++)
                {
                    porcupineY--;
                    if (porcupineY < firstColOfRow)
                    {
                        porcupineY = lastColOfRow;
                    }

                    if (porcupineX == rabbitX && porcupineY == rabbitY)
                    {
                        porcupineY++;
                        if (porcupineY > lastColOfRow)
                        {
                            porcupineY = firstColOfRow;
                        }

                        break;
                    }

                    CollectPts(PORCUPINE);
                }

                break;

            case RIGHT:
                firstColOfRow = GetFirstColOfTheRow(porcupineX);
                lastColOfRow = GetLastColOfTheRow(porcupineX);
                for (int i = 0; i < steps; i++)
                {
                    porcupineY++;
                    if (porcupineY > lastColOfRow)
                    {
                        porcupineY = firstColOfRow;
                    }

                    if (porcupineX == rabbitX && porcupineY == rabbitY)
                    {
                        porcupineY--;
                        if (porcupineY < firstColOfRow)
                        {
                            porcupineY = lastColOfRow;
                        }

                        break;
                    }

                    CollectPts(PORCUPINE);
                }

                break;
        }
    }

    private static void MoveRabbit(string direction, int steps)
    {
        int firstRowOfColumn;
        int lastRowOfColumn;
        int firstColOfRow;
        int lastColOfRow;

        switch (direction)
        {
            case TOP:
                firstRowOfColumn = GetFirstRowOfTheColumn(rabbitY);
                lastRowOfColumn = GetLastRowOfTheColumn(rabbitY);
                for (int i = 0; i < steps; i++)
                {
                    rabbitX--;
                    if (rabbitX < firstRowOfColumn)
                    {
                        rabbitX = lastRowOfColumn;
                    }
                }

                if (rabbitX == porcupineX && rabbitY == porcupineY)
                {
                    rabbitX++;
                    if (rabbitX > lastRowOfColumn)
                    {
                        rabbitX = firstRowOfColumn;
                    }

                    break;
                }

                CollectPts(RABBIT);
                break;

            case BOTTOM:
                firstRowOfColumn = GetFirstRowOfTheColumn(rabbitY);
                lastRowOfColumn = GetLastRowOfTheColumn(rabbitY);
                for (int i = 0; i < steps; i++)
                {
                    rabbitX++;
                    if (rabbitX > lastRowOfColumn)
                    {
                        rabbitX = firstRowOfColumn;
                    }
                }

                if (rabbitX == porcupineX && rabbitY == porcupineY)
                {
                    rabbitX--;
                    if (rabbitX < firstRowOfColumn)
                    {
                        rabbitX = lastRowOfColumn;
                    }

                    break;
                }

                CollectPts(RABBIT);
                break;

            case LEFT:
                firstColOfRow = GetFirstColOfTheRow(rabbitX);
                lastColOfRow = GetLastColOfTheRow(rabbitX);
                for (int i = 0; i < steps; i++)
                {
                    rabbitY--;
                    if (rabbitY < firstColOfRow)
                    {
                        rabbitY = lastColOfRow;
                    }
                }

                if (rabbitX == porcupineX && rabbitY == porcupineY)
                {
                    rabbitY++;
                    if (rabbitY > lastColOfRow)
                    {
                        rabbitY = firstColOfRow;
                    }

                    break;
                }

                CollectPts(RABBIT);
                break;

            case RIGHT:
                firstColOfRow = GetFirstColOfTheRow(rabbitX);
                lastColOfRow = GetLastColOfTheRow(rabbitX);
                for (int i = 0; i < steps; i++)
                {
                    rabbitY++;
                    if (rabbitY > lastColOfRow)
                    {
                        rabbitY = firstColOfRow;
                    }
                }

                if (rabbitX == porcupineX && rabbitY == porcupineY)
                {
                    rabbitY--;
                    if (rabbitY < firstColOfRow)
                    {
                        rabbitY = lastColOfRow;
                    }

                    break;
                }

                CollectPts(RABBIT);
                break;
        }
    }

    private static int GetLastColOfTheRow(int currentRow)
    {
        int lastCol = 0;
        for (int i = checkField.GetLength(1) - 1; i >= 0; i--)
        {
            if (checkField[currentRow, i] == true)
            {
                lastCol = i;
                break;
            }
        }

        return lastCol;
    }

    private static int GetFirstColOfTheRow(int currentRow)
    {
        int firstCol = 0;
        for (int i = 0; i < checkField.GetLength(1); i++)
        {
            if (checkField[currentRow, i] == true)
            {
                firstCol = i;
                break;
            }
        }

        return firstCol;
    }

    private static int GetFirstRowOfTheColumn(int currentCol)
    {
        int firstRowIndex = 0;
        for (int i = 0; i < checkField.GetLength(0); i++)
        {
            if (checkField[i, currentCol] == true)
            {
                firstRowIndex = i;
                break;
            }
        }

        return firstRowIndex;
    }

    private static int GetLastRowOfTheColumn(int currentCol)
    {
        int lastRowIndex = 0;
        for (int i = checkField.GetLength(0) - 1; i >= 0; i--)
        {
            if (checkField[i, currentCol] == true)
            {
                lastRowIndex = i;
                break;
            }
        }

        return lastRowIndex;
    }

    private static void CollectPts(string unit)
    {
        if (unit == RABBIT)
        {
            if (field[rabbitX][rabbitY] == 0)
            {
                return;
            }
            else
            {
                rabbitPts += field[rabbitX][rabbitY];
                field[rabbitX][rabbitY] = 0;
            }
        }
        else
        {
            if (field[porcupineX][porcupineY] == 0)
            {
                return;
            }
            else
            {
                porcupinePts += field[porcupineX][porcupineY];
                field[porcupineX][porcupineY] = 0;
            }
        }
    }

    private static void Input()
    {
        baseColumnCount = int.Parse(Console.ReadLine());
        rowsCount = int.Parse(Console.ReadLine());
        int[] porcupineXY = Console.ReadLine().Split(' ').Select(i => int.Parse(i)).ToArray();
        int[] rabbitXY = Console.ReadLine().Split(' ').Select(i => int.Parse(i)).ToArray();
        porcupineX = porcupineXY[0];
        porcupineY = porcupineXY[1];
        rabbitX = rabbitXY[0];
        rabbitY = rabbitXY[1];

        // initializing field and checkField
        field = new BigInteger[rowsCount][];
        int j = 1;
        BigInteger initialValue = 1;
        BigInteger value = initialValue;
        int maxColsCount = (rowsCount / 2) * baseColumnCount;
        checkField = new bool[rowsCount, maxColsCount];

        for (int i = 0; i < rowsCount / 2; i++, j++)
        {
            field[i] = new BigInteger[j * baseColumnCount];
            for (int k = 0; k < field[i].Length; k++)
            {
                field[i][k] = value;
                value += initialValue;
                checkField[i, k] = true;
            }

            initialValue++;
            value = initialValue;
        }

        j--;
        for (int i = rowsCount / 2; i < rowsCount; i++)
        {
            field[i] = new BigInteger[j * baseColumnCount];
            for (int k = 0; k < field[i].Length; k++)
            {
                field[i][k] = value;
                value += initialValue;
                checkField[i, k] = true;
            }

            initialValue++;
            value = initialValue;
            j--;
        }
    }
}