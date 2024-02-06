using System;
using System.Linq;

namespace _02.KnightsOfHonor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine()
                .Split(" ")
                .ToArray();
            Action<string> print = c => Console.WriteLine("Sir " + c);
            Array.ForEach(names, print);
        }
    }
}
