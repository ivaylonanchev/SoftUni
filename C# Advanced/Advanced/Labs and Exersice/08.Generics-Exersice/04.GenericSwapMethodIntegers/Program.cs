using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.GenericSwapMethodIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var list = new List<int>();
            for (int i = 0; i < n; i++)
            {
                list.Add(int.Parse(Console.ReadLine()));
            }
            var indexes = Console.ReadLine().Split(' ').ToArray();
            int firstIndex = int.Parse(indexes[0]);
            int secondIndex = int.Parse(indexes[1]);

            Swap<int>(list, firstIndex, secondIndex);
            Console.WriteLine(ToString<int>(list));
        }
        static void Swap<T>(List<T> list, int first, int second)
        {
            T current = list[first];
            list[first] = list[second];
            list[second] = current;
        }
        static string ToString<T>(List<T> list)
        {
            var sb = new StringBuilder();
            foreach (var item in list)
            {
                sb.AppendLine(typeof(T) + ": " + item.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
