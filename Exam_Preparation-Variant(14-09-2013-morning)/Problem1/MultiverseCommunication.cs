using System;
using System.Collections.Generic;
using System.Text;

internal class MultiverseCommunication
{
    private static void Main()
    {
        string message = Console.ReadLine();

        var numberInBase13 = GetNumber(message);
        var numInBase10 = ConvertToBase10(numberInBase13);

        Console.WriteLine(numInBase10);
    }

    private static long ConvertToBase10(List<int> numberInBase13)
    {
        long number = 0L;

        for (int i = numberInBase13.Count - 1, j = 0; i >= 0; i--, j++)
        {
            number += numberInBase13[i] * (long)Math.Pow(13.0, j);
        }

        return number;
    }

    private static List<int> GetNumber(string message)
    {
        var number = new List<int>();

        StringBuilder digit = new StringBuilder();
        for (int i = 0; i < message.Length; i += 3)
        {
            digit.Append(message[i]);
            digit.Append(message[i + 1]);
            digit.Append(message[i + 2]);
            switch (digit.ToString())
            {
                case "CHU":
                    number.Add(0);
                    break;

                case "TEL":
                    number.Add(1);
                    break;

                case "OFT":
                    number.Add(2);
                    break;

                case "IVA":
                    number.Add(3);
                    break;

                case "EMY":
                    number.Add(4);
                    break;

                case "VNB":
                    number.Add(5);
                    break;

                case "POQ":
                    number.Add(6);
                    break;

                case "ERI":
                    number.Add(7);
                    break;

                case "CAD":
                    number.Add(8);
                    break;

                case "K-A":
                    number.Add(9);
                    break;

                case "IIA":
                    number.Add(10);
                    break;

                case "YLO":
                    number.Add(11);
                    break;

                case "PLA":
                    number.Add(12);
                    break;
            }

            digit.Clear();
        }

        return number;
    }
}