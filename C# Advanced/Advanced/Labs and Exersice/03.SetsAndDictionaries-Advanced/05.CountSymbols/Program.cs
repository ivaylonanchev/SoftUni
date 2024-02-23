using System;
using System.Collections.Generic;

namespace _05.CountSymbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            var dic = new SortedDictionary<char, int>();
            foreach (char c in word)
            {
                if (!dic.ContainsKey(c))
                {
                    dic.Add(c, 0);
                }
                dic[c]++;
            }
            foreach (var c in dic)
            {
                Console.WriteLine($"{c.Key}: {c.Value} time/s");
            }
        }
    }
}
