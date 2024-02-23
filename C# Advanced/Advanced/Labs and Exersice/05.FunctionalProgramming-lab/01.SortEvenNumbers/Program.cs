using System;
using System.Linq;

namespace _01.SortEvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var item = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .Where(x=>x%2==0)
                .OrderBy(x=>x)
                .ToArray();
            Console.WriteLine(string.Join(", ", item));
        }
    }
}
