using System;
using System.Collections.Generic;

namespace _05.GenericCountMethodStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var list = new List<string>();
            for (int i = 0; i < n; i++)
            {
                list.Add(Console.ReadLine());
            }

            string toCompare = Console.ReadLine();
            Console.WriteLine(Count<string>(list,toCompare));

        }
        static int Count<T>(List<T> list, T toCompare) where T :IComparable
        {
            int count = 0;
            foreach(var item in list)
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
