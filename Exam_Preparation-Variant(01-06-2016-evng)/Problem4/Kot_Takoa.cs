using System;
using System.Linq;
using System.Text;

internal class Kot_Takoa
{
    private static string[] keywords = { "bool", "break", "byte", "case", "char", "class", "const", "continue", "decimal", "default", "double", "enum", "finally", "float", "goto", "in", "int", "internal", "long", "namespace", "new", "object", "operator", "out", "override", "params", "private", "protected", "public", "readonly", "ref", "return", "sbyte", "short", "static", "string", "this", "throw", "uint", "ulong", "ushort", "using", "void", "var" };

    private static void Main()
    {
        int numOfLines = int.Parse(Console.ReadLine());
        StringBuilder minifiedText = new StringBuilder();
        for (int i = 0; i < numOfLines; i++)
        {
            // get new line of input
            string line = Console.ReadLine();

            line = RemoveComments(line, ref i);
            line = RemoveWhiteSpaces(line);

            if (line != string.Empty)
            {
                minifiedText.Append(line);
            }
        }

        string result = SeparateSameTypeDeclaration(minifiedText.ToString());
        Console.WriteLine(result);
    }

    private static string RemoveComments(string line, ref int lineNum)
    {
        //// All single and multi-line comments should be removed from the code

        if (line != string.Empty)
        {
            // single line
            int commentIndex = line.IndexOf("//");
            if (commentIndex >= 0)
            {
                line = line.Remove(commentIndex);
                return line;
            }
            else
            {
                // multi-line
                StringBuilder codeBeforeAndAfterComment = new StringBuilder();
                int multiCommentOpnIndex = line.IndexOf("/*");
                int multiCommentClsngIndex = line.IndexOf("*/");
                if (multiCommentOpnIndex >= 0)
                {
                    if (multiCommentClsngIndex == -1)
                    {
                        line = line.Remove(multiCommentOpnIndex);
                        if (line != string.Empty)
                        {
                            codeBeforeAndAfterComment.Append(line);
                        }

                        while (multiCommentClsngIndex == -1)
                        {
                            line = Console.ReadLine();
                            lineNum++;

                            multiCommentClsngIndex = line.IndexOf("*/");
                        }

                        line = line.Remove(0, multiCommentClsngIndex + 2);
                        if (line != string.Empty)
                        {
                            codeBeforeAndAfterComment.Append(line);
                        }
                    }
                    else
                    {
                        int counter = ((multiCommentClsngIndex + 1) - multiCommentOpnIndex) + 1;
                        line = line.Remove(multiCommentOpnIndex, counter);
                    }
                }

                if (codeBeforeAndAfterComment.Length == 0)
                {
                    return line;
                }
                else
                {
                    return codeBeforeAndAfterComment.ToString();
                }
            }
        }

        return line;
    }

    private static string RemoveWhiteSpaces(string line)
    {
        //// All unnecessary white-spaces and all new lines should be removed from the code

        if (line != string.Empty)
        {
            line.Trim();
            for (int i = 0; i < line.Length; i++)
            {
                string currentWord = GetWord(line, i, out i);
                if (line[i] == ' ' && keywords.Contains(currentWord))
                {
                    if (currentWord == "in")
                    {
                        // put a space before and after 'in', in  foreach cycle
                        line = line.Insert(i - 2, " ");
                        i++;
                        continue;
                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
                    if (line[i] == ' ')
                    {
                        int counter = 0;
                        int startiIndex = i;
                        while (line[i] == ' ')
                        {
                            counter++;
                            i++;
                            if (i >= line.Length)
                            {
                                i--;
                                break;
                            }
                        }

                        line = line.Remove(startiIndex, counter);

                        if (counter > 0)
                        {
                            if (line == string.Empty) 
                            {
                                break;
                            }
                            else 
                            {
                                i -= counter + 1; 
                            }
                        }
                        else
                        {
                            i -= counter;
                        }
                    }
                    else if (line[i] == '"')
                    {
                        int quoteClsIndex = line.IndexOf('"', i + 1);
                        i = quoteClsIndex;
                    }
                }
            }
        }

        return line;
    }

    private static string SeparateSameTypeDeclaration(string line)
    {
        // All variable declarations of the same type that are directly one after another should be separated by a comma, instead of
        // being on different lines

        // bool, int, char, string, decimal
        for (int i = 0; i < line.Length; i++)
        {
            string currentWord = GetWord(line, i, out i);
            switch (currentWord)
            {
                case "bool":
                    while (true)
                    {
                        int semicolIndex = line.IndexOf(';', i);
                        string nextWord = GetWord(line.ToString(), semicolIndex + 1, out i);
                        if (nextWord == currentWord)
                        {
                            line = line.Remove(semicolIndex, 6);
                            line = line.Insert(semicolIndex, ",");
                        }
                        else
                        {
                            i = semicolIndex;
                            break;
                        }

                        i = semicolIndex;
                    }

                    break;

                case "int":
                    while (true)
                    {
                        int semicolIndex = line.IndexOf(';', i);
                        string nextWord = GetWord(line.ToString(), semicolIndex + 1, out i);
                        if (nextWord == currentWord)
                        {
                            line = line.Remove(semicolIndex, 5);
                            line = line.Insert(semicolIndex, ",");
                        }
                        else
                        {
                            i = semicolIndex;
                            break;
                        }

                        i = semicolIndex;
                    }

                    break;

                case "char":
                    while (true)
                    {
                        int semicolIndex = line.IndexOf(';', i);
                        string nextWord = GetWord(line.ToString(), semicolIndex + 1, out i);
                        if (nextWord == currentWord)
                        {
                            line = line.Remove(semicolIndex, 6);
                            line = line.Insert(semicolIndex, ",");
                        }
                        else
                        {
                            i = semicolIndex;
                            break;
                        }

                        i = semicolIndex;
                    }

                    break;

                case "string":
                    while (true)
                    {
                        int semicolIndex = line.IndexOf(';', i);
                        string nextWord = GetWord(line.ToString(), semicolIndex + 1, out i);
                        if (nextWord == currentWord)
                        {
                            line = line.Remove(semicolIndex, 8);
                            line = line.Insert(semicolIndex, ",");
                        }
                        else
                        {
                            i = semicolIndex;
                            break;
                        }

                        i = semicolIndex;
                    }

                    break;

                case "decimal":
                    while (true)
                    {
                        int semicolIndex = line.IndexOf(';', i);
                        string nextWord = GetWord(line.ToString(), semicolIndex + 1, out i);
                        if (nextWord == currentWord)
                        {
                            line = line.Remove(semicolIndex, 9);
                            line = line.Insert(semicolIndex, ",");
                        }
                        else
                        {
                            i = semicolIndex;
                            break;
                        }

                        i = semicolIndex;
                    }

                    break;

                default:
                    continue;
            }
        }

        return line.ToString();
    }

    private static string GetWord(string line, int i, out int index)
    {
        StringBuilder word = new StringBuilder();
        while (char.IsLetterOrDigit(line[i]))
        {
            word.Append(line[i]);

            i++;
            if (i >= line.Length)
            {
                i--;
                break;
            }
        }

        index = i;
        return word.ToString();
    }
}