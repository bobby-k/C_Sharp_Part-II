using System;
using System.Globalization;
using System.Threading;

namespace Problem3.EnglishDigit
{
    class EnglishDigit
    {
        // Write a method that returns the last digit of given integer as an English word.

        static string GetLastDigitAsWord(int number)
        {
            string digitAsWord = "";

            int lastDigit = number % 10;
            switch (lastDigit)
            {
                case 1: digitAsWord = "one";
                    break;
                case 2: digitAsWord = "two";
                    break;
                case 3: digitAsWord = "three";
                    break;
                case 4: digitAsWord = "four";
                    break;
                case 5: digitAsWord = "five";
                    break;
                case 6: digitAsWord = "six";
                    break;
                case 7: digitAsWord = "seven";
                    break;
                case 8: digitAsWord = "eight";
                    break;
                case 9: digitAsWord = "nine";
                    break;
                default: digitAsWord = "zero";
                    break;
            }

            return digitAsWord;
        }
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            Console.Write("Give me some number: ");
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine(GetLastDigitAsWord(number));
        }
    }
}
