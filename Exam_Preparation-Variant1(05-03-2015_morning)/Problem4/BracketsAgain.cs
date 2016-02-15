using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

class BracketsAgain
{
    static void Main()
    {
        var reader = new StreamReader(@"D:\C#2\Problem 4\Tests\test.002.in.txt");
        int lines = int.Parse(reader.ReadLine().Trim());

        StringBuilder methodName = new StringBuilder();
        var invokedMethods = new List<string>();
        var staticMethods = new List<string>();
        string capitalLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        for (int i = 0; i < lines; i++)
        {
            string currentLine = reader.ReadLine().Trim();

            int index = currentLine.IndexOf("static");
            if (index > -1)
            {
                int nameIndex = currentLine.IndexOf(' ', index + 7);
                char currentChar = currentLine[++nameIndex];
                while (currentChar != '(')
                {
                    methodName.Append(currentChar);
                    currentChar = currentLine[++nameIndex];
                }

                staticMethods.Add(methodName.ToString());

                // finds invoked methods by finding .METHODNAME(

                bool endOfMethodDeclaration = false;
                int numOpennigBrackets = 0;
                int numClosingBrackets = 0;
                while (!endOfMethodDeclaration)
                {
                    currentLine = reader.ReadLine().Trim();
                    i++;

                    for (int currentIndex = 0; currentIndex < currentLine.Length; currentIndex++)
                    {
                        switch (currentLine[currentIndex])
                        {
                            case '{':
                                numOpennigBrackets++;
                                break;
                            case '}':
                                numClosingBrackets++;
                                break;
                            case '.':
                                int indexOfBracket = currentLine.IndexOf('(', currentIndex);
                                StringBuilder method = new StringBuilder();
                                for (int k = currentIndex + 1; k < indexOfBracket; k++)
                                {
                                    method.Append(currentLine[k]);
                                }

                                if (method.Length > 0)
                                {
                                    invokedMethods.Add(method.ToString());
                                }

                                if (indexOfBracket > -1)
                                {
                                    currentIndex = indexOfBracket;
                                }
                                break;

                            default:
                                if (capitalLetters.Contains(currentLine[currentIndex]))
                                {
                                    string currentWord = GetCurrentWord(currentIndex, currentLine);
                                    if (staticMethods.Contains(currentWord))
                                    {
                                        invokedMethods.Add(currentWord);
                                        currentIndex += currentWord.Length - 1; // poneje currentIndex ste se uvelichi pri zavartaneto
                                    }
                                    else
                                    {
                                        currentIndex += currentWord.Length - 1; // poneje currentIndex ste se uvelichi pri zavartaneto
                                    }
                                }
                                break;
                        }
                    }

                    if (numOpennigBrackets == numClosingBrackets)
                    {
                        endOfMethodDeclaration = true;
                    }
                }
            }
            else
            {
                continue;
            }

            string foundMethodCalls = string.Empty;
            if (invokedMethods.Count > 0)
            {
                foundMethodCalls = string.Join(", ", invokedMethods);
            }
            else
            {
                foundMethodCalls = "None";
            }
            Console.WriteLine("{0} -> {1}", methodName.ToString(), foundMethodCalls);
            methodName.Clear();
            invokedMethods.Clear();
        }

    }

    private static string GetCurrentWord(int startIndex, string currentLine)
    {
        var currentWord = new StringBuilder();
        while (char.IsLetterOrDigit(currentLine[startIndex]))
        {
            char currentChar = currentLine[startIndex];
            currentWord.Append(currentChar);

            startIndex++;
        }

        return currentWord.ToString();
    }
}
