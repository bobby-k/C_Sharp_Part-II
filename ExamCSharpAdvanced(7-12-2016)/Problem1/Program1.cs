using System;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Problem1
{
    internal class Program1
    {
        private static void Main()
        {
            string[] strangeNumbersTable =
            {
                "ocaml",
                "haskell",
                "scala",
                "f#",
                "lisp",
                "rust",
                "ml",
                "clojure",
                "erlang",
                "standardml",
                "racket",
                "elm",
                "mercury",
                "commonlisp",
                "scheme",
                "curry",
            };

            string[] numbers = Console.ReadLine().Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string[] numbersAsStr = new string[numbers.Length];
            StringBuilder razbivka = new StringBuilder();
            StringBuilder decRepr = new StringBuilder();
            for (int i = 0; i < numbers.Length; i++)
            {
                string currentStrangeNumber = numbers[i];
                for (int j = 0; j < currentStrangeNumber.Length; j++)
                {
                    razbivka.Append(currentStrangeNumber[j]);
                    if (strangeNumbersTable.Contains(razbivka.ToString()))
                    {
                        int foundAtIndex = Array.IndexOf(strangeNumbersTable, razbivka.ToString());
                        if (foundAtIndex < 10)
                        {
                            decRepr.Append(foundAtIndex);
                        }
                        else
                        {
                            switch (foundAtIndex)
                            {
                                case 10:
                                    decRepr.Append("A");
                                    break;
                                case 11:
                                    decRepr.Append("B");
                                    break;
                                case 12:
                                    decRepr.Append("C");
                                    break;
                                case 13:
                                    decRepr.Append("D");
                                    break;
                                case 14:
                                    decRepr.Append("E");
                                    break;
                                case 15:
                                    decRepr.Append("F");
                                    break;
                            }
                        }
                        razbivka.Clear();
                    }
                }

                numbersAsStr[i] = decRepr.ToString();
                decRepr.Clear();
            }

            BigInteger[] tempResult = ConvertToDecimal(numbersAsStr);
            BigInteger product = 1;
            for (int i = 0; i < tempResult.Length; i++)
            {
                product *= tempResult[i];
            }

            Console.WriteLine(product);
        }

        private static BigInteger[] ConvertToDecimal(string[] numbersAsStr)
        {
            BigInteger[] result = new BigInteger[numbersAsStr.Length];
            int baseS = 16;
            int index = 0;
            foreach (var number in numbersAsStr)
            {
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

                result[index] = decimalNum;
                index++;
            }

            return result;
        }
    }
}