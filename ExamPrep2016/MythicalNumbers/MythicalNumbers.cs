using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MythicalNumbers
{
    public class MythicalNumbers
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            double lastDigit = double.Parse(input[2].ToString());
            double result = 0;

            if (lastDigit == 0)
            {
                result = Multiply(input[0], input[1]);
            }
            else if (lastDigit > 0 && lastDigit <= 5) // ? >= or >
            {
                result = Multiply(input[0], input[1]) / double.Parse(input[2].ToString());
            }
            else if (lastDigit > 5)
            {
                result = Sum(input);
            }

            Console.WriteLine("{0:F2}", result);
        }

        private static double Sum(string input)
        {
            double firstDigit = double.Parse(input[0].ToString());
            double secondDigit = double.Parse(input[1].ToString());
            double thirdDigit = double.Parse(input[2].ToString());

            return (firstDigit + secondDigit) * thirdDigit;
        }

        private static double Multiply(char p1, char p2)
        {
            double firstNum = double.Parse(p1.ToString());
            double secondNum = double.Parse(p2.ToString());

            return firstNum * secondNum;
        }
    }
}
