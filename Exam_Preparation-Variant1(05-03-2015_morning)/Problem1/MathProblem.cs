using System;
using System.Collections.Generic;
using System.Linq;

internal class MathProblem
{
    private static string numSysEquivalents = "abcdefghijklmnopqrs";

    private static void Main()
    {
        string input = Console.ReadLine();
        string[] inputSplited = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var substitution = new List<int>();
        var nums = new List<int>();

        foreach (var num in inputSplited)
        {
            for (int i = 0; i < num.Length; i++)
            {
                if (numSysEquivalents.Contains(num[i]))
                {
                    substitution.Add(numSysEquivalents.IndexOf(num[i]));
                }
            }

            int sum = 0;
            double power = 0;

            for (int i = substitution.Count - 1; i >= 0; i--)
            {
                sum += substitution[i] * (int)(Math.Pow(19.0, power));
                power++;
            }

            nums.Add(sum);
            sum = 0;
            power = 0;
            substitution.Clear();
        }

        Console.WriteLine("{0} = {1}", ConvertFromDecimal(nums.Sum(), 19), nums.Sum());
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
                case 0: tempValue += 'a';
                    break;

                case 1: tempValue += 'b';
                    break;

                case 2: tempValue += 'c';
                    break;

                case 3: tempValue += 'd';
                    break;

                case 4: tempValue += 'e';
                    break;

                case 5: tempValue += 'f';
                    break;

                case 6: tempValue += 'g';
                    break;

                case 7: tempValue += 'h';
                    break;

                case 8: tempValue += 'i';
                    break;

                case 9: tempValue += 'j';
                    break;

                case 10: tempValue += 'k';
                    break;

                case 11: tempValue += 'l';
                    break;

                case 12: tempValue += 'm';
                    break;

                case 13: tempValue += 'n';
                    break;

                case 14: tempValue += 'o';
                    break;

                case 15: tempValue += 'p';
                    break;

                case 16: tempValue += 'q';
                    break;

                case 17: tempValue += 'r';
                    break;

                case 18: tempValue += 's';
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