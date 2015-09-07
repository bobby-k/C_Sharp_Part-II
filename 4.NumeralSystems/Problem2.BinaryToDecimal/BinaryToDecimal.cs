using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Problem2.BinaryToDecimal
{
    class BinaryToDecimal
    {
        // Write a program to convert binary numbers to their decimal representation.
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            Console.Write("Please enter a number in binary representation: ");
            string userInput = Console.ReadLine();

            ConvertBinaryToDecimal(userInput);
        }

        private static void ConvertBinaryToDecimal(string userInput)
        {
            Validate(userInput);
            double decimalNum = 0;
            int lastIndex = userInput.Length - 1;
            for (int i = 0; i < userInput.Length; i++)
            {
                decimalNum += userInput[lastIndex] * (Math.Pow(2, i));
                lastIndex--;
            }

            Console.WriteLine("{0} in binary system is\n{1} in decimal system", userInput, decimalNum);
        }

        private static void Validate(string userInput)
        {
            bool validInput = false;
            while (!validInput)
            {
                foreach (char symbol in userInput)
                {
                    if (symbol != '0' && symbol != '1')
                    {
                        Console.Write("Wrong format!!!\nBinary representations can only have \"0\"s or \"1\"s\nTry again: ");
                        userInput = Console.ReadLine();
                        break;
                    }
                    else
                    {
                        validInput = true;
                    }
                }
            }
        }
    }
}
