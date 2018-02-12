using System;
using System.Collections.Generic;

namespace Algorithm.DataStructure.Stack
{
    // https://www.youtube.com/watch?v=DjH-vmOo08Y
    public class PostfixToPrefix
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
                "12+",
                "345*+6+",
                "12+34+*",
                "123/-45/6-*"
            };

            Solution(expressions);
        }

        public string Convert(string expression)
        {
            Stack<string> stack = new Stack<string>();

            foreach (var ch in expression)
            {
                if (char.IsDigit(ch))
                {
                    stack.Push(ch.ToString());
                }
                else
                {
                    var operand2 = stack.Pop();
                    var operand1 = stack.Pop();
                    var exp = ch.ToString() + operand1 + operand2;

                    stack.Push(exp);
                }
            }

            return stack.Pop();
        }
    }
}