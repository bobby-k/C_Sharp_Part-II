using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

internal class CalculationProblem
{
    private static string letterNums = "abcdefghijklmnopqrstuvw";

    private static void Main()
    {
        string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        BigInteger output = 0;

        for (int inputIndex = 0; inputIndex < input.Length; inputIndex++)
        {
            double sum = 0;
            var digitRepresentation = new List<int>();
            string currentWord = input[inputIndex];

            for (int i = 0; i < currentWord.Length; i++)
            {
                if (letterNums.Contains(currentWord[i]))
                {
                    int indexOfCurChar = letterNums.IndexOf(currentWord[i]);
                    digitRepresentation.Add(indexOfCurChar);
                }
            }

            for (int i = digitRepresentation.Count - 1, j = 0; i >= 0; i--, j++)
            {
                sum += digitRepresentation[i] * Math.Pow(23.0, j);
            }

            output += (int)sum;
        }

        string numInBase23 = ConvertToBase23(output);
        Console.WriteLine("{0} = {1}", numInBase23, output);
    }

    private static string ConvertToBase23(BigInteger output)
    {
        string convertedValue = string.Empty; ;
        string tempValue = string.Empty;

        while (output != 0)
        {
            BigInteger remain = output % 23;
            if (remain == 0)
            {
                tempValue += "a";
            }
            else if (remain == 1)
            {
                tempValue += "b";
            }
            else if (remain == 2)
            {
                tempValue += "c";
            }
            else if (remain == 3)
            {
                tempValue += "d";
            }
            else if (remain == 4)
            {
                tempValue += "e";
            }
            else if (remain == 5)
            {
                tempValue += "f";
            }
            else if (remain == 6)
            {
                tempValue += "g";
            }
            else if (remain == 7)
            {
                tempValue += "h";
            }
            else if (remain == 8)
            {
                tempValue += "i";
            }
            else if (remain == 9)
            {
                tempValue += "j";
            }
            else if (remain == 10)
            {
                tempValue += "k";
            }
            else if (remain == 11)
            {
                tempValue += "l";
            }
            else if (remain == 12)
            {
                tempValue += "m";
            }
            else if (remain == 13)
            {
                tempValue += "n";
            }
            else if (remain == 14)
            {
                tempValue += "o";
            }
            else if (remain == 15)
            {
                tempValue += "p";
            }
            else if (remain == 16)
            {
                tempValue += "q";
            }
            else if (remain == 17)
            {
                tempValue += "r";
            }
            else if (remain == 18)
            {
                tempValue += "s";
            }
            else if (remain == 19)
            {
                tempValue += "t";
            }
            else if (remain == 20)
            {
                tempValue += "u";
            }
            else if (remain == 21)
            {
                tempValue += "v";
            }
            else if (remain == 22)
            {
                tempValue += "w";
            }

            output /= 23;
        }

        // reversing
        for (int i = tempValue.Length - 1; i >= 0; i--)
        {
            convertedValue += tempValue[i];
        }

        return convertedValue;
    }
}