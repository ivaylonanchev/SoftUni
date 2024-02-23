using System;
using System.Linq;

namespace _07.CustomComparator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            numbers = numbers.OrderByDescending(x=>x%2==0).ToArray();
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
