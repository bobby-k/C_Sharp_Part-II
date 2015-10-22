using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

class FormatNumber
{
    // Write a program that reads a number and prints it as a decimal number, hexadecimal number, percentage and in scientific notation.
    // Format the output aligned right in 15 symbols.
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        Console.Write("Enter some integer number here: ");
        int input = int.Parse(Console.ReadLine());

        string outputDecimal = string.Format("{0,15:D}", input);
        string outputHex = string.Format("{0,15:X}", input);
        string outputPercentage = string.Format("{0,15:P}", input);
        string outputExponential = string.Format("{0,15:E}", input);

        Console.WriteLine(outputDecimal);
        Console.WriteLine(outputHex);
        Console.WriteLine(outputPercentage);
        Console.WriteLine(outputExponential);
    }
}
