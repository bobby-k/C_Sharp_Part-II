using System;
using System.Collections.Generic;

internal class BadCat
{
    private static List<int> output = new List<int>();
    private static string keyword = string.Empty;

    private static void Main()
    {
        //var reader = new StreamReader(@"D:\C#2\Variant 2 (2015-03-05, Evening)\Problem 5\Tests\test.000.002.in.txt");
        int numOfInstructions = int.Parse(Console.ReadLine());  //  reader

        for (int i = 0; i < numOfInstructions; i++)
        {
            string instructionString = Console.ReadLine();  //  reader

            int numX = instructionString[0] - '0';
            int numY = instructionString[instructionString.Length - 1] - '0';
            if (instructionString.IndexOf("before") > -1)
            {
                keyword = "before";
            }
            else
            {
                keyword = "after";
            }

            switch (keyword)
            {
                case "before":
                    InsertXBeforeY(numX, numY);
                    break;

                case "after":
                    InsertXAfterY(numX, numY);
                    break;
            }
        }

        Console.WriteLine("{0}", string.Join(String.Empty, output));
    }

    private static void InsertXAfterY(int numX, int numY)
    {
        bool xExists = false;
        bool yExists = false;

        if (output.IndexOf(numX) > -1)
        {
            xExists = true;
        }

        if (output.IndexOf(numY) > -1)
        {
            yExists = true;
        }

        if (!xExists && !yExists && output.Count == 0)
        {
            output.Add(numY);
            output.Add(numX);
        }
        else if (!xExists && !yExists)
        {
            // insert Y
            int indexOfY = 0;
            for (int i = 0; i < output.Count; i++)
            {
                if (output[i] > numY)
                {
                    output.Insert(i, numY);
                    indexOfY = i;
                    break;
                }
            }

            // insert X
            for (int i = indexOfY; i < output.Count; i++)
            {
                if (i == output.Count - 1)
                {
                    output.Add(numX);
                    break;
                }
                else if (output[i] > numX)
                {
                    output.Insert(i + 1, numX);
                    break;
                }
            }
        }
        else if (xExists && yExists)
        {
            if (!CheckIfInstructionIsCorrect(numX, numY, keyword))
            {
                // make it correct
                int indexOfY = output.IndexOf(numY);
                int indexOfX = output.IndexOf(numX);
                output.RemoveAt(indexOfX);
                output.Insert(indexOfY + 1, numX);
            }
        }
        else if (xExists && !yExists)
        {
            int indexOfX = output.IndexOf(numX);
            if (output[0] == 0)
            {
                output.Insert(0, numY);
            }
            else
            {
                output.Insert(indexOfX, numY);
            }
        }
        else if (!xExists && yExists)
        {
            int indexOfY = output.IndexOf(numY);
            output.Insert(indexOfY + 1, numX);
        }
    }

    private static void InsertXBeforeY(int numX, int numY)
    {
        bool xExists = false;
        bool yExists = false;

        if (output.IndexOf(numX) > -1)
        {
            xExists = true;
        }

        if (output.IndexOf(numY) > -1)
        {
            yExists = true;
        }

        if (!xExists && !yExists && output.Count == 0)
        {
            output.Add(numX);
            output.Add(numY);
        }
        else if (!xExists && !yExists)
        {
            // insert X
            int indexOfX = 0;
            for (int i = 0; i < output.Count; i++)
            {
                if (output[i] > numX)
                {
                    output.Insert(i, numX);
                    indexOfX = i;
                    break;
                }
                else if (i + 1 < output.Count && output[i + 1] > numX)
                {
                    output.Insert(i + 1, numX);
                    break;
                }
                else if (i == output.Count - 1)
                {
                    output.Add(numX);
                    break;
                }
            }

            // insert Y
            for (int i = indexOfX; i < output.Count; i++)
            {
                if (i == output.Count - 1)
                {
                    output.Add(numY);
                    break;
                }
                else if (output[i] > numY)
                {
                    output.Insert(i + 1, numY);
                    break;
                }
            }
        }
        else if (xExists && yExists)
        {
            if (!CheckIfInstructionIsCorrect(numX, numY, keyword))
            {
                // make it correct
                int indexOfY = output.IndexOf(numY);
                int indexOfX = output.IndexOf(numX);
                output.RemoveAt(indexOfX);
                output.Insert(indexOfY, numX);
            }
        }
        else if (xExists && !yExists)
        {
            int indexOfX = output.IndexOf(numX);
            for (int i = indexOfX; i < output.Count; i++)
            {
                if (i == output.Count - 1)
                {
                    output.Add(numY);
                    break;
                }
                else if (output[i] > numY)
                {
                    output.Insert(i + 1, numY);
                    break;
                }
            }
        }
        else if (!xExists && yExists)
        {
            if (output[0] == 0)
            {
                output.Insert(0, numX);
            }
            else
            {
                int indexOfY = output.IndexOf(numY);
                output.Insert(indexOfY, numX);
            }
        }
    }

    private static bool CheckIfInstructionIsCorrect(int numX, int numY, string keyword)
    {
        int indexOFX = output.IndexOf(numX);
        int indexOFY = output.IndexOf(numY);

        if (keyword == "before")
        {
            if (indexOFX < indexOFY) return true;
            else return false;
        }
        else
        {
            if (indexOFX > indexOFY) return true;
            else return false;
        }
    }
}