using System;
using System.Linq;

namespace _01.ActionPoint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine()
                .Split(" ")
                .ToArray();
            Action<string> print = c => Console.WriteLine(c);
            Array.ForEach(names, print);
        }
    }
}
