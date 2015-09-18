using System;
using System.Globalization;
using System.Threading;

internal class BinaryFloatingPoint
{
    // Write a program that shows the internal binary representation of given 32-bit signed floating-point number in IEEE 754 format
    // (the C# type float).

    private static float number = -21.15625f;
    private static float z = Math.Abs(number);
    private static int p = (int)Math.Floor(Math.Log(z, 2));

    // Логика: за подробно обяснен алгоритъм виж на този линк http://www.markovood.eu/videos/Computer%20representation%20of%20a%20floating%20point%20number.mp4
    private static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        Console.WriteLine("{0} in binary is", number);

        Console.Write("Sign  ");
        Console.Write("Exponent  ");
        Console.WriteLine("Mantissa  ");
        Console.Write("{0,5}", GetSign(number) + "  ");
        Console.Write("{0,11}", GetExponent(number) + "  ");
        Console.WriteLine("{0}", GetMantissa(number));
    }
    private static int GetSign(float number)
    {
        if (number < 0)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    private static string GetExponent(float number)
    {
        string exponent = ConvertToBinary(p + 127);
        if (exponent.Length < 8)
        {
            while (exponent.Length < 8)
            {
                exponent = exponent.Insert(0, "0");
            }
        }

        return exponent;
    }

    private static string GetMantissa(float number)
    {
        string mantissa = "";

        ulong j = (ulong)Math.Round(z * Math.Pow(2, 23 - p));

        mantissa = ConvertToBinary(j);
        mantissa = mantissa.Remove(0, 1);
        return mantissa;
    }

    private static string ConvertToBinary(dynamic decimalNum)
    {
        string binary = "";
        string tempBinaryRepr = "";
        int remain = 0;
        for (dynamic i = decimalNum; i > 0; i /= 2)
        {
            remain = (int)i % 2;
            tempBinaryRepr += remain;
        }
        // reversing
        for (int i = tempBinaryRepr.Length - 1; i >= 0; i--)
        {
            binary += tempBinaryRepr[i];
        }
        return binary;
    }
}