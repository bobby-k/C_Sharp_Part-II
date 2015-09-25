using System;
using System.Globalization;
using System.Threading;

internal class TriangleSurface
{
    // Write methods that calculate the surface of a triangle by given:
    // - Side and an altitude to it;
    // - Three sides;
    // - Two sides and an angle between them; Use System.Math.
    private static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        Console.WriteLine("Please choose what method to use in finding the triangle's surface");
        Console.WriteLine(new string('*', 75));
        Console.Write("| 1.Side and an altitude to it |");
        Console.Write(" 2.Three sides |");
        Console.WriteLine(" 3.Two sides and an angle |");
        Console.WriteLine(new string('*', 75));

        Console.Write("Enter your choice: ");
        byte choice = byte.Parse(Console.ReadLine());

        // validate user input
        while (choice < 1 || choice > 3)
        {
            Console.Write("Invalid choice!\nTry again! ");
            choice = byte.Parse(Console.ReadLine());
        }

        double surface;
        switch (choice)
        {
            case 1:
                Console.Write("Please enter the side: ");
                double side = double.Parse(Console.ReadLine());
                Console.Write("Please enter the altitude: ");
                double altitude = double.Parse(Console.ReadLine());
                surface = Triangle.TriangleSurface(side, altitude);
                Console.WriteLine("Surface is: {0}", surface);
                break;

            case 2:
                Console.Write("Please enter the side A: ");
                double sideA = double.Parse(Console.ReadLine());
                Console.Write("Please enter the side B: ");
                double sideB = double.Parse(Console.ReadLine());
                Console.Write("Please enter the side C: ");
                double sideC = double.Parse(Console.ReadLine());
                surface = Triangle.TriangleSurface(sideA, sideB, sideC);
                Console.WriteLine("Surface is: {0:N}", surface);
                break;

            case 3:
                Console.Write("Please enter the side A: ");
                sideA = double.Parse(Console.ReadLine());
                Console.Write("Please enter the side B: ");
                sideB = double.Parse(Console.ReadLine());
                Console.Write("Please enter the angle(in degrees): ");
                int angle = int.Parse(Console.ReadLine());
                surface = Triangle.TriangleSurface(sideA, sideB, angle);
                Console.WriteLine("Surface is: {0:N}", surface);
                break;
        }
    }
}