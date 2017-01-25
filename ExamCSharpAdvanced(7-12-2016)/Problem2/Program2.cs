using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem2
{
    internal class Program2
    {
        private static int[] board = new int[52];

        private static void Main()
        {
            int numOfHands = int.Parse(Console.ReadLine());
            string[] fulldeck =
            {
                "2c","3c","4c","5c","6c","7c","8c","9c","Tc","Jc","Qc","Kc","Ac",
                "2d","3d","4d","5d","6d","7d","8d","9d","Td","Jd","Qd","Kd","Ad",
                "2h","3h","4h","5h","6h","7h","8h","9h","Th","Jh","Qh","Kh","Ah",
                "2s","3s","4s","5s","6s","7s","8s","9s","Ts","Js","Qs","Ks","As"
            };

            for (int i = 0; i < numOfHands; i++)
            {
                ulong currentHand = ulong.Parse(Console.ReadLine());
                WriteFoundCards(currentHand);
            }

            // result
            if (Array.IndexOf(board, 0) < 0)
            {
                Console.WriteLine("Full deck");
            }
            else
            {
                Console.WriteLine("Wa wa!");
            }

            List<string> cards = new List<string>();

            for (int i = 0; i < board.Length; i++)
            {
                // on the second line, print all cards that occurred an even number of times, in ascending order, separated by
                // a whitespace " ". Look at the examples to get a better idea of how the output should look like
                if (board[i] % 2 == 0)
                {
                    cards.Add(fulldeck[i]);
                }
            }

            var result = cards.Where(c => c[1] == 'c').ToList();
            result.AddRange(cards.Where(c => c[1] == 'd').ToList());
            result.AddRange(cards.Where(c => c[1] == 'h').ToList());
            result.AddRange(cards.Where(c => c[1] == 's').ToList());

            Console.WriteLine(string.Join(" ", result));
        }

        private static void WriteFoundCards(ulong currentHand)
        {
            string binRepr = Convert.ToString((long)currentHand, 2);
            if (binRepr.Length < 52)
            {
                binRepr = binRepr.PadLeft(52, '0');
            }

            for (int i = 0, j = binRepr.Length - 1; i < binRepr.Length; i++, j--)
            {
                if (binRepr[i] == '1')
                {
                    board[j]++;
                }
            }
        }
    }
}