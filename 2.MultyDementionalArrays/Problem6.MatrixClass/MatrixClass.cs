using System;
using System.Globalization;
using System.Threading;

namespace Problem6.MatrixClass
{
    class MatrixClass
    {
        // Write a class Matrix, to hold a matrix of integers. Overload the operators for adding, subtracting and multiplying of
        // matrices, indexer for accessing the matrix content and ToString().
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            Matrix someMatrix = new Matrix(2, 3);
            someMatrix[0, 0] = 1;
            someMatrix[0, 1] = 2;
            someMatrix[0, 2] = 3;
            someMatrix[1, 0] = 4;
            someMatrix[1, 1] = 5;
            someMatrix[1, 2] = 6;

            Matrix anotherMatrix = new Matrix(3, 2);
            anotherMatrix[0, 0] = 7;
            anotherMatrix[0, 1] = 8;
            anotherMatrix[1, 0] = 9;
            anotherMatrix[1, 1] = 10;
            anotherMatrix[2, 0] = 11;
            anotherMatrix[2, 1] = 12;

            Matrix otherMatrix = new Matrix(2, 3);
            otherMatrix[0, 0] = 7;
            otherMatrix[0, 1] = 8;
            otherMatrix[0, 2] = 9;
            otherMatrix[1, 0] = 10;
            otherMatrix[1, 1] = 11;
            otherMatrix[1, 2] = 12;

            Matrix sumOfMatrices = new Matrix(2, 3);                // +
            sumOfMatrices = someMatrix + otherMatrix;

            Matrix substractionOfMatrices = new Matrix(2, 3);       // -
            substractionOfMatrices = otherMatrix - someMatrix;

            Matrix productOfMatrices = new Matrix(2, 2);            // *
            productOfMatrices = someMatrix * anotherMatrix;

            Console.WriteLine(sumOfMatrices.ToString());            // +
            Console.WriteLine(substractionOfMatrices.ToString());   // -
            Console.WriteLine(productOfMatrices.ToString());        // *
        }
    }
}
