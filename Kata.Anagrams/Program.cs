using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Anagrams
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(", ", Anagrams("racer", new List<string>() { "carer", "arcre", "arceer" })));
        }

        public static List<string> Anagrams(string word, List<string> words)
        {
            List<string> anagrams = new List<string>();
            var sortedWord = word.OrderBy(x => x);

            foreach (var item in words)
            {
                var sortedItem = item.OrderBy(x => x);

                if (Enumerable.SequenceEqual(sortedWord, sortedItem))
                    anagrams.Add(item);
            }

            return anagrams;
        }
    }
}
