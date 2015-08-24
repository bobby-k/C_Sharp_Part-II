using System;
using System.Globalization;
using System.Threading;

namespace Problem15.PrimeNumbers
{
    class PrimeNumbers
    {
        // Write a program that finds all prime numbers in the range [1...10 000 000]. Use the Sieve of Eratosthenes algorithm.
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            // user-friendly interface
            Console.WriteLine("Please enter a number up to which you want to see all prime numbers: ");
            Console.WriteLine("!!! The number you will enter is not included !!!");
            Console.WriteLine(new string('*', 25));

            int n = int.Parse(Console.ReadLine());
            bool[] sieve = new bool[n];

            Console.WriteLine(new string('*', 25));

            // запълваме с true всички клетки, за да можем да задаваме false на всяка задраскана клетка
            // започваме от две тъй като е първото просто число
            for (int i = 2; i < sieve.Length; i++)
            {
                sieve[i] = true;
            }

            // започваме от "х" (т.е. 2, тъй като е първото просто число)и задраскваме всяко "х"-то число до края, 
            // ако е задраскано, преминаваме към следващото 
            int j = 0;
            for (int i = 2; i < sieve.Length; i++) // optimization available --> i < Math.Sqrt((double)sieve.Length);
            {
                // ако "х"-тото число не е задраскано го задраскваме и отиваме на следващото "х"-то число и така до края
                if (sieve[i] == true)
                {
                    // "j" е следващото "х"-то число
                    j = i + i; // optimization available --> j = i * i; така ще се избегне минаването през вече задрасканите числа
                    while (j < n)
                    {
                        sieve[j] = false;
                        j += i; // следващото "х"-то число
                    }
                }
            }

            // накрая минаваме по целият масив и даваме само ст-тите които не са задраскани, т.е. true
            for (int i = 2; i < sieve.Length; i++)
            {
                if (sieve[i] == true)
                {
                    Console.WriteLine(i);
                }
            }

        }
    }
}
