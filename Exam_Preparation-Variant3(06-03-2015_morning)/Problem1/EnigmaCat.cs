using System;
using System.Collections.Generic;
using System.Numerics;

internal class EnigmaCat
{
    private static string numSys17Digits = "abcdefghijklmnopq";

    private static void Main()
    {
        // var reader = new StreamReader(@"D:\C#2\Variant 3 (2015-03-06, Morning)\Problem 1\Tests\test.010.in.txt");
        string[] inputWords = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var wordsInBase26 = new List<string>();

        foreach (var word in inputWords)
        {
            BigInteger numInDecimal = 0;
            for (int i = word.Length - 1, j = 0; i >= 0; i--, j++)
            {
                numInDecimal += numSys17Digits.IndexOf(word[i]) * PowerOf17(j);
            }

            string wordInBase26 = ConvertToBase26(numInDecimal);
            wordsInBase26.Add(wordInBase26);
        }
        
        Console.WriteLine(string.Join(" ", wordsInBase26));
    }

    private static BigInteger PowerOf17(int j)
    {
        BigInteger result = 1;
        for (int i = 0; i < j; i++)
        {
            result *= 17;
        }

        return result;
    }

    private static string ConvertToBase26(BigInteger numInDecimal)
    {
        string convertedValue = string.Empty;
        string tempValue = string.Empty;

        while (numInDecimal != 0)
        {
            BigInteger remain = numInDecimal % 26;
            switch (remain.ToString())
            {
                case "0": tempValue += 'a';
                    break;

                case "1": tempValue += 'b';
                    break;

                case "2": tempValue += 'c';
                    break;

                case "3": tempValue += 'd';
                    break;

                case "4": tempValue += 'e';
                    break;

                case "5": tempValue += 'f';
                    break;

                case "6": tempValue += 'g';
                    break;

                case "7": tempValue += 'h';
                    break;

                case "8": tempValue += 'i';
                    break;

                case "9": tempValue += 'j';
                    break;

                case "10": tempValue += 'k';
                    break;

                case "11": tempValue += 'l';
                    break;

                case "12": tempValue += 'm';
                    break;

                case "13": tempValue += 'n';
                    break;

                case "14": tempValue += 'o';
                    break;

                case "15": tempValue += 'p';
                    break;

                case "16": tempValue += 'q';
                    break;

                case "17": tempValue += 'r';
                    break;

                case "18": tempValue += 's';
                    break;

                case "19": tempValue += 't';
                    break;

                case "20": tempValue += 'u';
                    break;

                case "21": tempValue += 'v';
                    break;

                case "22": tempValue += 'w';
                    break;

                case "23": tempValue += 'x';
                    break;

                case "24": tempValue += 'y';
                    break;

                case "25": tempValue += 'z';
                    break;

                default: tempValue += remain;
                    break;
            }

            numInDecimal /= 26;
        }

        // reversing
        for (int i = tempValue.Length - 1; i >= 0; i--)
        {
            convertedValue += tempValue[i];
        }

        return convertedValue;
    }
}