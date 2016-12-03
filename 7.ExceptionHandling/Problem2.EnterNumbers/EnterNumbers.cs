using System;

internal class EnterNumbers
{
    // Write a method ReadNumber(int start, int end) that enters an integer number in a given range [start...end]. If an
    // invalid number or non-number text is entered, the method should throw an exception. Using this method write a program
    // that enters 10 numbers: a1, a2, ... a10, such that 1 < a1 < ... < a10 < 100 and not 1 <= a1 ... <= a10 <= 100

    private const int Start = 1;
    private const int End = 100;
    private static int[] tenNumbers = new int[10];

    private static void Main()
    {
        try
        {
            Console.WriteLine("Please enter ten numbers between 1 and 100");
            EnterTenNumbers();
            Print();
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("Start again!");
        }
        catch (FormatException ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("Start again!");
        }
    }

    private static int[] EnterTenNumbers()
    {
        for (int i = 0; i < 10; i++)
        {
            //Console.Write("number {0} = ", i + 1);
            tenNumbers[i] = ReadNumber(Start, End);
        }

        for (int i = 1; i < tenNumbers.Length; i++)
        {
            if (tenNumbers[i - 1] >= tenNumbers[i])
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        return tenNumbers;
    }

    private static int ReadNumber(int start, int end)
    {
        int userNumber = int.Parse(Console.ReadLine());
        if (userNumber < start || userNumber > end)
        {
            throw new ArgumentOutOfRangeException();
        }

        return userNumber;
    }

    private static void Print()
    {
        Console.WriteLine("1 < " + string.Join(" < ", tenNumbers) + " < 100");
    }
}