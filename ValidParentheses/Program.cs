using System;
using System.Collections.Generic;

namespace Kata.ValidParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
                                                    // true,        false, false, false,    true,         true
            List<string> test = new List<string>() { "(c(b(a)))(d)", "(", ")", "hi(hi))(", "((())()())", "hi(hi)", "" };
            test.ForEach(a => Console.WriteLine(ValidParentheses(a)));
        }

        public static bool ValidParentheses(string input)
        {
            Console.WriteLine($"Input: {input}");
            Dictionary<int, int> keys = new Dictionary<int, int>();

            // shouldnt no '()' at all be false? why is this required to pass.....
            if (string.IsNullOrWhiteSpace(input))
                return true;

            // verify the string contains at least 1 parantheses
            if (!input.Contains('(') || input.Length <= 1)
                return false;

            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                if (c == '(')
                {
                    keys.Add(i, -1);
                    for (int j = i + 1; j < input.Length; j++)
                    {
                        if (input[j] == ')')
                        {
                            if (!keys.ContainsValue(j))
                            {
                                keys[i] = j;
                                break;
                            }
                        }
                    }
                }
                else if (c == ')' && !keys.ContainsValue(i))
                    return false;
            }

            if (keys.ContainsValue(-1))
                return false;

            return true;
        }
    }
}
