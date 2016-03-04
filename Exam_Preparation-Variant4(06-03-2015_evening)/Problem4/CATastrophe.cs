using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

internal class CATastrophe
{
    private static List<string> methods = new List<string>();
    private static List<string> loops = new List<string>();
    private static List<string> conditionalStatements = new List<string>();
    private static string[] primitiveDataTypes = { "sbyte", "sbyte?", "byte", "byte?", "short", "short?", "ushort", "ushort?", "int", "int?", "uint", "uint?", "long", "long?", "ulong", "ulong?", "float", "float?", "double", "double?", "decimal", "decimal?", "bool", "bool?", "char", "char?", "string", "string?" };
    private static string[] conditionalStatementsScope = { "if", "else" };
    private static string[] loopsScope = { "for", "while", "foreach" };
    private static List<string> keywordsFound = new List<string>();

    private static void Main()
    {
        // var reader = new StreamReader(@"D:\C#2\Variant 4 (2015-03-06, Evening)\Problem 4\Tests\test.007.in.txt");
        int totatlNumOfLines = int.Parse(Console.ReadLine());   // reader

        for (int line = 0; line < totatlNumOfLines; line++)
        {
            string currentLine = Console.ReadLine().Trim();
            if (currentLine.Length > 0)
            {
                if (currentLine[0] == '}' && currentLine.Length == 1)
                {
                    keywordsFound.RemoveAt(keywordsFound.Count - 1);
                }

                string firstWordOfLine = GetFirstWord(currentLine);
                if (firstWordOfLine.Length > 0)
                {
                    if (firstWordOfLine == "static")
                    {
                        // check for PTD(Primitive Type Declaration) to the end of line and add it to methods list
                        keywordsFound.Add(firstWordOfLine);
                        var foundPTD = GetAllPTD(currentLine, currentLine.IndexOf('(') + 1);
                        methods.AddRange(foundPTD);
                    }
                    else if (loopsScope.Contains(firstWordOfLine))
                    {
                        // check for PTD to the end of line and add it to loops list
                        keywordsFound.Add(firstWordOfLine);
                        var foundPTD = GetAllPTD(currentLine);
                        loops.AddRange(foundPTD);
                    }
                    else if (conditionalStatementsScope.Contains(firstWordOfLine))
                    {
                        // go 1 line further than the next and check for PTD to the end of line and add it to conditionalStatements list
                        keywordsFound.Add(firstWordOfLine);
                        line += 2;
                        var foundPTD = GetAllPTD(currentLine);
                        conditionalStatements.AddRange(foundPTD);
                    }
                    else if (primitiveDataTypes.Contains(firstWordOfLine))
                    {
                        // check last keyword and according to it find which is the corresponding list to add to
                        string lastKeywordInList = keywordsFound[keywordsFound.Count - 1];
                        var foundPTD = GetAllPTD(currentLine);
                        switch (lastKeywordInList)
                        {
                            case "static":
                                methods.AddRange(foundPTD);
                                break;

                            case "if":
                            case "else":
                                conditionalStatements.AddRange(foundPTD);
                                break;

                            case "for":
                            case "foreach":
                            case "while":
                                loops.AddRange(foundPTD);
                                break;
                        }
                    }
                }
                else
                {
                    continue;
                }
            }
            else
            {
                continue;
            }
        }

        PrintOutput();
    }

    private static List<string> GetAllPTD(string currentLine, int index = 0)
    {
        var ptds = new List<string>();

        for (int i = index; i < currentLine.Length; i++)
        {
            string word = GetNextWord(currentLine, i);
            if (word.Length > 0)
            {
                if (primitiveDataTypes.Contains(word))
                {
                    if (currentLine[i + word.Length] == ' ')
                    {
                        i += word.Length + 1;
                        int correction;
                        string ptdName = GetPTDName(currentLine, i, out correction);
                        if (ptdName.Length > 0)
                        {
                            ptds.Add(ptdName);
                        }

                        i += ptdName.Length - 1 + correction;
                    }
                    else
                    {
                        i += word.Length;
                    }
                }
                else
                {
                    i += word.Length;
                }
            }
        }

        return ptds;
    }

    private static string GetPTDName(string line, int index, out int numOfSpaces)
    {
        StringBuilder name = new StringBuilder();
        numOfSpaces = 0;
        char currentChar;
        for (int i = index; i < line.Length; i++)
        {
            currentChar = line[i];
            if (char.IsLetter(currentChar))
            {
                name.Append(currentChar);
            }
            else if (currentChar == ' ' && name.Length == 0)
            {
                numOfSpaces++;
                continue;
            }
            else
            {
                break;
            }
        }

        return name.ToString();
    }

    private static string GetNextWord(string line, int index)
    {
        var word = new StringBuilder();
        char currentChar;
        for (int i = index; i < line.Length; i++)
        {
            currentChar = line[i];
            if (char.IsLetter(currentChar) || currentChar == '?')
            {
                word.Append(currentChar);
            }
            else
            {
                break;
            }
        }

        return word.ToString();
    }

    private static string GetFirstWord(string currentLine)
    {
        var word = new StringBuilder();
        int index = 0;
        char currentChar = currentLine[index];
        while (char.IsLetter(currentChar) || currentChar == '?')
        {
            word.Append(currentChar);
            index++;
            if (index >= currentLine.Length)
            {
                break;
            }
            else
            {
                currentChar = currentLine[index];
            }
        }

        return word.ToString();
    }

    private static void PrintOutput()
    {
        if (methods.Count == 0)
        {
            Console.WriteLine("Methods -> {0}", "None");
        }
        else
        {
            Console.WriteLine("Methods -> {0} -> {1}", methods.Count, string.Join(", ", methods));
        }

        if (loops.Count == 0)
        {
            Console.WriteLine("Loops -> {0}", "None");
        }
        else
        {
            Console.WriteLine("Loops -> {0} -> {1}", loops.Count, string.Join(", ", loops));
        }

        if (conditionalStatements.Count == 0)
        {
            Console.WriteLine("Conditional Statements -> {0}", "None");
        }
        else
        {
            Console.WriteLine("Conditional Statements -> {0} -> {1}", conditionalStatements.Count, string.Join(", ", conditionalStatements));
        }
    }
}