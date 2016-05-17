using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace Problem10.NFactorial
{
    internal class NFactorial
    {
        // Write a program to calculate n! for each n in the range [0..100].
        // Hint: Implement first a method that multiplies a number represented as array of digits by given integer number.

        // Логика: програмата ще пита за число от 1 до 100 вкл.,после ще превръща подаденото число в масив от цифрите му и ще го
        // умножава по предходното му число вече превърнато в масив от цифрите си, полученият резултат ще се умножава по поредното
        // предходно число и това ще продължава докато предходното число не стане 1.Тогава ще се отпечатва натрупаният резултат от
        // всички умножения, т.е. факториела на първоначално подаденото число

        // този метод ще се грижи за превръщането на числата в масив от цифри
        private static int[] CreateArrayOfDigits(int number)
        {
            var numberAsList = new List<int>();
            while (number > 0)
            {
                numberAsList.Add((int)(number % 10));
                number /= 10;
            }

            numberAsList.TrimExcess();
            return numberAsList.ToArray();
        }

        // тук се случва действителното пресмятане(умножава всяка цифра на първото число с всяка цифра на второто после събира
        // резултатите и връща нов масив от цифри представляващ произведението на двете подадени числа).
        private static int[] Multiply(int[] array, int[] anotherArray)
        {
            // тук ще се записва резултата от умножението на всяка цифра от първото число с всяка от второто, т.е. нулевият елемент на
            // този списък ще е резултата от умножението на първото число по последната цифра на второто, елемент[1] - резултата от
            // умножението на първото число по пред-последната цифра на второто и т.н.
            List<List<int>> product = new List<List<int>>();

            for (int i = 0; i < anotherArray.Length; i++)
            {
                List<int> tempProduct = new List<int>();
                int over = 0;
                // този цикъл пресмята умножението на единиците и ако резултата е повече от 9 записва за ст-ст на единици съответно
                // последното число от резултата, а остатъка го прехвърля към десетиците, и т.н. до последното число
                for (int j = 0; j < array.Length; j++)
                {
                    tempProduct.Add(((array[j] * anotherArray[i]) + over) % 10);
                    over = ((array[j] * anotherArray[i]) + over) / 10;
                }
                // в случай че има някакъв остатък след излизането от цикъла той също трябва да се добави
                if (over > 0)
                {
                    tempProduct.Add(over);
                }

                product.Add(tempProduct);
            }

            // крайният продукт е сбора на всички произведения (произведението на първото число с последната цифра на второто +
            // произведението на първото число с пред-последната цифра на второто и т.н.), като се внимава за това коя цифра каква
            // ст-ст представлява (единици, десетици и т.н.)
            List<int> finalProduct = new List<int>();

            // ако второто подадено число е с повече от една цифра, това значи че ще има повече от 1 пресмятания и трябва да си
            // гарантираме че няма да излезем от границите на листа за да работи гладко програмата, затова 
            if (anotherArray.Length > 1)
            {
                // проверяваме ако второто пресмятане е по-голямо или равно като брой цифри на първото ще трябва да добавим n на брой 0
                // към края на първото пресмятане за да не излизаме извън рамките при пресмятането на сумата на единици, десетици и
                // т.н. , n ще е разликата в броя цифри + 1
                if (product[1].Count >= product[0].Count)
                {
                    int diference = (product[1].Count - product[0].Count) + 1;
                    for (int i = 0; i < diference; i++)
                    {
                        product[0].Insert(product[0].Count, 0);
                    }
                }

                int remain = 0;

                // вземаме първото пресмятане 
                for (int i = 0, j = 0; i < product[0].Count; i++)
                {
                    // първата цифра на първото пресмятане записваме като стойност на единици в крайният продукт(тя ще е винаги м/у 0-9)
                    if (i == 0)
                    {
                        finalProduct.Add(product[0][i]);
                        continue;
                    }

                    // всяка следваща цифра събираме с първата по ред от второто пресмятане и записваме в крайният продукт само
                    // последната цифра на резултата в случай че той е двуцифрен, а остатъка се прехвърля към следващата двойка числа
                    finalProduct.Add(((product[0][i] + product[1][j]) + remain) % 10);
                    remain = ((product[0][i] + product[1][j]) + remain) / 10;
                    j++;
                }
                // в случай че има остатък след излизането от цикъла той също трябва да се добави в крайният продукт
                if (remain > 0)
                {
                    finalProduct.Add(remain);
                }
            }
            // ако второто подадено число не е с повече от една цифра, то умножението вече се е случило и резултата от него е записан
            // като нулев елемент в списъка product, така че просто трябва да го прочетем и да го запишем в краиният продукт
            else
            {
                // dobavq w krainiqt produkt umnojenieto na golqmoto do momenta chislo s ednocifrenoto predhodno
                for (int i = 0; i < product[0].Count; i++)
                {
                    finalProduct.Add(product[0][i]);
                }
            }

            return finalProduct.ToArray();
        }

        // този метод пресмята факториел на даденото число
        private static int[] Factorial(int number)
        {
            if (number == 1)
            {
                return new int[] { 1 };
            }

            int[] numAsArr = CreateArrayOfDigits(number);
            int[] prevNumber = CreateArrayOfDigits(--number);

            int[] result = Multiply(numAsArr, prevNumber);

            while (number >= 2)
            {
                result = Multiply(result, CreateArrayOfDigits(--number));
            }

            return result;
        }

        private static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            // The user input
            //Console.Write("Enter a number between 1 and 100 (incl.) to see its factorial: ");
            int number = int.Parse(Console.ReadLine());

            // валидация на входните данни
            while (number < 0 || number > 100)
            {
                Console.WriteLine("Wrong input!!!");
                Console.Write("Try again: ");
                number = int.Parse(Console.ReadLine());
            }

            if (number == 0)
            {
                Console.WriteLine(1);
                return;
            }

            Print(Factorial(number));
        }

        // този метод ще се грижи за отпечатването на натрупаният от умноженията резултат
        private static void Print(int[] result)
        {
            // принтира наопъки за да извади правилната последователност на цифрите
            for (int i = result.Length - 1; i >= 0; i--)
            {
                Console.Write(result[i]);
            }

            Console.WriteLine();
        }
    }
}