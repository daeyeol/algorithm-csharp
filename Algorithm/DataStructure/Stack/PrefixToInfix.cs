using System;
using System.Collections.Generic;

namespace Algorithm.DataStructure.Stack
{
    // https://www.youtube.com/watch?v=KrWZ66Rp7GA
    public class PrefixToInfix
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
                "+1*23",
                "//925",
                "+*776",
                "+3+*456",
                "*+12+34",
                "*-1/23-/456"
            };

            Solution(expressions);
        }

        public string Convert(string expression)
        {
            Stack<string> stack = new Stack<string>();

            for (int i = expression.Length - 1; i >= 0; i--)
            {
                var ch = expression[i];

                if (char.IsDigit(ch))
                {
                    stack.Push(ch.ToString());
                }
                else
                {
                    var operand1 = stack.Pop();
                    var operand2 = stack.Pop();
                    var exp = operand1 + ch.ToString() + operand2;

                    stack.Push(exp);
                }
            }

            return stack.Pop();
        }
    }
}