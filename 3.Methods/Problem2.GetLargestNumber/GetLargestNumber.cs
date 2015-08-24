using System;
using System.Globalization;
using System.Threading;

namespace Problem2.GetLargestNumber
{
    class GetLargestNumber
    {
        // Write a method GetMax() with two parameters that returns the larger of two integers.
        // Write a program that reads 3 integers from the console and prints the largest of them using the method GetMax().
        static int GetMax(int number, int anotherNumber)
        {
            int max = number;

            if (anotherNumber > max)
            {
                max = anotherNumber;
            }

            return max;
        }
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            Console.WriteLine("Please enter 3 integer numbers: ");

            // collect userInput data into an array
            int[] userInput = new int[3];

            for (int i = 0; i < userInput.Length; i++)
            {
                userInput[i] = int.Parse(Console.ReadLine());
            }

            // clears the screen of console before printing the result
            Console.Clear();

            Console.WriteLine("The largest number is: {0}", GetMax(GetMax(userInput[0], userInput[1]), userInput[2]));
        }
    }
}
