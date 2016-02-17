using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

internal class BracketsAgain
{
    private static string[] keyWords = new string[]
    {
        "abstract",
        "as",
        "base",
        "break",
        "case",
        "catch",
        "checked",
        "class",
        "const",
        "continue",
        "default",
        "delegate",
        "do",
        "else",
        "enum",
        "event",
        "explicit",
        "extern",
        "false",
        "finally",
        "fixed",
        "for",
        "foreach",
        "goto",
        "if",
        "implicit",
        "in",
        "interface",
        "internal",
        "is",
        "lock",
        "namespace",
        "new",
        "null",
        "operator",
        "out",
        "override",
        "params",
        "private",
        "protected",
        "public",
        "readonly",
        "ref",
        "return",
        "sealed",
        "sizeof",
        "stackalloc",
        "static",
        "struct",
        "switch",
        "this",
        "throw",
        "true",
        "try",
        "typeof",
        "unchecked",
        "unsafe",
        "using",
        "virtual",
        "void",
        "volatile",
        "while"
    };

    private static void Main()
    {
        // var reader = new StreamReader(@"D:\C#2\Problem 4\Tests\test.000.001.in.txt");
        int totalNumOfLines = int.Parse(Console.ReadLine().Trim());

        var methodCalls = new List<string>();
        string staticMethodName = string.Empty;
        bool foundNewStatic = false;

        for (int numOfLine = 0; numOfLine < totalNumOfLines; numOfLine++)
        {
            string currentLine = Console.ReadLine().Trim();

            #region if current line starts with "static" and there is another "static" before that
            if (currentLine.IndexOf("static ") == 0 && foundNewStatic)
            {
                string contentOfMethodCalls = string.Empty;
                if (methodCalls.Count > 0)
                {
                    contentOfMethodCalls = string.Join(", ", methodCalls);
                }
                else
                {
                    contentOfMethodCalls = "None";
                }

                Console.WriteLine("{0} -> {1}", staticMethodName, contentOfMethodCalls);
                methodCalls.Clear();
                staticMethodName = GetStaticMethodName(currentLine);
                var foundMethodCalls = CheckForMethodCall(currentLine, currentLine.IndexOf('('));
                if (foundMethodCalls.Count > 0)
                {
                    methodCalls.AddRange(foundMethodCalls);
                }
            }

            #endregion if current line starts with "static" and there is another "static" before that

            #region if current line starts with "static" and there is no other "static" before that
            else if (currentLine.IndexOf("static ") == 0)
            {
                foundNewStatic = true;
                staticMethodName = GetStaticMethodName(currentLine);

                var foundMethodCalls = CheckForMethodCall(currentLine, currentLine.IndexOf('('));
                if (foundMethodCalls.Count > 0)
                {
                    methodCalls.AddRange(foundMethodCalls);
                }
            }

            #endregion if current line starts with "static" and there is no other "static" before that

            #region if current line doesn't have "static" but it's already in a "static" method so just check for method calls
            else if (staticMethodName.Length > 0)
            {
                // check for method calls to the end of line
                var foundMethodCalls = CheckForMethodCall(currentLine, 0);
                if (foundMethodCalls.Count > 0)
                {
                    methodCalls.AddRange(foundMethodCalls);
                }
            }

            #endregion if current line doesn't have "static" but it's already in a "static" method so just check for method calls

            #region if there is no more than 1 static methods there will be no output so we prevent that by this check
            if (numOfLine == totalNumOfLines - 1 && staticMethodName.Length > 0)
            {
                string contentOfMethodCalls = string.Empty;
                if (methodCalls.Count > 0)
                {
                    contentOfMethodCalls = string.Join(", ", methodCalls);
                }
                else
                {
                    contentOfMethodCalls = "None";
                }

                Console.WriteLine("{0} -> {1}", staticMethodName, contentOfMethodCalls);
            }

            #endregion if there is no more than 1 static methods there will be no output so we prevent that by this check
        }
    }

    private static List<string> CheckForMethodCall(string currentLine, int currentIndex)
    {
        var foundMethodCalls = new List<string>();
        var currentWord = new StringBuilder();
        bool isKeyword = false;
        string lastFoundKeyword = string.Empty;

        #region Get current word and check when done if it's a keyword or method name.If it's a method add it to "foundMethodCalls"

        for (int currentCharIndex = currentIndex; currentCharIndex < currentLine.Length; currentCharIndex++)
        {
            if (char.IsLetter(currentLine[currentCharIndex]))
            {
                currentWord.Append(currentLine[currentCharIndex]);
            }
            else
            {
                if (currentWord.Length > 0)
                {
                    if (keyWords.Contains(currentWord.ToString()))
                    {
                        isKeyword = true;
                        lastFoundKeyword = currentWord.ToString();
                        currentWord.Clear();
                        continue;
                    }
                    else if (lastFoundKeyword != "new")
                    {
                        isKeyword = false;
                    }

                    if (IsMethodCall(currentLine, currentCharIndex))
                    {
                        if (isKeyword)
                        {
                            isKeyword = false;
                            currentWord.Clear();
                            continue;
                        }

                        foundMethodCalls.Add(currentWord.ToString());
                    }

                    currentWord.Clear();
                }
            }
        }

        #endregion Get current word and check when done if it's a keyword or method name.If it's a method add it to "foundMethodCalls"

        return foundMethodCalls;
    }

    private static bool IsMethodCall(string currentLine, int currentCharIndex)
    {
        for (int i = currentCharIndex; i < currentLine.Length; i++)
        {
            if (currentLine[i] == ' ')
            {
                continue;
            }

            if (currentLine[i] == '(')
            {
                return true;
            }

            break;
        }

        return false;
    }

    private static string GetStaticMethodName(string currentLine)
    {
        int indexOfOpnBracket = currentLine.IndexOf('(');
        string staticDeclaration = currentLine.Substring(0, indexOfOpnBracket).TrimEnd();
        var nameChars = new StringBuilder();

        int currentChar = staticDeclaration.Length - 1;
        while (staticDeclaration[currentChar] != ' ')
        {
            nameChars.Append(staticDeclaration[currentChar]);
            currentChar--;
        }

        StringBuilder name = new StringBuilder();
        for (int i = nameChars.Length - 1; i >= 0; i--)
        {
            name.Append(nameChars[i]);
        }

        return name.ToString();
    }
}