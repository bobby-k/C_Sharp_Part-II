using System;
using System.Globalization;
using System.Threading;

internal class SolveTasks
{
    // Write a program that can solve these tasks:
    // - Reverses the digits of a number
    // - Calculates the average of a sequence of integers
    // - Solves a linear equation a * x + b = 0 Create appropriate methods. Provide a simple text-based menu for the user to choose
    // which task to solve. Validate the input data:
    // - The decimal number should be non-negative
    // - The sequence should not be empty
    // - a should not be equal to 0

    // Логика: Ще реализираме менюто в Main() , като го сведем до избор на числа, като всяко число ще е всъщност метода изпълняващ
    // съответното действие, а с един while (true) цикъл ще дадем възможност да се извършват действия докато потребителя не избере
    // опцията за изход

    private static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        Console.Title = "Menu based solving tasks";
        Console.WriteLine("Please choose a task from the menu below:");
        while (true)
        {
            // simple text-based menu
            Console.WriteLine(new string('*', 71));
            Console.Write("1. Reverse digits ");
            Console.Write("2. Calculate average ");
            Console.Write("3. Solve linear equation ");
            Console.WriteLine("4. Exit ");
            Console.WriteLine(new string('*', 71));

            Console.Write("Waiting for your choice: ");
            int choosenTask = int.Parse(Console.ReadLine());
            switch (choosenTask)
            {
                case 1: ReverseDigits();
                    break;

                case 2: CalculateAverage();
                    break;

                case 3: SolveLinearEquation();
                    break;

                case 4: Console.WriteLine("Good Bye!"); return;
            }
            Console.WriteLine("What do you want to do next...");
        }
    }

    // този метод ще обръща въведено число наопъки като първо го превърне в стринг презапише в нов стринг стойностите му започвайки от
    // последният символ към началото и след това го превърне отново в число
    private static void ReverseDigits()
    {
        Console.Write("Please enter the number you want to reverse: ");
        decimal number = decimal.Parse(Console.ReadLine());
        number = Validate(number);

        string numberToStr = Convert.ToString(number);
        string numberTostrReversed = "";
        for (int i = numberToStr.Length - 1; i >= 0; i--)
        {
            numberTostrReversed += numberToStr[i];
        }

        decimal numberReversed = decimal.Parse(numberTostrReversed);
        Console.WriteLine("Here it is: {0}", numberReversed);
    }

    // този метод ще пресмята средно аритметичната ст-ст от поредица от стойности, като събере всички стойности и ги раздели на общият
    // брой елементи на поредицата
    private static void CalculateAverage()
    {
        Console.Write("Please enter the length of your sequence of integers: ");
        int length = int.Parse(Console.ReadLine());
        length = Validate(length);

        int[] sequence = new int[length];
        int sum = 0;

        Console.WriteLine("Now enter the integers:");
        for (int i = 0; i < sequence.Length; i++)
        {
            sequence[i] = int.Parse(Console.ReadLine());
            sum += sequence[i];
        }

        decimal average = sum / (decimal)length;
        Console.WriteLine("The average of your sequence is: {0}", average);
    }

    // този метод ще решава линейно уравнение като дава на потребителя да въведе стойностите за уравнението и после пресмята решенията
    // по формулата x = -b/a
    private static void SolveLinearEquation()
    {
        // ax+b=0 , x=-b/a

        Console.WriteLine("Linear equation format is: a*x + b = 0 , a != 0");
        Console.WriteLine("Please give values for \"a\" and \"b\"");

        Console.Write("a = ");
        decimal a = Decimal.Parse(Console.ReadLine());
        a = ValidateA(a);
        Console.Write("b = ");
        decimal b = Decimal.Parse(Console.ReadLine());

        decimal x = -b / a;
        Console.WriteLine("The solution of {0}*x + {1} = 0 is: {2}", a, b, x);
    }

    // валидациите за отделните методи
    private static decimal Validate(decimal number)
    {
        while (number < 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid input!!!\nThe number must be positive...");
            Console.Write("Try again: ");
            Console.ResetColor();
            number = decimal.Parse(Console.ReadLine());
        }

        return number;
    }

    private static int Validate(int length)
    {
        while (length <= 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid input!!!\nThe length must be greater than 0...");
            Console.Write("Try again: ");
            Console.ResetColor();
            length = int.Parse(Console.ReadLine());
        }

        return length;
    }

    private static decimal ValidateA(decimal a)
    {
        while (a == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid input!!!\nThe \"a\" must be different than 0...");
            Console.Write("Try again: ");
            Console.ResetColor();
            a = int.Parse(Console.ReadLine());
        }

        return a;
    }
}