using System;
using System.Numerics;
using System.Text;

internal class Tres4Numbers
{
    private static void Main()
    {
        BigInteger input = BigInteger.Parse(Console.ReadLine());

        string convertedValue = ConvertToBase9(input);
        string alienNumber = ConvertToAlienNumSys(convertedValue);

        Console.WriteLine(alienNumber);
    }

    private static string ConvertToAlienNumSys(string convertedValue)
    {
        StringBuilder newNumb = new StringBuilder();

        foreach (var symbol in convertedValue)
        {
            switch (symbol)
            {
                case '1':
                    newNumb.Append("VK-");
                    break;

                case '2':
                    newNumb.Append("*ACAD");
                    break;

                case '3':
                    newNumb.Append("^MIM");
                    break;

                case '4':
                    newNumb.Append("ERIK|");
                    break;

                case '5':
                    newNumb.Append("SEY&");
                    break;

                case '6':
                    newNumb.Append("EMY>>");
                    break;

                case '7':
                    newNumb.Append("/TEL");
                    break;

                case '8':
                    newNumb.Append("<<DON");
                    break;

                default:
                    newNumb.Append("LON+");
                    break;
            }
        }

        return newNumb.ToString();
    }

    private static string ConvertToBase9(BigInteger input)
    {
        string convertedValue = "";
        string tempValue = "";

        if (input == 0)
        {
            return "0";
        }

        while (input != 0)
        {
            BigInteger remain = input % 9;

            tempValue += remain;

            input /= 9;
        }

        // reversing
        for (int i = tempValue.Length - 1; i >= 0; i--)
        {
            convertedValue += tempValue[i];
        }

        return convertedValue;
    }
}