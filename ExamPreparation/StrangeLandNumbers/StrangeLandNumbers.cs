using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace StrangeLandNumbers
{
    internal class StrangeLandNumbers
    {
        private static void Main()
        {
            string input = Console.ReadLine();

            string[] strangeNumSysTable =
            {
                "f",
                "bIN",
                "oBJEC",
                "mNTRAVL",
                "lPVKNQ",
                "pNWE",
                "hT"
            };

            StringBuilder currentStrangeNumber = new StringBuilder();
            List<int> strangeNumberAsInt = new List<int>();

            for (int i = input.Length - 1; i >= 0; i--)
            {
                currentStrangeNumber.Append(input[i]);

                string curNum = MyReverse(currentStrangeNumber.ToString());
                if (strangeNumSysTable.Contains(curNum))
                {
                    int number;
                    switch (curNum)
                    {
                        case "bIN":
                            number = 1;
                            break;

                        case "oBJEC":
                            number = 2;
                            break;

                        case "mNTRAVL":
                            number = 3;
                            break;

                        case "lPVKNQ":
                            number = 4;
                            break;

                        case "pNWE":
                            number = 5;
                            break;

                        case "hT":
                            number = 6;
                            break;

                        default:
                            number = 0;
                            break;
                    }
                    strangeNumberAsInt.Insert(0, number);
                    currentStrangeNumber.Clear();
                }
            }

            BigInteger decNum = ConvertToDecimal(strangeNumberAsInt);
            Console.WriteLine(decNum);
        }

        private static string MyReverse(string someString)
        {
            StringBuilder result = new StringBuilder();
            for (int i = someString.Length - 1; i >= 0; i--)
            {
                result.Append(someString[i]);
            }

            return result.ToString();
        }

        private static BigInteger ConvertToDecimal(List<int> strangeNumberAsInt)
        {
            int baseS = 7;
            string number = string.Join("", strangeNumberAsInt);

            BigInteger decimalNum = 0;
            int lastIndex = number.Length - 1;
            for (int i = 0; i < number.Length; i++)
            {
                switch (number[lastIndex])
                {
                    case 'A':
                        decimalNum += (BigInteger)(10 * (Math.Pow(baseS, i)));
                        break;

                    case 'B':
                        decimalNum += (BigInteger)(11 * (Math.Pow(baseS, i)));
                        break;

                    case 'C':
                        decimalNum += (BigInteger)(12 * (Math.Pow(baseS, i)));
                        break;

                    case 'D':
                        decimalNum += (BigInteger)(13 * (Math.Pow(baseS, i)));
                        break;

                    case 'E':
                        decimalNum += (BigInteger)(14 * (Math.Pow(baseS, i)));
                        break;

                    case 'F':
                        decimalNum += (BigInteger)(15 * (Math.Pow(baseS, i)));
                        break;

                    default:
                        decimalNum += (BigInteger)((number[lastIndex] - '0') * (Math.Pow(baseS, i)));
                        break;
                }

                lastIndex--;
            }

            return decimalNum;
        }
    }
}