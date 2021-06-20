using System;
using System.Collections.Generic;

namespace Kata.GetPeaks
{
    class Program
    {
        static void Main(string[] args)
        {
            var tests = new List<int[]>() 
            {
                new int[] { 1, 2, 2, 1, 3, 3, 3, 2, 4, 3 },
                new int[]{1,2,3,6,4,1,2,3,2,1},
                new int[]{3,2,3,6,4,1,2,3,2,1,2,3},
                new int[]{3,2,3,6,4,1,2,3,2,1,2,2,2,1},
                new int[]{2,1,3,1,2,2,2,2,1},
                new int[]{2,1,3,1,2,2,2,2},
                new int[]{ 5, 4, 10, -4, 6, 18, 0, 13, 9, 0, 3, 2, 16, 16, 18, 16 }
            };

            foreach (var test in tests)
            {
                var ans = GetPeaks(test);
                Console.WriteLine(
                    $"Test: [{Print(test)}]\n" +
                    $"Results: Positions [{Print(ans["pos"].ToArray())}]\n" +
                    $"Results: Peaks [{Print(ans["peaks"].ToArray())}]\n"
                );
            }
        }

        internal static string Print<T>(T[] items)
        {
            return string.Join(", ", items);
        }

        public static Dictionary<string, List<int>> GetPeaks(int[] arr)
        {
            var results = new Dictionary<string, List<int>>()
            {
                { "pos", new List<int>() },
                { "peaks", new List<int>() }
            };
            
            // verify our list contains at least 3 items
            if (arr.Length <= 2)
                return results;

            for (int i = 1; i < arr.Length; i++)
            {
                // flags
                bool stop = false;
                
                // positions
                var currentIndex = i;
                var previousIndex = i - 1;
                var nextIndex = i + 1;

                // check if we are on the final check
                if (nextIndex >= arr.Length)
                    stop = true;

                if (!stop)
                {
                    // values
                    var currentValue = arr[currentIndex];
                    var previousValue = arr[previousIndex];
                    var nextValue = arr[nextIndex];

                    // check if we are greater then the previous number
                    if (currentValue > previousValue)
                    {
                        while (currentValue == nextValue)
                        {
                            nextIndex++;

                            if (nextIndex > arr.Length - 1)
                                return results;

                            nextValue = arr[nextIndex];
                        }

                        if (currentValue > nextValue)
                        {
                            results["pos"].Add(currentIndex);
                            results["peaks"].Add(currentValue);
                            continue;
                        }
                    }
                }
            }

            return results;
        }
    }
}
