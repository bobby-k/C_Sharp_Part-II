using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Threading;

namespace Problem8.NumberAsArray
{
    class NumberAsArray
    {
        // Write a method that adds two positive integer numbers represented as arrays of digits 
        // (each array element arr[i] contains a digit, the last digit is kept in arr[0]).
        // Each of the numbers that will be added could have up to 10 000 digits.

        // Логика: Първо ще превръщаме подадените числа в масиви като на 0 позиция ще са единиците на всяко число после десетиците и т.н.
        // Събирането ще се извършва като се събират единици после десетици и т.н.,ако сбора на единиците или коя да е друга двойка е 
        // двуцифрено число се записват само единиците от този сбор, а остатъка се прехвърля към следващата двойка.Съответно ще имаме
        // два метода(за всяка подзадача по един) и ще използваме BigInteger за да се побират евентуални числа с 10000 цифри.Накрая ще
        // тестваме сбор на две числа с по 10000 цифри за да се убедим че програмата смята коректно

        // тук ще се превръщат числата в масиви, като 0 позиция ще съответства на единици, 1 позиция на десетици и т.н. както е условието
        static int[] ConvertNumberToArrayOfDigits(BigInteger number)
        {
            List<int> numberAsList = new List<int>();
            for (BigInteger i = number; i > 0; i /= 10)
            {
                numberAsList.Add((int)(number % 10));
                number /= 10;
            }

            numberAsList.TrimExcess();

            return numberAsList.ToArray();
        }

        // тук ще се случва действителното събиране
        static BigInteger SumOfTwoNumbers(BigInteger number, BigInteger anotherNumber)
        {
            // превръщаме подадените числа в масиви от цифри
            int[] arr1 = ConvertNumberToArrayOfDigits(number);
            int[] arr2 = ConvertNumberToArrayOfDigits(anotherNumber);

            // тук ще се записва резултата, който ще е нов масив с големина дължината на по-голямато от двете числа
            int[] result = new int[Math.Max(arr1.Length, arr2.Length)];

            // тук ще се записва остатъка при събирането, ако сбора е двуцифрен
            int over = 0;
            for (int i = 0; i < result.Length; i++)
            {
                int tempSum = (i < arr1.Length ? arr1[i] : 0) + (i < arr2.Length ? arr2[i] : 0) + over;
                result[i] = tempSum % 10;
                over = tempSum / 10;
            }

            var sum = BigInteger.Parse(string.Join("", result.Reverse()));
            return sum;
        }

        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            Console.WriteLine(SumOfTwoNumbers(12345678912345678900, 12345678900));

            // testing the method with numbers up to 10000 digits
            BigInteger a = 1;
            for (int i = 0; i < 9999; i++)
            {
                a *= 10;
            }
            a++;

            BigInteger b = 2;
            for (int i = 0; i < 9999; i++)
            {
                b *= 10;
            }
            b += 9;

            BigInteger c = SumOfTwoNumbers(a, b);
            Console.WriteLine(c);
        }
    }
}
