using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

internal class BunnyFactory
{
    private static List<int> initialCages;

    private static void Main()
    {
        initialCages = InitializeCages();

        int numOfCycle = 1; // i == numOfCycle
        while (true)
        {
            #region Step 1:If there are less than i cages, the factory stops the multiplication process

            if (initialCages.Count < numOfCycle)
            {
                break;
            }

            #endregion Step 1:If there are less than i cages, the factory stops the multiplication process

            #region Step 2:The factory gets the first i cages and calculate the sum s of all bunnies in them.

            int sumS = Step2(numOfCycle);

            #endregion Step 2:The factory gets the first i cages and calculate the sum s of all bunnies in them.

            #region Step 3:If there are less than s cages after the i-th one, the factory stops the multiplication process

            if (sumS > initialCages.Count - numOfCycle)
            {
                break;
            }

            #endregion Step 3:If there are less than s cages after the i-th one, the factory stops the multiplication process

            #region Step 4:The factory gets the next s cages after the i-th one and calculates the sum and product of all bunnies in them.

            BigInteger product;
            int sum = Step4(sumS, numOfCycle, out product);

            #endregion Step 4:The factory gets the next s cages after the i-th one and calculates the sum and product of all bunnies in them.

            #region removes the cages that are used

            for (int l = 0; l < numOfCycle + sumS; l++)
            {
                initialCages.RemoveAt(0);
            }

            #endregion removes the cages that are used

            #region Step 5:These sum and product are concatenated as next cages. All cages that were not included in the calculations are simply appended to next.

            StringBuilder next = new StringBuilder();
            next.Append(sum.ToString());
            next.Append(product.ToString());
            next.Append(string.Join("", initialCages));

            #endregion Step 5:These sum and product are concatenated as next cages. All cages that were not included in the calculations are simply appended to next.

            #region Step 6:The factory gets several empty cages then gets the digits of next and for each digit puts the same amount of bunnies in each cell. If the digit is 1 or 0, the digit is ignored.

            Step6(next);

            #endregion Step 6:The factory gets several empty cages then gets the digits of next and for each digit puts the same amount of bunnies in each cell. If the digit is 1 or 0, the digit is ignored.

            numOfCycle++;
        }

        Console.WriteLine(string.Join(" ", initialCages));
    }

    private static List<int> InitializeCages()
    {
        var initialCages = new List<int>();
        while (true)
        {
            string line = Console.ReadLine();
            if (line == "END")
            {
                break;
            }
            else
            {
                initialCages.Add(int.Parse(line));
            }
        }

        return initialCages;
    }

    private static int Step2(int cycleNumber)
    {
        int sum = 0;
        for (int i = 0; i < cycleNumber; i++)
        {
            sum += initialCages[i];
        }

        return sum;
    }

    private static int Step4(int sumS, int numOfCycle, out BigInteger product)
    {
        int sum = 0;
        product = 1;
        for (int i = 0, index = numOfCycle; i < sumS; i++, index++)
        {
            sum += initialCages[index];
            product *= initialCages[index];
        }

        return sum;
    }

    private static void Step6(StringBuilder nextCages)
    {
        // removes 1s and 0s
        for (int i = 0; i < nextCages.Length; i++)
        {
            if (nextCages[i] == '1' || nextCages[i] == '0')
            {
                nextCages.Remove(i, 1);
                i--;
            }
        }

        // adds the new cages to the place of the old ones
        initialCages.Clear();
        for (int i = 0; i < nextCages.Length; i++)
        {
            initialCages.Add(int.Parse(nextCages[i].ToString()));
        }
    }
}