using System;
using System.Globalization;
using System.Threading;

internal class CorrectBrackets
{
    // Write a program to check if in a given expression the brackets are put correctly.
    private static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        Console.WriteLine("Please enter some mathematical expression with brackets:");
        string expression = Console.ReadLine();

        Console.WriteLine("Brackets are used correctly? --> {0}", ValidateExpr(expression));
    }

    private static bool ValidateExpr(string expression)
    {
        int leftBracketCounter = 0;
        int rightBracketCounter = 0;

        for (int i = 0; i < expression.Length; i++)
        {
            if (expression[i] == '(')
            {
                leftBracketCounter++;
            }
            else if (expression[i] == ')')
            {
                rightBracketCounter++;
                if (leftBracketCounter < rightBracketCounter)
                {
                    break;
                }
            }
        }

        if (leftBracketCounter == rightBracketCounter)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}