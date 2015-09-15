using System;
using System.Globalization;
using System.Linq;
using System.Threading;

internal class OneSystemToAnyOther
{
    // Write a program to convert from any numeral system of given base s to any other numeral system of base d (2 ≤ s, d ≤ 16).
    private static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        Console.Write("Please specify the base s: ");
        int baseS = int.Parse(Console.ReadLine());

        Console.Write("Please specify the base d: ");
        int baseD = int.Parse(Console.ReadLine());

        #region Validations

        if (baseS < 2 || baseS > 16)
        {
            while (baseS < 2 || baseS > 16)
            {
                Console.Write("base s cannot be less than 2 a greater than 16\nPlease enter base s so s >= 2 and s <= 16: ");
                baseS = int.Parse(Console.ReadLine());
            }
        }
        if (baseD > 16 || baseD < 2)
        {
            while (baseD > 16 || baseD < 2)
            {
                Console.Write("base d cannot be greater than 16 or less than 2\nPlease enter base d so d <= 16 and d >=2: ");
                baseD = int.Parse(Console.ReadLine());
            }
        }
        if (baseD == baseS)
        {
            while (baseD == baseS || baseD > 16)
            {
                Console.Write("base d must be less than or greater than base s\nPlease enter base d so d != s and d <= 16: ");
                baseD = int.Parse(Console.ReadLine());
            }
        }

        #endregion Validations

        Console.Write("Please enter the base {0} number to convert from: ", baseS);
        string number = Console.ReadLine().ToUpper();

        number = Validate(number, baseS);

        int decimalNum = ConvertToDecimal(number, baseS);
        string convertedValue = ConvertFromDecimal(decimalNum, baseD);

        Console.Clear();
        Console.WriteLine("{0} in base({1}) system is\n{2} in base({3}) system", number, baseS, convertedValue, baseD);
    }

    private static string Validate(string number, int baseS)
    {
        bool charIsValid = false;
        char[] masterChars = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
        char[] allowedChars = new char[baseS];
        for (int i = 0; i < allowedChars.Length; i++)
        {
            allowedChars[i] = masterChars[i];
        }

        while (!charIsValid)
        {
            foreach (char symbol in number)
            {
                if (allowedChars.Contains(symbol))
                {
                    charIsValid = true;
                }
                else
                {
                    charIsValid = false;
                    Console.Write("The number you have entered has some invalid digits\nTry again: ");
                    number = Console.ReadLine().ToUpper();
                    break;
                }
            }
        }

        return number;
    }

    private static int ConvertToDecimal(string number, int baseS)
    {
        double decimalNum = 0;
        int lastIndex = number.Length - 1;
        for (int i = 0; i < number.Length; i++)
        {
            switch (number[lastIndex])
            {
                case 'A': decimalNum += 10 * (Math.Pow(baseS, i));
                    break;

                case 'B': decimalNum += 11 * (Math.Pow(baseS, i));
                    break;

                case 'C': decimalNum += 12 * (Math.Pow(baseS, i));
                    break;

                case 'D': decimalNum += 13 * (Math.Pow(baseS, i));
                    break;

                case 'E': decimalNum += 14 * (Math.Pow(baseS, i));
                    break;

                case 'F': decimalNum += 15 * (Math.Pow(baseS, i));
                    break;

                default: decimalNum += (number[lastIndex] - '0') * (Math.Pow(baseS, i));
                    break;
            }
            lastIndex--;
        }

        return Convert.ToInt32(decimalNum);
    }

    private static string ConvertFromDecimal(int decimalNum, int baseD)
    {
        string convertedValue = "";
        string tempValue = "";

        while (decimalNum != 0)
        {
            int remain = decimalNum % baseD;
            switch (remain)
            {
                case 10: tempValue += 'A';
                    break;

                case 11: tempValue += 'B';
                    break;

                case 12: tempValue += 'C';
                    break;

                case 13: tempValue += 'D';
                    break;

                case 14: tempValue += 'E';
                    break;

                case 15: tempValue += 'F';
                    break;

                default: tempValue += remain;
                    break;
            }
            decimalNum /= baseD;
        }

        // reversing
        for (int i = tempValue.Length - 1; i >= 0; i--)
        {
            convertedValue += tempValue[i];
        }

        return convertedValue;
    }
}