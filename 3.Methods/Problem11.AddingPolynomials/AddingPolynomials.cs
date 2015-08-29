using System;
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

        // TODO: да не се отпечатва + когато следващото число е отрицателно
        private static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            // Потребителя ще въвежда степента на полинома с който ще се работи
            Console.Write("Please enter the first polynomial's degree: ");
            int polynomialDegree = int.Parse(Console.ReadLine());
            // -2x^6 - 3x^3 + 4x^2 - x + 3

            Console.Write("Please enter the other polynomial's degree: ");
            int anotherPolynomialDegree = int.Parse(Console.ReadLine());
            // -2x^4 + 3x^2 + 5x + 8

            // чрез метода GetPolynomialCoefficients() потребителят ще въведе коефициентите пред всеки едночлен в масив след това с
            // метода PrintPolynomial() ще отпечатим на потребителя получените полиноми
            decimal[] firstPolynomial = GetPolynomialCoefficients(polynomialDegree);
            Console.Write("The first polynomial you entered is: ");
            PrintPolynomial(firstPolynomial);

            decimal[] secondPolynomial = GetPolynomialCoefficients(anotherPolynomialDegree);
            Console.Write("The second polynomial you entered is: ");
            PrintPolynomial(secondPolynomial);

            // тук даваме възможност на юзъра да провери въведените полиноми след което изчистваме конзолата 
            Console.WriteLine("PRESS ANY KEY TO MOVE ON...");
            Console.Beep();
            Console.ReadKey();
            Console.Clear();

            // отпечатваме си пак въведените полиноми за да следим операциите с тях по-късно
            Console.Write("First entered polynomial:");
            PrintPolynomial(firstPolynomial);
            Console.Write("Second entered polynomial:");
            PrintPolynomial(secondPolynomial);

            // разделител за по-добра визуализация
            Console.WriteLine(new string('*', 44));

            // чрез SumPolynomials() ще се пресмята събиране на въведените полиноми
            Console.WriteLine("The sum of the entered polynomials is:");
            decimal[] sum = SumPolynomials(firstPolynomial, secondPolynomial);
            PrintPolynomial(sum);

            Console.WriteLine(new string('*', 44));

            // чрез SubstractPolynomials() ще се пресмята изваждане на въведените полиноми
            Console.WriteLine("The deduction of the entered polynomials is:");
            decimal[] deduction = SubstractPolynomials(firstPolynomial, secondPolynomial);
            PrintPolynomial(deduction);

            Console.WriteLine(new string('*', 44));

            // чрез MultyplyPolynomials() ще се пресмята умножение на въведените полиноми
            Console.WriteLine("The product of the entered polynomials is:");
            decimal[] product = MultyplyPolynomials(firstPolynomial, secondPolynomial);
            PrintPolynomial(product);

            Console.WriteLine(new string('*', 44));
        }

        // Тук потребителя ще въвежда коеф.на отделните членове.На нулевата позиция ще се записва последният коеф. т.е. свободният член
        // а на последна позиция ще е старшият коеф. или първият, това ще улесни сметките на по-късен етап, също трябва да се направи
        // валидация на старши коефициента, за да се гарантира, че ще е винаги различен от 0.
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

        // Тук ще се събират двата въведени полинома, като резултата ще е нов полином от степен по-голямата от двете въведени в началото
        private static decimal[] SumPolynomials(decimal[] polynomial, decimal[] anotherPolynomial)
        {
            decimal[] sum = new decimal[Math.Max(polynomial.Length, anotherPolynomial.Length)];

            // трябва да определим кой е по-големият и кой по-малкият полином също ще ни трябва и дължината на по-малкият за да можем
            // когато я надхвърлим да не излезем от границите на масива.Тъй като масивите са референтен тип не е необходимо да
            // създаваме нови масиви в които да презапишем коеф. на по-големия и по-малкия а само нови променливи които да сочат към
            // вече подадените масиви показвайки по-големият и по-малкият
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

            // събираме двата масива с коеф.(нулев елемент на единия с нулев елемент на другия и т.н.) докато стигнем дължината на
            // по-краткия масив и след това просто презаписваме останалите елементи до края на по-големият масив
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

        // Тук ще се изваждат двата въведени полинома, като резултата ще е нов полином от степен по-голямата от двете въведени в началото
        private static decimal[] SubstractPolynomials(decimal[] polynomial, decimal[] anotherPolynomial)
        {
            decimal[] deduction = new decimal[Math.Max(polynomial.Length, anotherPolynomial.Length)];

            // следваме същата логика като при събирането, но извършваме действие изваждане
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

        // Тук ще се случва умножението на полиномите, като резултата ще е нов полином от степен сбора от степените на най-левият член
        // на единия полином и най-лявият член на другия полином
        private static decimal[] MultyplyPolynomials(decimal[] polynomial, decimal[] anotherPolynomial)
        {
            // вземаме дължините на по-големия и по-малкия полином (дължината всъщност е степента на полинома + 1)
            int biggerPolynomialLength = Math.Max(polynomial.Length, anotherPolynomial.Length);
            int smallerPolynomialLength = Math.Min(polynomial.Length, anotherPolynomial.Length);

            // дължината на крайният полином ще е броят едночлени минус 1, след - умножението на единият полином със всеки едночлен на
            // другия полином и сумирането на получените резултати, като всеки нов резултат се отмества с една позиция на вътре (както
            // е при умножение на числата в математиката).Крайният брой едночлени може да се пресметне като се знае, че всяко умножение
            // на полином с пореден едночлен от друг полином добавя един нов едночлен към броя на едночлените в произведението, т.е ако
            // първият има 5 монома, а вторият 3, то произведението ще има 5+(3-1) монома
            int productLength = biggerPolynomialLength + (smallerPolynomialLength - 1);
            decimal[] product = new decimal[productLength];

            // пак определяме по-големият и по-малкият полином подобно на събирането и изваждането
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

            // в тази матрица ще записваме резултатите от умножението на всички едночлени на по-големият полином с поредният едночлен
            // на по-малкият полином, като всеки следващ резултат ще се записва на нов ред отместен с една позиция на дясно, така ще
            // постигнем подравняване на подобните едночлени и ще можем да ги сумираме по-лесно нататък
            decimal[,] result = new decimal[smallerPolynomialLength, productLength];

            // вътрешният цикъл ще се грижи да се умножат всички елементи на по-големият полином с поредният елемент на по-малкия, а
            // външният да се мине по всички елементи на по-малкият полином.Допълнителните броячи за ред и колона ще се грижат за
            // правилното въвеждане в матрицата
            for (int i = 0, row = 0, col = 0; i < smallerPolynomialLength; i++)
            {
                col = i;
                for (int j = 0; j < biggerPolynomial.Length; j++)
                {
                    result[row, col] = biggerPolynomial[j] * smallerPolynomial[i];
                    col++;
                }
                row++;
            }

            #region Принтира матрицата, т.е. сметките за да се проследи визуално дали се смята правилно (uncomment when debugging)
            //for (int i = 0; i < result.GetLength(0); i++)
            //{
            //    for (int j = 0; j < result.GetLength(1); j++)
            //    {
            //        Console.Write("{0,3}",result[i, j]);
            //    }
            //    Console.WriteLine();
            //}
            #endregion

            // тук сумираме подобните едночлени и оформяме крайното произведение
            for (int col = 0; col < result.GetLength(1); col++)
            {
                for (int row = 0; row < result.GetLength(0); row++)
                {
                    product[col] += result[row, col];
                }
            }

            return product;
        }

        // Този метод ще отпечатва подаден полином по подходящ начин 
        private static void PrintPolynomial(decimal[] polynomial)
        {
            // за да се отпечата правино ще е необходима степента на полинома, можем да я получим като от дължината на масива с коеф.
            // извадим 1
            int polynomialDegree = polynomial.Length - 1;

            // тръгваме в обратен ред тъй като сме записали въведените от потребителя коефициенти по такъв начин, че на нулева позиция
            // имаме свободният член, а на последна позиция старши коеф.Това е направено с цел да се сумират по-лесно съотв. коеф. без
            // да се излиза от границите на масивите
            for (int i = polynomial.Length - 1; i >= 0; i--)
            {
                // тъй като последният член е всъщност ax^0, където "a" е коеф. и x^0 е 1 за всяко "x", то няма нужда от печатане на "x"
                if (i == 0) Console.Write(polynomial[i]);
                // предпоследният член е всъщност аx^1, където "a" е коеф. и x^1 е винаги "x" 
                else if (polynomialDegree == 1)
                {
                    // знаейки че тук имаме винаги "x", то проверяваме коеф. пред него ако е 0, и крайният резултат ще е 0, т.е. няма
                    // нужда от отпечатване
                    if (polynomial[i] == 0) continue;

                    // ако коеф пред "x" е 1, той също няма нужда да се отпечатва само се взема знака в случай че е -1
                    if (polynomial[i] == 1) Console.Write("x" + " + ");
                    else if (polynomial[i] == -1) Console.Write("-x" + " + ");
                    // във всички останали случаи се отпечатва коеф., "x" и +
                    else Console.Write(polynomial[i] + "x" + " + ");
                }
                // за всички останали едночлени (без последните 2)
                else
                {
                    // ще се проверява ако коеф. е 0 се преминава към следващият едночлен, тъй като всичко*0 = 0, т.е. 0 не променя
                    // резултата съответно няма нужда да се печата
                    if (polynomial[i] == 0)
                    {
                        polynomialDegree--;
                        continue;
                    }

                    // ако коеф. е 1 или -1 ще се отпечатва само знака, в случай че е "-", "x", степента и +
                    if (polynomial[i] == 1) Console.Write("x^" + polynomialDegree + " + ");
                    else if (polynomial[i] == -1) Console.Write("-x^" + polynomialDegree + " + ");

                    // при всички други случаи ще се отпечатва коеф., "x", степента и +
                    else Console.Write(polynomial[i] + "x^" + polynomialDegree + " + ");
                    polynomialDegree--;
                }
            }
            Console.WriteLine();
        }
    }
}