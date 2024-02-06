using System;
using System.Linq;

namespace _11.TriFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            var names = Console.ReadLine()
                .Split(' ')
                .ToList();

            Console.WriteLine(names
                .FirstOrDefault(x => x.ToCharArray()
                    .Select(y => (int)y)
                    .Sum() >= number));
        }
    }
}
