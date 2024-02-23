using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SetsOfElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();
            var set1 = new HashSet<int>(arr[0]);
            var finalSet = new HashSet<int>();
            for (int i = 0; i < arr[0]; i++)
            {
                int a = int.Parse(Console.ReadLine());
                set1.Add(a);
            }

            var set2 = new HashSet<int>(arr[1]);

            for (int i = 0; i < arr[1]; i++)
            {
                int a = int.Parse(Console.ReadLine());
                set2.Add(a);
            }
            foreach (var number1 in set1)
            {
                foreach (var number2 in set2)
                {
                    if (number1 == number2)
                    {
                        finalSet.Add(number1);
                    }
                }
            }
            Console.WriteLine(string.Join(" ", finalSet));

        }
    }
}
