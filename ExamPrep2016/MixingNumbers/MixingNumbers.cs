using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixingNumbers
{
    class MixingNumbers
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            string[] numbersAsStr = new string[N];

            for (int i = 0; i < N; i++)
            {
                numbersAsStr[i] = Console.ReadLine();
            }

            int[] mixedNums = MixNumbers(numbersAsStr);
            int[] substractedNums = SubstractNumbers(numbersAsStr);

            Console.WriteLine(string.Join(" ", mixedNums));
            Console.WriteLine(string.Join(" ", substractedNums));
        }

        private static int[] SubstractNumbers(string[] numbersAsStr)
        {
            int[] result = new int[numbersAsStr.Length - 1];
            for (int i = 0; i < numbersAsStr.Length - 1; i++)
            {
                result[i] = Math.Abs(int.Parse(numbersAsStr[i]) - int.Parse(numbersAsStr[i + 1]));
            }

            return result;
        }

        private static int[] MixNumbers(string[] numbersAsStr)
        {
            int[] result = new int[numbersAsStr.Length - 1];
            int b = 1;
            int c = 0;
            for (int i = 0; i < numbersAsStr.Length - 1; i++)
            {
                result[i] = int.Parse(numbersAsStr[i][b].ToString()) * int.Parse(numbersAsStr[i + 1][c].ToString());
            }

            return result;
        }


    }
}
