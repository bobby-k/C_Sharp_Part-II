using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace Problem11.AddingPolynomials
{
    internal class AddingPolynomials
    {
        // Write a method that adds two polynomials. Represent them as arrays of their coefficients.
        // Example: x^2 + 5 = (1 * x^2) + (0 * x) + 5 => {5, 0, 1}

        // действия с полиноми и въобще за полиномите --> http://stancho.roncho.net/HighMath/Polinoms/Polynomes.html

        // Логика: събирането на полиноми става като се съберат коефициентите пред еднаквите степени на всеки моном съдържащ се в
        // полинома и крайният резултат е полином от степен по-голямата от степените на събираните полиноми за повече яснота да
        // се погледне на предоставеният линк

        // TODO: да се не се отпечатва + когато следващото число е отрицателно
        // TODO: Explanations
        // TODO: finish the multiplication of polynomials method
        private static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            Console.Write("Please enter the first polynomial's degree: ");
            int polynomialDegree = int.Parse(Console.ReadLine());
            //string polynomial = "-2x^6 - 3x^3 + 4x^2 - x + 3";

            Console.Write("Please enter the other polynomial's degree: ");
            int anotherPolynomialDegree = int.Parse(Console.ReadLine());
            //string anotherPolynomial = "-2x^4 + 3x^2 + 5x + 8";

            decimal[] firstPolynomial = GetPolynomialCoefficients(polynomialDegree);
            Console.Write("The first polynomial you entered is: ");
            PrintPolynomial(firstPolynomial);

            decimal[] secondPolynomial = GetPolynomialCoefficients(anotherPolynomialDegree);
            Console.Write("The second polynomial you entered is: ");
            PrintPolynomial(secondPolynomial);

            Console.Clear();
            Console.Write("First entered polynomial:");
            PrintPolynomial(firstPolynomial);
            Console.Write("Second entered polynomial:");
            PrintPolynomial(secondPolynomial);

            Console.WriteLine(new string('*', 40));
            Console.WriteLine("The sum of the entered polynomials is:");
            decimal[] sum = SumPolynomials(firstPolynomial, secondPolynomial);
            // correct result -2x^6 + -2x^4 + -3x^3 + 7x^2 + 4x + 11
            PrintPolynomial(sum);

            Console.WriteLine(new string('*', 40));
            Console.WriteLine("The deduction of the entered polynomials is:");
            decimal[] deduction = SubstractPolynomials(firstPolynomial, secondPolynomial);
            // correct result -2x^6 + 2x^4 + -3x^3 + x^2 + -6x + -5 
            PrintPolynomial(deduction);

            Console.WriteLine(new string('*', 40));
            Console.WriteLine("The product of the entered polynomials is:");
            decimal[] product = MultyplyPolynomials(firstPolynomial, secondPolynomial);
            // correct result 
            PrintPolynomial(product);

            Console.WriteLine(new string('*', 40));
        }
        private static decimal[] GetPolynomialCoefficients(int polynomialDegree)
        {
            Console.WriteLine("Please enter the coefficients starting from the leading one and going on to the end...");

            decimal[] polynomialCoefficients = new decimal[polynomialDegree + 1];

            for (int i = polynomialCoefficients.Length - 1; i >= 0; i--)
            {
                polynomialCoefficients[i] = decimal.Parse(Console.ReadLine());
                #region Validation of the leading coefficient's value
                while (polynomialCoefficients[polynomialCoefficients.Length - 1] == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("!!!Leading coefficient can not be a 0!!!");
                    Console.ResetColor();
                    Console.Write("Enter new value: ");
                    polynomialCoefficients[polynomialCoefficients.Length - 1] = decimal.Parse(Console.ReadLine());
                }
                #endregion
            }

            return polynomialCoefficients;
        }
        private static decimal[] SumPolynomials(decimal[] polynomial, decimal[] anotherPolynomial)
        {
            decimal[] sum = new decimal[Math.Max(polynomial.Length, anotherPolynomial.Length)];

            decimal[] biggerPolynomial;
            decimal[] smallerPolynomial;
            int smallerLength;
            if (polynomial.Length >= anotherPolynomial.Length)
            {
                biggerPolynomial = polynomial;
                smallerPolynomial = anotherPolynomial;
                smallerLength = anotherPolynomial.Length;
            }
            else
            {
                biggerPolynomial = anotherPolynomial;
                smallerPolynomial = polynomial;
                smallerLength = polynomial.Length;
            }

            for (int i = 0; i < sum.Length; i++)
            {
                if (smallerLength == 0) sum[i] = biggerPolynomial[i];
                else
                {
                    sum[i] = biggerPolynomial[i] + smallerPolynomial[i];
                    smallerLength--;
                }
            }

            return sum;
        }
        private static decimal[] SubstractPolynomials(decimal[] polynomial, decimal[] anotherPolynomial)
        {
            decimal[] deduction = new decimal[Math.Max(polynomial.Length, anotherPolynomial.Length)];

            decimal[] biggerPolynomial;
            decimal[] smallerPolynomial;
            int smallerLength;
            if (polynomial.Length >= anotherPolynomial.Length)
            {
                biggerPolynomial = polynomial;
                smallerPolynomial = anotherPolynomial;
                smallerLength = anotherPolynomial.Length;
            }
            else
            {
                biggerPolynomial = anotherPolynomial;
                smallerPolynomial = polynomial;
                smallerLength = polynomial.Length;
            }

            for (int i = 0; i < deduction.Length; i++)
            {
                if (smallerLength == 0) deduction[i] = biggerPolynomial[i];
                else
                {
                    deduction[i] = biggerPolynomial[i] - smallerPolynomial[i];
                    smallerLength--;
                }
            }

            return deduction;
        }
        private static decimal[] MultyplyPolynomials(decimal[] polynomial, decimal[] anotherPolynomial)
        {
            int biggerPolynomialLength = Math.Max(polynomial.Length, anotherPolynomial.Length);
            int smallerPolynomialLength = Math.Min(polynomial.Length, anotherPolynomial.Length);
            int productLength = biggerPolynomialLength + (smallerPolynomialLength - 1);
            decimal[] product = new decimal[productLength];

            decimal[] biggerPolynomial;
            decimal[] smallerPolynomial;
            if (biggerPolynomialLength == polynomial.Length)
            {
                biggerPolynomial = polynomial;
                smallerPolynomial = anotherPolynomial;
            }
            else
            {
                biggerPolynomial = anotherPolynomial;
                smallerPolynomial = polynomial;
            }

            var result = new List<decimal[]>();// v result ima vsichki smetki kato otdelni masiwi s koef
            for (int j = 0; j < smallerPolynomialLength; j++)
            {
                decimal[] tempResult = new decimal[biggerPolynomialLength];
                for (int k = 0; k < biggerPolynomialLength; k++)
                {
                    tempResult[k] = biggerPolynomial[k] * smallerPolynomial[j];
                }
                result.Add(tempResult);
            }

            for (int i = 0; i < product.Length; i++)
            {
                // todo
            }

            return product;
        }
        private static void PrintPolynomial(decimal[] polynomial)
        {
            int polynomialDegree = polynomial.Length - 1;

            for (int i = polynomial.Length - 1; i >= 0; i--)
            {
                if (i == 0) Console.Write(polynomial[i]);
                else if (polynomialDegree == 1)
                {
                    if (polynomial[i] == 0) continue;

                    if (polynomial[i] == 1) Console.Write("x" + " + ");
                    else if (polynomial[i] == -1) Console.Write("-x" + " + ");
                    else Console.Write(polynomial[i] + "x" + " + ");
                }
                else
                {
                    if (polynomial[i] == 0)
                    {
                        polynomialDegree--;
                        continue;
                    }
                    if (polynomial[i] == 1) Console.Write("x^" + polynomialDegree + " + ");
                    else if (polynomial[i] == -1) Console.Write("-x^" + polynomialDegree + " + ");
                    else Console.Write(polynomial[i] + "x^" + polynomialDegree + " + ");
                    polynomialDegree--;
                }
            }
            Console.WriteLine();
        }
    }
}