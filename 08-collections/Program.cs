using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static List<string> words = new List<string> { "apple", "apple", "cherry" };

        static void Main(string[] args)
        {
            CountUniques(words);
        }

        static void CountUniques<T>(List<T> list)
        {
            Dictionary<T, int> counts = new Dictionary<T, int>();
            List<T> uniques = new List<T>();

            foreach(T val in list)
            {
                if(counts.ContainsKey(val))
                {
                    counts[val]++;
                } else
                {
                    counts[val] = 1;
                    uniques.Add(val);
                }
            }
            foreach(T val in uniques)
            {
                Console.WriteLine("{0} appears {1} time(s)", val, counts[val]);
            }
        }
    }
}