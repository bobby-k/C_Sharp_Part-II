using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

class Konspiration
{
    static List<string> foundMethodCalls = new List<string>();
    static string staticDeclarationName = string.Empty;
    static string[] keywords = { "abstract", "as", "base", "bool", "break", "byte", "case", "catch", "char", "checked", "class", "const", "continue", "decimal", "default", "delegate", "do", "double", "else", "enum", "event", "explicit", "extern", "false", "finally", "fixed", "float", "for", "foreach", "goto", "if", "implicit", "in", "int", "interface", "internal", "is", "lock", "long", "namespace", "new", "null", "object", "operator", "out", "override", "params", "private", "protected", "public", "readonly", "ref", "return", "sbyte", "sealed", "short", "sizeof", "stackalloc", "static", "string", "struct", "switch", "this", "throw", "true", "try", "typeof", "uint", "ulong", "unchecked", "unsafe", "ushort", "using", "virtual", "void", "volatile", "while" };
    static void Main()
    {
        //var reader = new StreamReader(@"D:\C#2\Variant 2 (2015-03-05, Evening)\Problem 4\Tests\test.001.in.txt");
        int totalNumOfLines = int.Parse(Console.ReadLine());
        bool newStaticFound = false;

        for (int line = 0; line < totalNumOfLines; line++)
        {
            string currentLine = Console.ReadLine().Trim();

            if (CheckForStaticDeclaration(currentLine))
            {
                if (newStaticFound)
                {
                    // print
                    newStaticFound = false;
                    string callsContent = string.Empty;
                    if (foundMethodCalls.Count == 0)
                    {
                        callsContent = "None";
                        Console.WriteLine("{0} -> {1}", staticDeclarationName, callsContent);
                    }
                    else
                    {
                        callsContent = string.Join(", ", foundMethodCalls);
                        Console.WriteLine("{0} -> {1} -> {2}", staticDeclarationName, foundMethodCalls.Count, callsContent);
                    }

                    staticDeclarationName = string.Empty;
                    foundMethodCalls.Clear();
                }

                staticDeclarationName = GetStaticName(currentLine);
                CheckForMethodCall(currentLine, currentLine.IndexOf('('));
                newStaticFound = true;
                continue;
            }
            else if (staticDeclarationName.Length > 0)
            {
                CheckForMethodCall(currentLine);
            }

            if (line == totalNumOfLines - 1)
            {
                string callsContent = string.Empty;
                if (foundMethodCalls.Count == 0)
                {
                    callsContent = "None";
                    Console.WriteLine("{0} -> {1}", staticDeclarationName, callsContent);
                }
                else
                {
                    callsContent = string.Join(", ", foundMethodCalls);
                    Console.WriteLine("{0} -> {1} -> {2}", staticDeclarationName, foundMethodCalls.Count, callsContent);
                }


            }
        }
    }

    static void CheckForMethodCall(string line, int startIndex = 0)
    {
        bool isKeyword = false;
        string lastKeyword = string.Empty;
        for (int i = startIndex; i < line.Length; i++)
        {
            string currentWord = GetCurrentWord(line, i);

            if (currentWord.Length == 0)
            {
                continue;
            }
            else if (keywords.Contains(currentWord))
            {
                isKeyword = true;
                lastKeyword = currentWord;
                i += currentWord.Length;
                continue;
            }
            else if (lastKeyword != "new")
            {
                isKeyword = false;
            }

            if (IsMethodCall(currentWord, line, i))
            {
                if (isKeyword)
                {
                    isKeyword = false;
                    i += currentWord.Length;
                    continue;
                }

                foundMethodCalls.Add(currentWord);
            }

            i += currentWord.Length;
        }
    }

    static bool IsMethodCall(string word, string line, int startindex = 0)
    {
        int indexOfCharAfterWord = line.IndexOf(word, startindex) + word.Length;
        for (int i = indexOfCharAfterWord; i < line.Length; i++)
        {
            if (line[i] == ' ')
            {
                continue;
            }

            if (line[i] == '(')
            {
                return true;
            }

            break;
        }

        return false;
    }

    static string GetCurrentWord(string line, int index)
    {
        var word = new StringBuilder();

        for (int i = index; i < line.Length; i++)
        {
            if (char.IsLetter(line[i]))
            {
                word.Append(line[i]);
            }
            else
            {
                break;
            }
        }

        return word.ToString();
    }

    static string GetStaticName(string line)
    {
        StringBuilder nameReversed = new StringBuilder();
        StringBuilder name = new StringBuilder();

        int indexOfStatic = line.IndexOf("static ");
        int indexOfOpnBracket = line.IndexOf("(");
        for (int i = indexOfOpnBracket - 1; i >= 0; i--)
        {
            if (line[i] == ' ' && nameReversed.Length == 0)
            {
                continue;
            }
            else if (line[i] == ' ' && nameReversed.Length > 0)
            {
                break;
            }
            else
            {
                nameReversed.Append(line[i]);
            }
        }

        // reversing
        for (int i = nameReversed.Length - 1; i >= 0; i--)
        {
            name.Append(nameReversed[i]);
        }

        return name.ToString();
    }

    static bool CheckForStaticDeclaration(string line)
    {
        int indexOfStatic = line.IndexOf("static ");
        if (indexOfStatic == 0)
        {
            return true; // there is static declaration only if "static" is the first word of line
        }

        return false;
    }
}
