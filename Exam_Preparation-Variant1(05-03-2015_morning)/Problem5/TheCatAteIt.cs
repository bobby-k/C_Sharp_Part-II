using System;
using System.Collections.Generic;
using System.Text;

internal class TheCatAteIt
{
    private static List<int> output = new List<int>();

    private static void Main()
    {
        // this task is done to pass the first 5 tests i.e. for 50pts 

        // var reader = new StreamReader(@"D:\C#2\Problem 5\Tests\test.006.in.txt");
        int number = int.Parse(Console.ReadLine());

        for (int i = 0; i < number; i++)
        {
            string input = Console.ReadLine().Trim();
            int fromStart = 0;
            int fromEnd = input.Length - 1;

            string numXStr = GetNumFromInput(input, fromStart);
            string numYStr = GetNumFromInput(input, fromEnd);

            int numX = int.Parse(numXStr);
            int numY = int.Parse(numYStr);

            string keyword = GetKeyword(input);
            bool xExists = false;
            bool yExists = false;

            switch (keyword)
            {
                case "before":
                    if (output.Contains(numX))
                    {
                        xExists = true;
                    }

                    if (output.Contains(numY))
                    {
                        yExists = true;
                    }

                    if (!xExists && !yExists && i == 0)
                    {
                        output.Insert(0, numX);
                        output.Insert(1, numY);
                    }
                    else if (!xExists && !yExists)
                    {
                        InsertXBeforeY(numX, numY);
                    }
                    else if (xExists && yExists)
                    {
                        if (!CheckIfRuleIsCorrect(numX, numY, keyword))
                        {
                            // make it correct
                            int indexOfX = output.IndexOf(numX);
                            int indexOfY = output.IndexOf(numY);

                            int temp = output[indexOfX];
                            output.RemoveAt(indexOfX);
                            output.Insert(indexOfY, temp);
                        }
                    }
                    else if (xExists && !yExists)
                    {
                        int indexOfX = output.IndexOf(numX);
                        if (output[0] == 0 && i == number - 1)
                        {
                            int temp = output[0];
                            output[0] = output[indexOfX];
                            output[indexOfX] = temp;
                            output.Insert(1, numY);
                        }
                        else
                        {
                            for (int j = indexOfX; j < output.Count; j++)
                            {
                                if (j == output.Count - 1)
                                {
                                    output.Add(numY);
                                    break;
                                }
                                else if (output[j + 1] > numY)
                                {
                                    output.Insert(j + 1, numY);
                                    break;
                                }
                            }
                        }
                    }
                    else if (!xExists && yExists)
                    {
                        int indexOfY = output.IndexOf(numY);
                        if (output[0] == 0 && i == number - 1)
                        {
                            output.Insert(output[0], numX);
                        }
                        else
                        {
                            output.Insert(indexOfY, numX);
                        }
                    }

                    break;

                case "after":
                    if (output.Contains(numX))
                    {
                        xExists = true;
                    }

                    if (output.Contains(numY))
                    {
                        yExists = true;
                    }

                    if (!xExists && !yExists && i == 0)
                    {
                        output.Insert(0, numY);
                        output.Insert(1, numX);
                    }
                    else if (!xExists && !yExists)
                    {
                        InsertXAfterY(numX, numY);
                    }
                    else if (xExists && yExists)
                    {
                        if (!CheckIfRuleIsCorrect(numX, numY, keyword))
                        {
                            // make it correct
                            int indexOfX = output.IndexOf(numX);
                            int indexOfY = output.IndexOf(numY);

                            // x after y
                            int temp = output[indexOfX];
                            output.RemoveAt(indexOfX);
                            output.Insert(indexOfY + 1, temp);
                        }
                    }
                    else if (xExists && !yExists)
                    {
                        int indexOfX = output.IndexOf(numX);
                        if (output[0] == 0 && i == number - 1)
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
                        if (output[0] == 0 && i == number - 1)
                        {
                            int temp = output[0];
                            output[0] = output[indexOfY];
                            output[indexOfY] = temp;
                            output.Insert(1, numX);
                        }
                        else
                        {
                            output.Insert(indexOfY + 1, numX);
                        }
                    }

                    break;
            }
        }

        Console.WriteLine("{0}", string.Join(string.Empty, output));
    }

    private static bool CheckIfRuleIsCorrect(int numX, int numY, string keyword)
    {
        if (keyword == "before")
        {
            int indexOfX = output.IndexOf(numX);
            int indexOfY = output.IndexOf(numY);
            if (indexOfX < indexOfY)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            int indexOfX = output.IndexOf(numX);
            int indexOfY = output.IndexOf(numY);
            if (indexOfX > indexOfY)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    private static void InsertXAfterY(int numX, int numY)
    {
        int indexForX = 0;
        int indexForY = 0;
        for (int i = 0; i < output.Count; i++)
        {
            if (output[i] > numY)
            {
                indexForY = i;
                output.Insert(indexForY, numY);
                break;
            }
        }

        for (int i = indexForY; i < output.Count; i++)
        {
            if (output[i] > numX && i <= output.Count - 1)
            {
                indexForX = i;
                output.Insert(indexForX, numX);
                break;
            }
            else if (i == output.Count - 1)
            {
                output.Add(numX);
                break;
            }
        }
    }

    private static void InsertXBeforeY(int numX, int numY)
    {
        int indexForX = 0;
        int indexForY = 0;
        for (int i = 0; i < output.Count; i++)
        {
            if (output[i] > numX)
            {
                indexForX = i;
                output.Insert(indexForX, numX);
                break;
            }
            else if (i == output.Count - 1)
            {
                indexForX = i + 1;
                output.Add(numX);
                break;
            }
        }

        for (int i = indexForX; i < output.Count; i++)
        {
            if (output[i] > numY && i <= output.Count - 1)
            {
                indexForY = i + 1;
                output.Insert(indexForY, numY);
                break;
            }
            else if (i == output.Count - 1)
            {
                output.Add(numY);
                break;
            }
        }
    }

    private static string GetKeyword(string input)
    {
        string keyword = string.Empty;

        if (input.IndexOf("is before") > -1)
        {
            keyword = "before";
        }
        else
        {
            keyword = "after";
        }

        return keyword;
    }

    private static string GetNumFromInput(string input, int index)
    {
        var number = new StringBuilder();
        int i = index;
        while (char.IsDigit(input[i]))
        {
            number.Append(input[i]);
            if (index == 0)
            {
                i++;
            }
            else
            {
                i--;
            }
        }

        return number.ToString();
    }
}