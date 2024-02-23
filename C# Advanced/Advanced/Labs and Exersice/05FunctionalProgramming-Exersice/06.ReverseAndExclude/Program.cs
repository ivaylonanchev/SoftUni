using System;
using System.Linq;

namespace _06.ReverseAndExclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();
            int devide = int.Parse(Console.ReadLine());

            Predicate<int> func = c => c % devide != 0;
            nums = nums
                .Where(new Func<int, bool>(func))
                .Reverse()
                .ToArray();
            Console.WriteLine(string.Join(" ", nums));

        }
    }
}
