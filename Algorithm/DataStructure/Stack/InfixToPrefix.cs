using System;
using System.Collections.Generic;

namespace Algorithm.DataStructure.Stack
{
    // https://www.youtube.com/watch?v=ZCZj4fDbyi8
    public class InfixToPrefix
    {
        public void Solution(string[] expressions)
        {
            foreach (var expression in expressions)
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

        public string Convert(string expression)
        {
            string result = "";
            Stack<string> stack = new Stack<string>();

            for (int i = expression.Length - 1; i >= 0; i--)
            {
                var ch = expression[i];

                if (char.IsDigit(ch))
                {
                    result += ch.ToString();
                }
                else
                {
                    if(ch == ')')
                    {
                        stack.Push("(");
                    }
                    else if(ch == '(')
                    {
                        while(stack.Peek() != "(")
                        {
                            var op = stack.Pop();

                            result += op;
                        }

                        if(stack.Count > 0 && stack.Peek() == "(")
                        {
                            stack.Pop();
                        }
                        else
                        {
                            return "error";
                        }
                    }
                    else
                    {
                        if(stack.Count > 0 && OperatorPriorty(stack.Peek()) > OperatorPriorty(ch.ToString()))
                        {
                            var op = stack.Pop();

                            result += op;
                        }

                        stack.Push(ch.ToString());
                    }
                }
            }

            while(stack.Count > 0)
            {
                result += stack.Pop();
            }

            return ReverseString(result);
        }

        public int Calculate(string expression)
        {
            Stack<string> stack = new Stack<string>();

            foreach (var ch in expression)
            {
                if (OperatorPriorty(ch.ToString()) > -1)
                {
                    stack.Push(ch + "");
                }
                else if (char.IsDigit(ch))
                {
                    var op2 = ch - '0';

                    while (stack.Count > 0 && char.IsDigit(stack.Peek()[0]))
                    {
                        var op1 = int.Parse(stack.Pop());
                        var oper = stack.Pop();
                        var val = Calculate(oper, op1, op2);

                        op2 = val;
                    }

                    stack.Push(op2 + "");
                }
                else
                {
                    return -1;
                }
            }

            return int.Parse(stack.Pop());
        }

        private int Calculate(string oper, int op1, int op2)
        {
            int val = 0;

            switch (oper)
            {
                case "+":
                    val = op1 + op2;
                    break;

                case "-":
                    val = op1 - op2;
                    break;

                case "*":
                    val = op1 * op2;
                    break;

                case "/":
                    val = op1 / op2;
                    break;

                case "^":
                    val = op1 ^ op2;
                    break;
            }

            return val;
        }

        private int OperatorPriorty(string ch)
        {
            switch (ch)
            {
                case "+":
                case "-":
                    return 1;

                case "*":
                case "/":
                    return 2;

                case "^":
                    return 3;
            }

            return -1;
        }

        private string ReverseString(string str)
        {
            int si = 0;
            int ei = str.Length - 1;
            var arr = str.ToCharArray();

            while(si < ei)
            {
                arr[si] ^= arr[ei];
                arr[ei] ^= arr[si];
                arr[si] ^= arr[ei];

                si++;
                ei--;
            }

            return new string(arr);
        }
    }
}