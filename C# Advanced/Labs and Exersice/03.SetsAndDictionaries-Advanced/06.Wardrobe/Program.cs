using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace _06.Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var dic = new Dictionary<string, Dictionary<string, int>>();
            for (int i = 0; i < n; i++)
            {
                var arr = Console.ReadLine()
                    .Split(" -> ")
                    .ToArray();
                string color = arr[0];
                if (!dic.ContainsKey(color))
                {
                    dic.Add(color,new Dictionary<string, int>());
                }

                var clothes = arr[1].Split(",").ToArray();

                for (int j = 0; j < clothes.Length; j++)
                {
                    if (!dic[color].ContainsKey(clothes[j]))
                    {
                        dic[color].Add(clothes[j], 0);
                    }
                    dic[color][clothes[j]]++;
                }
            }

            var array = Console.ReadLine().Split(" ").ToArray();
            string col = array[0];
            string clothe = array[1];

            
            foreach(var d in dic)
            {
                Console.WriteLine($"{d.Key} clothes:");
                foreach(var k in d.Value)
                {
                    if (d.Key == col && k.Key == clothe)
                    {
                        Console.WriteLine($"* {k.Key} - {k.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {k.Key} - {k.Value}");
                    }
                }
            }
        }
    }
}
