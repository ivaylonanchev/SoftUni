using System;
using System.Collections.Generic;

namespace _06.GenericCountMethodDouble
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var list = new List<double>();
            for (int i = 0; i < n; i++)
            {
                list.Add(double.Parse(Console.ReadLine()));
            }

            double toCompare = double.Parse(Console.ReadLine());
            Console.WriteLine(Count<double>(list, toCompare));

        }
        static int Count<T>(List<T> list, T toCompare) where T : IComparable
        {
            int count = 0;
            foreach (var item in list)
            {
                if (item.CompareTo(toCompare) > 0)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
