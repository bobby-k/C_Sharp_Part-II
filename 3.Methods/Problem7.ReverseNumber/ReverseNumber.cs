using System;
using System.Globalization;
using System.Threading;

namespace Problem7.ReverseNumber
{
    class ReverseNumber
    {
        // Write a method that reverses the digits of a given decimal number.

        static void ReverseDigitsEasy(decimal number)
        {
            string numberToString = Convert.ToString(number);
            string reversed = "";
            for (int i = numberToString.Length - 1; i >= 0; i--)
            {
                reversed += numberToString[i];
            }

            Console.WriteLine("The reversed number is {0}", reversed);
        }

        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            Console.Write("Please enter a decimal number to reverse it: ");
            ReverseDigitsEasy(decimal.Parse(Console.ReadLine()));
        }
    }
}
