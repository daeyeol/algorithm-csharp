using Algorithm.DataStructure.Stack;
using System;

namespace Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] expressions = new string[]
            {
                "1+2",
                "3+4*5+6",
                "(1+2)*(3+4)",
                "(1-2/3)*(4/5-6)"
            };

            InfixToPostfix infixToPostfix = new InfixToPostfix();
            InfixToPrefix infixToPrefix = new InfixToPrefix();
            PrefixToPostfix prefixToPostfix = new PrefixToPostfix();
            PostfixToPrefix postfixToPrefix = new PostfixToPrefix();
            PrefixToInfix prefixToInfix = new PrefixToInfix();
            PostfixToInfix postfixToInfix = new PostfixToInfix();

            foreach(var expression in expressions)
            {
                Console.WriteLine(expression);

                var prefix = infixToPrefix.Convert(expression);
                var postfix = infixToPostfix.Convert(expression);

                Console.WriteLine(prefixToInfix.Convert(prefix));
                Console.WriteLine(postfixToInfix.Convert(postfix));
                Console.WriteLine(prefix);
                Console.WriteLine(postfixToPrefix.Convert(postfix));
                Console.WriteLine(postfix);
                Console.WriteLine(prefixToPostfix.Convert(prefix));
                Console.WriteLine();
            }         

            Console.ReadKey();
        }
    }
}
