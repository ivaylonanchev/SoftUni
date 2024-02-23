using System;
using System.Linq;

namespace _04.AddVAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(c => c * 1.2)
                .ToArray();

            foreach (var n in nums)
            {
                Console.WriteLine($"{n:f2}");
            }
        }
    }
}
