using System;
using System.Diagnostics;

namespace Kata.IsANumberPrime
{
    class Program
    {
        static void Main(string[] args)
        {
            var gen = new Random();
            var stopwatch = new Stopwatch();
            int number = gen.Next();

            stopwatch.Start();
            bool isPrime = IsPrime(number);
            stopwatch.Stop();

            Console.WriteLine($"Number: {number}\n" +
                $"Is Prime: {isPrime}\n" +
                $"Time: {stopwatch.ElapsedMilliseconds}ms");
        }

        public static bool IsPrime(int number)
        {
            if (number < 2)
                return false;

            if (number == 2)
                return true;

            var dividor = Math.Sqrt(number) + 1;
            for (int i = 2; i < dividor; i++)
            {
                if (number % i == 0)
                    return false;
            }

            return true;
        }
    }
}