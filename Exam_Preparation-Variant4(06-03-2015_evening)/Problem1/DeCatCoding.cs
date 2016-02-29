using System;
using System.Collections.Generic;
using System.Numerics;

internal class DeCatCoding
{
    private static string base21SysAsStr = "abcdefghijklmnopqrstu";

    private static void Main()
    {
        var output = new List<string>();
        string[] inputSplited = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        for (int wordIndex = 0; wordIndex < inputSplited.Length; wordIndex++)
        {
            var currentInputWord = new List<BigInteger>();

            for (int i = 0; i < inputSplited[wordIndex].Length; i++)
            {
                currentInputWord.Add(base21SysAsStr.IndexOf(inputSplited[wordIndex][i]));
            }

            BigInteger sum = 0;
            for (int i = currentInputWord.Count - 1, j = 0; i >= 0; i--, j++)
            {
                sum += currentInputWord[i] * (BigInteger)Math.Pow(21.0, j);
            }

            string convertedValue = string.Empty;
            string tempValue = string.Empty;

            while (sum != 0)
            {
                BigInteger baseSys = 26Ul;
                BigInteger remain = sum % baseSys;
                if (remain == 0)
                {
                    tempValue += 'a';
                }
                else if (remain == 1)
                {
                    tempValue += 'b';
                }
                else if (remain == 2)
                {
                    tempValue += 'c';
                }
                else if (remain == 3)
                {
                    tempValue += 'd';
                }
                else if (remain == 4)
                {
                    tempValue += 'e';
                }
                else if (remain == 5)
                {
                    tempValue += 'f';
                }
                else if (remain == 6)
                {
                    tempValue += 'g';
                }
                else if (remain == 7)
                {
                    tempValue += 'h';
                }
                else if (remain == 8)
                {
                    tempValue += 'i';
                }
                else if (remain == 9)
                {
                    tempValue += 'j';
                }
                else if (remain == 10)
                {
                    tempValue += 'k';
                }
                else if (remain == 11)
                {
                    tempValue += 'l';
                }
                else if (remain == 12)
                {
                    tempValue += 'm';
                }
                else if (remain == 13)
                {
                    tempValue += 'n';
                }
                else if (remain == 14)
                {
                    tempValue += 'o';
                }
                else if (remain == 15)
                {
                    tempValue += 'p';
                }
                else if (remain == 16)
                {
                    tempValue += 'q';
                }
                else if (remain == 17)
                {
                    tempValue += 'r';
                }
                else if (remain == 18)
                {
                    tempValue += 's';
                }
                else if (remain == 19)
                {
                    tempValue += 't';
                }
                else if (remain == 20)
                {
                    tempValue += 'u';
                }
                else if (remain == 21)
                {
                    tempValue += 'v';
                }
                else if (remain == 22)
                {
                    tempValue += 'w';
                }
                else if (remain == 23)
                {
                    tempValue += 'x';
                }
                else if (remain == 24)
                {
                    tempValue += 'y';
                }
                else if (remain == 25)
                {
                    tempValue += 'z';
                }
                else
                {
                    tempValue += remain;
                }

                sum /= baseSys;
            }

            // reversing
            for (int i = tempValue.Length - 1; i >= 0; i--)
            {
                convertedValue += tempValue[i];
            }

            output.Add(convertedValue);
        }

        Console.WriteLine("{0}", string.Join(" ", output));
    }
}