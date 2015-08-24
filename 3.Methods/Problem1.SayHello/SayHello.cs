using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;

namespace Problem1.SayHello
{
    class SayHello
    {
        // Write a method that asks the user for his name and prints “Hello, <name>”
        // Write a program to test this method.
        static void PrintName()
        {
            Console.Write("Please enter your name: ");
            string name = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Hello, {0}!", name);
        }
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            PrintName();
        }
    }
}
