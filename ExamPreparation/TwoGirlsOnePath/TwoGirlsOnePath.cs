namespace TwoGirlsOnePath
{
    using System;
    using System.Linq;
    using System.Numerics;

    internal class TwoGirlsOnePath
    {
        private static void Main()
        {
            BigInteger mollyScore = 0;
            BigInteger dollyScore = 0;

            BigInteger[] path = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(BigInteger.Parse).ToArray();
            int mollyPosition = 0;
            int dollyPosition = path.Length - 1;
            string winner = string.Empty;

            while (true)
            {
                // when is the game over?
                if (path[mollyPosition] == 0 || path[dollyPosition] == 0)
                {
                    if (path[mollyPosition] == 0 && path[dollyPosition] == 0)
                    {
                        winner = "Draw";
                    }
                    else if (path[mollyPosition] == 0)
                    {
                        winner = "Dolly";
                    }
                    else if (path[dollyPosition] == 0)
                    {
                        winner = "Molly";
                    }

                    mollyScore += path[mollyPosition];
                    dollyScore += path[dollyPosition];
                    break;
                }

                // get flowers in the current cell
                BigInteger currentMollyFlowers = path[mollyPosition];
                BigInteger currentDollyFlowers = path[dollyPosition];

                // apply rule if in the same cell
                if (mollyPosition == dollyPosition)
                {
                    path[mollyPosition] = currentMollyFlowers % 2;
                    mollyScore += currentMollyFlowers / 2;
                    dollyScore += currentDollyFlowers / 2;
                }
                // otherwise
                else
                {
                    mollyScore += currentMollyFlowers;
                    dollyScore += currentDollyFlowers;

                    path[mollyPosition] = 0;
                    path[dollyPosition] = 0;
                }

                // move
                mollyPosition = (int)((mollyPosition + currentMollyFlowers) % path.Length);

                dollyPosition = (int)((dollyPosition - currentDollyFlowers) % path.Length);
                if (dollyPosition < 0)
                {
                    dollyPosition += path.Length;
                }
            }

            // print the final results
            Console.WriteLine(winner);
            Console.WriteLine("{0} {1}", mollyScore, dollyScore);
        }
    }
}