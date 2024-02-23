
using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CountSameValuesInArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(" ").Select(double.Parse).ToArray();
            var dic = new Dictionary<double, int>();
            for (int i = 0; i < numbers.Length; i++)
            {
                if (dic.ContainsKey(numbers[i]))
                {
                    dic[numbers[i]]++;
                }
                else
                {
                    dic.Add(numbers[i], 1);
                }
            }
            foreach(var d in dic)
            {
                Console.WriteLine($"{d.Key} - {d.Value} times");
            }
            
        }
    }
}
