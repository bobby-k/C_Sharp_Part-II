using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;

internal class ArithmeticalExpression
{
    // Write a program that calculates the value of given arithmetical expression. 
    // The expression can contain the following elements only:
    // - Real numbers, e.g. 5, 18.33, 3.14159, 12.6
    // - Arithmetic operators: +, -, *, / (standard priorities)
    // - Mathematical functions: ln(x), sqrt(x), pow(x,y)
    // - Brackets (for changing the default priorities): (, )

    // examples: 
    // (3+5.3) * 2.7 - ln(22) / pow(2.2, -1.7) --> ~10.6 
    // pow(2, 3.14) * (3 - (3 * sqrt(2) - 3.2) + 1.5*0.3) --> ~21.22

    private static readonly char[] operators = { '+', '-', '*', '/' };
    private static readonly char[] brackets = { '(', ')' };
    private static readonly string[] functions = { "ln", "sqrt", "pow" };
    private static readonly char[] leftAssociativeOperators = { '+', '-', '*', '/' };
    private static readonly char[] rightAssociativeOperators = { '=', '^' };

    public static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        string input = TrimInput(Console.ReadLine()).ToLower();// makes sure that function names will always be in small letters

        var tokens = SeparateTokens(input);
        var RPN = ConvertToRPN(tokens);
        double result = CalculateRPN(RPN);

        Console.Clear();
        Console.WriteLine("{0} is \n{1}", input, result);
    }

    public static string TrimInput(string input)
    {
        StringBuilder trimmedInput = new StringBuilder();

        foreach (char symbol in input)
        {
            if (symbol != ' ')
            {
                trimmedInput.Append(symbol);
            }
        }
        return trimmedInput.ToString();
    }

    public static List<string> SeparateTokens(string input)
    {
        var tokens = new List<string>();

        // creates the number, symbol by symbol in case that it's more than one digit or it's a floating point number or it's a negative
        StringBuilder number = new StringBuilder();

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == '-' && (i == 0 || input[i - 1] == ',' || input[i - 1] == '(')) // checks if '-' is an operator or a sign
            {
                number.Append(input[i]);
            }
            else if (char.IsDigit(input[i]))
            {
                while (char.IsDigit(input[i]) || input[i] == '.')// collects all digits including '.' to get the whole number
                {
                    number.Append(input[i]);
                    i++;
                    if (i >= input.Length) break; // makes sure you don't go out of the bounds of the input
                }
                tokens.Add(number.ToString());
                number.Clear();
                i--;
            }
            else if (operators.Contains(input[i]))
            {
                if (operators.Contains(input[i - 1])) // in case that 2 operators are entered in a row example: 1+-2 must be 1+(-2)
                {
                    throw new ArgumentException("Cannot have two operators in a row!");
                }
                else // otherwise add as a token
                {
                    tokens.Add(input[i].ToString());
                }
            }
            else if (brackets.Contains(input[i]))
            {
                tokens.Add(input[i].ToString());
            }
            else if (char.IsLetter(input[i]))
            {
                StringBuilder functionName = new StringBuilder();
                while (char.IsLetter(input[i]))
                {
                    functionName.Append(input[i]);
                    i++;
                }
                i--;

                if (functions.Contains(functionName.ToString()))
                {
                    tokens.Add(functionName.ToString());
                }
                else
                {
                    throw new ArgumentException("Invalid function name!");
                }
            }
            else if (input[i] == ',')
            {
                tokens.Add(input[i].ToString());
            }
            else // any other case
            {
                throw new ArgumentException("Wrong Expression!\nUnrecognized Symbol");
            }
        }

        return tokens;
    }

    public static int GetPrecedence(string arithmeticOperator)
    {
        if (arithmeticOperator == "+" || arithmeticOperator == "-")
        {
            return 1; // smaller precedence
        }
        else
        {
            return 2; // bigger precedence
        }
    }

    public static Queue<string> ConvertToRPN(List<string> tokens)   // Shunting Yard Algorithm from wikipedia
    {
        var output = new Queue<string>();   // required by the algorithm
        var stack = new Stack<string>();    // required by the algorithm

        for (int i = 0; i < tokens.Count; i++)
        {
            string token = tokens[i];

            double number;
            if (double.TryParse(token, out number))
            {
                output.Enqueue(token); // or output.Enqueue(number.ToString());
            }
            else if (functions.Contains(token))
            {
                stack.Push(token);
            }
            else if (token == ",")
            {
                while (stack.Peek() != "(")
                {
                    output.Enqueue(stack.Pop());
                }
                // if not working put it first , before while
                if (!stack.Contains("("))
                {
                    throw new ArgumentException("No closing bracket found!");
                }
            }
            else if (token == "(")
            {
                stack.Push(token);
            }
            else if (operators.Contains(token[0]))
            {
                // while there is an operator token, o2, at the top of the operator stack, and either o1 is left-associative and its
                // precedence is less than or equal to that of o2, or o1 is right associative, and has precedence less than that of o2,
                // then pop o2 off the operator stack, onto the output queue; push o1 onto the operator stack. string o1 = token;
                // string o2 = stack.Peek();

                while (stack.Count != 0 && operators.Contains(stack.Peek()[0]) &&
                    (((GetPrecedence(token) <= GetPrecedence(stack.Peek())) && leftAssociativeOperators.Contains(token[0])) ||
                     ((GetPrecedence(token) < GetPrecedence(stack.Peek())) && rightAssociativeOperators.Contains(token[0]))))
                {
                    output.Enqueue(stack.Pop());
                }

                stack.Push(token);
            }
            else if (token == ")")
            {
                if (!stack.Contains("(")) throw new ArgumentException("No opening bracket found!");

                while (stack.Peek() != "(")
                {
                    output.Enqueue(stack.Pop());
                }

                stack.Pop();

                if (stack.Count != 0 && functions.Contains(stack.Peek())) output.Enqueue(stack.Pop());
            }
        }

        while (stack.Count != 0)
        {
            if (brackets.Contains(stack.Peek()[0])) throw new ArgumentException("Invalid brackets position");
            output.Enqueue(stack.Pop());
        }

        return output;
    }

    public static string CalculateOperator(string arithmeticOperator, params double[] value)
    {
        StringBuilder result = new StringBuilder();

        // the order of value[0] and value[1] must be changed.That's how they were popped off the stack, but they have to be
        // executed in reversed order to follow the initial expression's flow

        if (arithmeticOperator == "+")
        {
            result.Append(value[1] + value[0]);
        }
        else if (arithmeticOperator == "-")
        {
            result.Append(value[1] - value[0]);
        }
        else if (arithmeticOperator == "*")
        {
            result.Append(value[1] * value[0]);
        }
        else if (arithmeticOperator == "/")
        {
            result.Append(value[1] / value[0]);
        }
        else if (arithmeticOperator == "pow")
        {
            result.Append(Math.Pow(value[1], value[0]));
        }
        else if (arithmeticOperator == "ln")
        {
            result.Append(Math.Log(value[0]));
        }
        else if (arithmeticOperator == "sqrt")
        {
            result.Append(Math.Sqrt(value[0]));
        }

        return result.ToString();
    }

    public static double CalculateRPN(Queue<string> RPN)    // Reverse Polish Notation Algorithm from wikipedia
    {
        var stack = new Stack<string>();    // required by the algorithm

        while (RPN.Count > 0)
        {
            string currentToken = RPN.Dequeue();

            double parsedValue;
            if (double.TryParse(currentToken, out parsedValue))
            {
                stack.Push(currentToken);   // or stack.Push(parsedValue.ToString());
            }
            else
            {
                if (currentToken == "+" && stack.Count >= 2)
                    stack.Push(CalculateOperator(currentToken, double.Parse(stack.Pop()), double.Parse(stack.Pop())));
                else if (currentToken == "-" && stack.Count >= 2)
                    stack.Push(CalculateOperator(currentToken, double.Parse(stack.Pop()), double.Parse(stack.Pop())));
                else if (currentToken == "*" && stack.Count >= 2)
                    stack.Push(CalculateOperator(currentToken, double.Parse(stack.Pop()), double.Parse(stack.Pop())));
                else if (currentToken == "/" && stack.Count >= 2)
                    stack.Push(CalculateOperator(currentToken, double.Parse(stack.Pop()), double.Parse(stack.Pop())));
                else if (currentToken == "pow" && stack.Count >= 2)
                    stack.Push(CalculateOperator(currentToken, double.Parse(stack.Pop()), double.Parse(stack.Pop())));
                else if (currentToken == "ln" && stack.Count >= 1)
                    stack.Push(CalculateOperator(currentToken, double.Parse(stack.Pop())));
                else if (currentToken == "sqrt" && stack.Count >= 1)
                    stack.Push(CalculateOperator(currentToken, double.Parse(stack.Pop())));
                else
                    throw new ArgumentException("Insufficient values available!");
            }
        }

        if (stack.Count == 1)
        {
            return double.Parse(stack.Pop());
        }
        else
        {
            throw new ArgumentException("The input has too many values.");
        }
    }
}