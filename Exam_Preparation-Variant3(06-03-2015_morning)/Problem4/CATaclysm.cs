using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

internal class CATaclysm
{
    private static string[] primitiveDataTypes = { "sbyte", "sbyte?", "byte", "byte?", "short", "short?", "ushort", "ushort?", "int", "int?", "uint", "uint?", "long", "long?", "ulong", "ulong?", "float", "float?", "double", "double?", "decimal", "decimal?", "bool", "bool?", "char", "char?", "string" };
    private static List<string> currentScope = new List<string>();  // might use a stack instead of a list
    private static List<string> methods = new List<string>();
    private static List<string> loopsList = new List<string>();
    private static List<string> conditionalStatementsList = new List<string>();

    private static void Main()
    {
        // var reader = new StreamReader(@"D:\C#2\Variant 3 (2015-03-06, Morning)\Problem 4\Tests\test.010.in.txt");
        int totalNumOfLines = int.Parse(Console.ReadLine());    // reader

        for (int line = 0; line < totalNumOfLines; line++)
        {
            string[] currentLineWords = Console.ReadLine().Trim().Split(new char[] { ' ', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
            currentLineWords = CheckForNullable(currentLineWords);

            if (currentLineWords.Length > 0)
            {
                for (int index = 0; index < currentLineWords.Length; index++)
                {
                    string currentWord = currentLineWords[index];

                    switch (currentWord)
                    {
                        case "static":
                            if (index == 0)
                            {
                                currentScope.Add(currentWord);
                                CheckForPDTD(currentLineWords, out index, 3);   // 3 is the word after '('
                            }

                            break;

                        case "for":
                        case "foreach":
                        case "while":
                            currentScope.Add(currentWord);
                            CheckForPDTD(currentLineWords, out index);

                            break;

                        case "if":
                        case "else":
                            currentScope.Add(currentWord);
                            CheckForPDTD(currentLineWords, out index);

                            break;

                        case "}":
                            if (currentLineWords.Length == 1)
                            {
                                if (currentScope.Count != 0)
                                {
                                    currentScope.RemoveAt(currentScope.Count - 1);
                                }
                            }

                            break;

                        default:
                            // check word in PDTD array
                            if (primitiveDataTypes.Contains(currentWord))
                            {
                                string pdtdName = GetPDTDName(currentLineWords, index, out index);
                                if (pdtdName.Length > 0 && char.IsLetter(pdtdName[0]))
                                {
                                    string scope = currentScope[currentScope.Count - 1];
                                    if (scope == "static")
                                    {
                                        pdtdName = RemoveNonLeterChars(pdtdName);
                                        methods.Add(pdtdName);
                                    }
                                    else if (scope == "if" || scope == "else")
                                    {
                                        pdtdName = RemoveNonLeterChars(pdtdName);
                                        conditionalStatementsList.Add(pdtdName);
                                    }
                                    else if (scope == "for" || scope == "foreach" || scope == "while")
                                    {
                                        pdtdName = RemoveNonLeterChars(pdtdName);
                                        loopsList.Add(pdtdName);
                                    }
                                }
                            }

                            break;
                    }
                }
            }
        }

        PrintResult();
    }

    private static string RemoveNonLeterChars(string word)
    {
        for (int i = 0; i < word.Length; i++)
        {
            if (!char.IsLetter(word[i]))
            {
                word = word.Remove(i);
                break;
            }
        }

        return word;
    }

    private static string[] CheckForNullable(string[] currentLineWords)
    {
        int difference = 0;
        for (int i = 0; i < currentLineWords.Length; i++)
        {
            if (currentLineWords[i] == "?")
            {
                currentLineWords[i - 1] += "?";
                currentLineWords[i] = string.Empty;
                difference++;
            }
        }

        // remove empty entries
        string[] newWords = new string[currentLineWords.Length - difference];
        for (int i = 0, j = 0; i < currentLineWords.Length; i++)
        {
            if (currentLineWords[i] == string.Empty)
            {
                continue;
            }

            newWords[j] = currentLineWords[i];
            j++;
        }

        return newWords;
    }

    private static string GetPDTDName(string[] currentLineWords, int currentIndex, out int index)
    {
        string name = currentLineWords[++currentIndex];

        index = currentIndex;

        return name;
    }

    private static void CheckForPDTD(string[] currentLineWords, out int index, int currentIndex = 0)
    {
        index = currentLineWords.Length - 1;
        for (int i = currentIndex; i <= currentLineWords.Length - 1; i++)
        {
            if (primitiveDataTypes.Contains(currentLineWords[i]))
            {
                if (char.IsLetter(currentLineWords[i + 1][0]))
                {
                    string scope = currentScope[currentScope.Count - 1];
                    switch (scope)
                    {
                        case "static":
                            currentLineWords[i + 1] = RemoveNonLeterChars(currentLineWords[i + 1]);
                            methods.Add(currentLineWords[i + 1]);
                            break;

                        case "if":
                        case "else":
                            currentLineWords[i + 1] = RemoveNonLeterChars(currentLineWords[i + 1]);
                            conditionalStatementsList.Add(currentLineWords[i + 1]);
                            break;

                        case "for":
                        case "foreach":
                        case "while":
                            currentLineWords[i + 1] = RemoveNonLeterChars(currentLineWords[i + 1]);
                            loopsList.Add(currentLineWords[i + 1]);
                            break;

                        default:
                            i++;
                            break;
                    }
                }
            }
        }
    }

    private static void PrintResult()
    {
        string methodsContent = "None";
        if (methods.Count != 0)
        {
            methodsContent = string.Join(", ", methods);
        }

        Console.WriteLine("Methods -> {0}", methodsContent);

        string loopsContent = "None";
        if (loopsList.Count != 0)
        {
            loopsContent = string.Join(", ", loopsList);
        }

        Console.WriteLine("Loops -> {0}", loopsContent);

        string conditionalStatementsContent = "None";
        if (conditionalStatementsList.Count != 0)
        {
            conditionalStatementsContent = string.Join(", ", conditionalStatementsList);
        }

        Console.WriteLine("Conditional Statements -> {0}", conditionalStatementsContent);
    }
}