using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace _08.ListOfPredicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int max = int.Parse(Console.ReadLine());
            var devide = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            var numbers = new List<int>();
            for (int i = 1; i <= max; i++)
            {
                numbers.Add(i);
            }

            Func<int[], int, bool> predicate = (a, i) =>
            {
                bool isDevideble = true;
                foreach (var n in a)
                {
                    if (i % n != 0)
                    {
                        return false;
                    }
                }

                return isDevideble;
            };
            var result = numbers
                .Where(x => predicate(devide, x));
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
