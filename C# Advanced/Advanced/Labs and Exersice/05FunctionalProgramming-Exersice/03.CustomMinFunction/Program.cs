using System;
using System.Linq;
using System.Net.Mail;

namespace _03.CustomMinFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();
            Func<int[], int> minValue = (int[] c) =>
            {
                int smallest = c[0];
                for (int i = 0; i < c.Length; i++)
                {
                    if (smallest > c[i])
                    {
                        smallest = c[i];
                    }
                }
                return smallest;
            };
            int smallest = minValue(nums);
            Console.WriteLine(smallest);
        }
    }
}
