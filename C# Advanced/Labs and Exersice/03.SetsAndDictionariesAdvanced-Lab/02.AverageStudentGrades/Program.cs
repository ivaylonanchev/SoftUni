using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.AverageStudentGrades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            var dic = new Dictionary<string, List<decimal>>();
            for (int i = 0; i < rows; i++)
            {
                var arr = Console.ReadLine()
                    .Split(" ")
                    .ToArray();
                string key = arr[0];
                decimal grade = decimal.Parse(arr[1]);
                if (!dic.ContainsKey(key))
                {
                    dic.Add(key, new List<decimal>());
                }
                dic[key].Add(grade);

            }
            foreach (var d in dic)
            {
                Console.Write($"{d.Key} -> ");
                foreach (var item in d.Value)
                {
                    Console.Write($"{item:f2} ");
                }
                Console.WriteLine($"(avg: {d.Value.Average():f2})");
            }
        }
    }
}
