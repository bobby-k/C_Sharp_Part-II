using System;
using System.Linq;

internal class Kitty
{
    private const char CODER_SOUL = '@';
    private const char FOOD = '*';
    private const char DEADLOCK = 'x';
    private static int soulsCollected = 0;
    private static int foodCollected = 0;
    private static int deadlocks = 0;
    private static bool[] inputCheck;
    private static char[] input;
    private static int jumps = 0;

    private static void Main()
    {
        input = Console.ReadLine().ToCharArray();
        int[] kittyMoves = Console.ReadLine().Split(' ').Select(i => int.Parse(i)).ToArray();
        inputCheck = new bool[input.Length];

        int currentPosition = 0;
        bool deathMsgPrinted;
        ProccessPosition(currentPosition, out deathMsgPrinted);
        if (deathMsgPrinted)
        {
            return;
        }

        int index = 0;
        while (index < kittyMoves.Length)
        {
            if (kittyMoves[index] > 0)
            {
                // move right
                currentPosition = MoveRight(currentPosition, kittyMoves[index]);
                ProccessPosition(currentPosition, out deathMsgPrinted);
                if (deathMsgPrinted)
                {
                    return;
                }
            }
            else
            {
                // move left
                currentPosition = MoveLeft(currentPosition, kittyMoves[index]);
                ProccessPosition(currentPosition, out deathMsgPrinted);
                if (deathMsgPrinted)
                {
                    return;
                }
            }

            index++;
        }

        PrintFinalResult();
    }

    private static int MoveLeft(int currentPosition, int positions)
    {
        positions *= -1;
        for (int i = 0; i < positions; i++)
        {
            currentPosition--;

            if (currentPosition < 0)
            {
                currentPosition = input.Length - 1;
                continue;
            }
        }

        return currentPosition;
    }

    private static int MoveRight(int currentPosition, int positions)
    {
        for (int i = 0; i < positions; i++)
        {
            currentPosition++;

            if (currentPosition > input.Length - 1)
            {
                currentPosition = 0;
                continue;
            }
        }

        return currentPosition;
    }

    // optimized method for moving left and right
    private static int Move(int currentPosition, int positions)
    {
        currentPosition = (currentPosition + positions) % input.Length;

        if (currentPosition < 0)
        {
            currentPosition += input.Length;
        }

        return currentPosition;
    }

    private static void ProccessPosition(int position, out bool deathMsgPrinted)
    {
        deathMsgPrinted = false;
        if (input[position] == CODER_SOUL && inputCheck[position] == false)
        {
            // soul
            soulsCollected++;
            inputCheck[position] = true;
            jumps++;
        }
        else if (input[position] == FOOD && inputCheck[position] == false)
        {
            // food
            foodCollected++;
            inputCheck[position] = true;
            jumps++;
        }
        else if (input[position] == DEADLOCK)
        {
            // deadlock
            deadlocks++;
            if (position % 2 == 0)
            {
                if (soulsCollected > 0)
                {
                    soulsCollected--;
                    jumps++;
                    inputCheck[position] = false;
                    input[position] = CODER_SOUL;
                }
                else
                {
                    PrintDeathMessage();
                    deathMsgPrinted = true;
                }
            }
            else
            {
                // odd position
                if (foodCollected > 0)
                {
                    foodCollected--;
                    jumps++;
                    inputCheck[position] = false;
                    input[position] = FOOD;
                }
                else
                {
                    PrintDeathMessage();
                    deathMsgPrinted = true;
                }
            }
        }
    }

    private static void PrintDeathMessage()
    {
        Console.WriteLine("You are deadlocked, you greedy kitty!");
        Console.WriteLine("Jumps before deadlock: {0}", jumps);
    }

    private static void PrintFinalResult()
    {
        Console.WriteLine("Coder souls collected: {0}", soulsCollected);
        Console.WriteLine("Food collected: {0}", foodCollected);
        Console.WriteLine("Deadlocks: {0}", deadlocks);
    }
}