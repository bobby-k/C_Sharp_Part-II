using System;

internal class Triangle
{
    public static double TriangleSurface(double sideA, double altitude)
    {
        double surface = (sideA * altitude) / 2;
        return surface;
    }

    public static double TriangleSurface(double sideA, double sideB, double sideC)
    {
        double p = (sideA + sideB + sideC) / 2;
        double surface = Math.Sqrt(p * (p - sideA) * (p - sideB) * (p - sideC));
        return surface;
    }

    public static double TriangleSurface(double sideA, double sideB, int degrees)
    {
        double radians = (degrees * Math.PI) / 180;
        double surface = ((sideA * sideB * (Math.Sin(radians)))) / 2;
        return surface;
    }
}