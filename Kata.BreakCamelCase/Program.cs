using System;
using System.Text;

namespace Kata.BreakCamelCase
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(BreakCamelCase("thisIsText"));
        }

        public static string BreakCamelCase(string text)
        {
            var splitText = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                char letter = text[i];
                char capitolLetter = text.ToUpper()[i];

                if (letter == capitolLetter)
                    splitText.Append(' ');

                splitText.Append(letter);
            }

            return splitText.ToString();
        }
    }
}
