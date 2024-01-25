using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.PeriodicTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var set = new SortedSet<string>();
            for (int i = 0; i < n; i++)
            {
                var arr = Console.ReadLine()
                    .Split(" ")
                    .ToArray();
                for (int j = 0; j < arr.Length; j++)
                {
                    set.Add(arr[j]);
                }
            }
            Console.WriteLine(string.Join(" ", set));
        }
    }
}
