using System;
using System.Linq;

namespace _03.Largest3Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();
            int[] sorted = numbers.OrderByDescending(c => c).ToArray();
            int nums = 0;
            while (sorted.Length > 0)
            {
                if (nums == sorted.Length || nums == 3)
                {
                    break;
                }
                Console.Write(sorted[nums]+ " ");
                nums++;
            }
        }
    }
}
