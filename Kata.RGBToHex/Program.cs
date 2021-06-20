using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.RGBToHex
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Rgb(148, 0, 211));
            Console.WriteLine(Rgb(148, -20, 211));
            Console.WriteLine(Rgb(212, 53, 12));
        }

        public static string Rgb(int r, int g, int b)
        {
            var hex = new StringBuilder();
            hex.Append(ConvertToHex(r));
            hex.Append(ConvertToHex(g));
            hex.Append(ConvertToHex(b));

            return hex.ToString();
        }

        public static string ConvertToHex(int number)
        {
            Dictionary<int, string> hexTable = new Dictionary<int, string>()
            {
                { 0, "0" },
                { 1, "1" },
                { 2, "2" },
                { 3, "3" },
                { 4, "4" },
                { 5, "5" },
                { 6, "6" },
                { 7, "7" },
                { 8, "8" },
                { 9, "9" },
                { 10, "A" },
                { 11, "B" },
                { 12, "C" },
                { 13, "D" },
                { 14, "E" },
                { 15, "F" }
            };

            // handle numbers less then 0
            if (number < 0)
                number = 0;

            // handle numbers greater then 255
            if (number > 255)
                number = 255;

            // default if number is 0
            if (number == 0)
                return "00";

            double part1 = number / 16;
            double part2 = (number / 16d % 1) * 16;
            return $"{hexTable[(int)part1]}{hexTable[(int)part2]}";
        }
    }
}
