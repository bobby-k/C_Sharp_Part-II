using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

class CryptoCS
{
    static void Main()
    {
        string base26Num = Console.ReadLine();
        string operation = Console.ReadLine();
        string base7Num = Console.ReadLine();

        BigInteger base26ToBase10 = ConvertToBase10(base26Num, 26);
        BigInteger base7ToBase10 = ConvertToBase10(base7Num, 7);

        BigInteger resultInBase10 = ProceedOperation(operation, base26ToBase10, base7ToBase10);
        string base9Num = ConvertToBase9(resultInBase10);

        // remove leading zeros
        while (base9Num[0] == '0')
        {
            base9Num.Remove(0, 1);
        }

        Console.WriteLine(base9Num);
    }

    private static string ConvertToBase9(BigInteger base10Num, int baseD = 9)
    {
        StringBuilder convertedValue = new StringBuilder();
        StringBuilder tempValue = new StringBuilder();

        while (base10Num != 0)
        {
            BigInteger remain = base10Num % baseD;

            tempValue.Append(remain);

            base10Num /= baseD;
        }

        // reversing
        for (int i = tempValue.Length - 1; i >= 0; i--)
        {
            convertedValue.Append(tempValue[i]);
        }

        return convertedValue.ToString();
    }

    private static BigInteger ProceedOperation(string operation, BigInteger base26ToBase10, BigInteger base7ToBase10)
    {
        BigInteger result = 0;
        if (operation == "+")
        {
            result = base26ToBase10 + base7ToBase10;
        }
        else
        {
            result = base26ToBase10 - base7ToBase10;
        }

        return result;
    }

    private static BigInteger ConvertToBase10(string number, int baseN)
    {
        BigInteger decimalNum = 0;
        int lastIndex = number.Length - 1;
        for (int i = 0; i < number.Length; i++)
        {
            switch (number[lastIndex])
            {
                case 'a': decimalNum += (BigInteger)(0);
                    break;

                case 'b': decimalNum += (BigInteger)(Math.Pow(baseN, i));
                    break;

                case 'c': decimalNum += (BigInteger)(2 * (Math.Pow(baseN, i)));
                    break;

                case 'd': decimalNum += (BigInteger)(3 * (Math.Pow(baseN, i)));
                    break;

                case 'e': decimalNum += (BigInteger)(4 * (Math.Pow(baseN, i)));
                    break;

                case 'f': decimalNum += (BigInteger)(5 * (Math.Pow(baseN, i)));
                    break;

                case 'g': decimalNum += (BigInteger)(6 * (Math.Pow(baseN, i)));
                    break;

                case 'h': decimalNum += (BigInteger)(7 * (Math.Pow(baseN, i)));
                    break;

                case 'i': decimalNum += (BigInteger)(8 * (Math.Pow(baseN, i)));
                    break;

                case 'j': decimalNum += (BigInteger)(9 * (Math.Pow(baseN, i)));
                    break;

                case 'k': decimalNum += (BigInteger)(10 * (Math.Pow(baseN, i)));
                    break;

                case 'l': decimalNum += (BigInteger)(11 * (Math.Pow(baseN, i)));
                    break;

                case 'm': decimalNum += (BigInteger)(12 * (Math.Pow(baseN, i)));
                    break;

                case 'n': decimalNum += (BigInteger)(13 * (Math.Pow(baseN, i)));
                    break;

                case 'o': decimalNum += (BigInteger)(14 * (Math.Pow(baseN, i)));
                    break;

                case 'p': decimalNum += (BigInteger)(15 * (Math.Pow(baseN, i)));
                    break;

                case 'q': decimalNum += (BigInteger)(16 * (Math.Pow(baseN, i)));
                    break;

                case 'r': decimalNum += (BigInteger)(17 * (Math.Pow(baseN, i)));
                    break;

                case 's': decimalNum += (BigInteger)(18 * (Math.Pow(baseN, i)));
                    break;

                case 't': decimalNum += (BigInteger)(19 * (Math.Pow(baseN, i)));
                    break;

                case 'u': decimalNum += (BigInteger)(20 * (Math.Pow(baseN, i)));
                    break;

                case 'v': decimalNum += (BigInteger)(21 * (Math.Pow(baseN, i)));
                    break;

                case 'w': decimalNum += (BigInteger)(22 * (Math.Pow(baseN, i)));
                    break;

                case 'x': decimalNum += (BigInteger)(23 * (Math.Pow(baseN, i)));
                    break;

                case 'y': decimalNum += (BigInteger)(24 * (Math.Pow(baseN, i)));
                    break;

                case 'z': decimalNum += (BigInteger)(25 * (Math.Pow(baseN, i)));
                    break;

                default: decimalNum += (BigInteger)((number[lastIndex] - '0') * (Math.Pow(baseN, i)));
                    break;
            }

            lastIndex--;
        }

        return decimalNum;
    }
}
