using System;
using System.Collections.Generic;

namespace Algorithm.DataStructure.Stack
{
    // https://www.geeksforgeeks.org/stack-set-2-infix-to-postfix/
    public class InfixToPostfix
    {
        public void Solution(string[] expressions)
        {
            foreach(var expression in expressions)
            {
                Console.WriteLine(expression);
                var result = Convert(expression);
                Console.WriteLine(result);
                Console.WriteLine();
            }
        }

        public void Test()
        {
            string[] expressions = new string[] 
            {
                "1+2",
                "3+4*5+6",
                "(1+2)*(3+4)",
                "(1-2/3)*(4/5-6)"
            };

            Solution(expressions);
        }

        private int OperatorPriorty(char ch)
        {
            switch (ch)
            {
                case '+':
                case '-':
                    return 1;

                case '*':
                case '/':
                    return 2;

                case '^':
                    return 3;
            }

            return -1;
        }

        public string Convert(string expression)
        {
            string result = "";
            Stack<char> stack = new Stack<char>();

            foreach(var ch in expression)
            {
                // If the scanned character is an operand, add it to output.
                if (char.IsLetterOrDigit(ch))
                {
                    result += ch;
                }

                // If the scanned character is an '(', push it to the stack.
                else if (ch == '(')
                {
                    stack.Push(ch);
                }

                //  If the scanned character is an ')', pop and output from the stack 
                // until an '(' is encountered.
                else if (ch == ')')
                {
                    while (stack.Count > 0 && stack.Peek() != '(')
                    {
                        result += stack.Pop();
                    }

                    if (stack.Count > 0 && stack.Peek() != '(')
                    {
                        return "Invalid Expression"; // invalid expression                
                    }
                    else
                    {
                        stack.Pop();
                    }
                }
                else // an operator is encountered
                {
                    while (stack.Count > 0 && OperatorPriorty(ch) <= OperatorPriorty(stack.Peek()))
                    {
                        result += stack.Pop();
                    }

                    stack.Push(ch);
                }

            }

            // pop all the operators from the stack
            while (stack.Count > 0)
            {
                result += stack.Pop();
            }

            return result;
        }

        public int Calculate(string expression)
        {
            Stack<int> stack = new Stack<int>();

            foreach(var ch in expression)
            {
                if(char.IsDigit(ch))
                {
                    stack.Push(ch - '0');
                }
                else if(OperatorPriorty(ch) > -1)
                {
                    if(stack.Count > 1)
                    {
                        var op2 = stack.Pop();
                        var op1 = stack.Pop();
                        var val = 0;

                        switch(ch)
                        {
                            case '+':
                                val = op1 + op2;
                                break;

                            case '-':
                                val = op1 - op2;
                                break;

                            case '*':
                                val = op1 * op2;
                                break;

                            case '/':
                                val = op1 / op2;
                                break;

                            case '^':
                                val = op1 ^ op2;
                                break;
                        }

                        stack.Push(val);
                    }
                }
                else
                {
                    return -1;
                }
            }

            return stack.Pop();
        }
    }
}