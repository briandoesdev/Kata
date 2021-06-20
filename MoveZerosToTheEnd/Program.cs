using System;
using System.Linq;
using System.Diagnostics;

namespace Kata.MoveZerosToTheEnd
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[] { 1, 2, 3, 0, 5, 4, 6, 0, 7, 8, 9, 0 };

            Stopwatch watch = new Stopwatch();
            watch.Start();
            var res = MoveZeroes(numbers);
            watch.Stop();

            Console.WriteLine($"[{string.Join(", ", numbers)}]\n" +
                $"[{string.Join(", ", res)}]\n" +
                $"Time: {watch.ElapsedMilliseconds}");
        }

        // slower method with more concise code
        public static int[] MoveZeroes(int[] numbers)
        {
            return numbers.OrderBy(n => n == 0).ToArray();
        }

        // faster method that is still fairly easy to understand
        public static int[] MoveZeroes2(int[] arr)
        {
            // This solution makes use of C#'s behaviour with unassigned ints in arrays: They are 0 by default.
            // So we basically only have to create a new array with the same size, and write non-zero values
            // in their usual order. Simple.
            int[] zeroesAtEnd = new int[arr.Length];
            int currIndex = -1;
            foreach (int num in arr)
            {
                if (num != 0)
                {
                    currIndex++;
                    zeroesAtEnd[currIndex] = num;
                }
            }
            return zeroesAtEnd;
        }
    }
}
