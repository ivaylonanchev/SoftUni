using System;
using System.Linq;

namespace _07._PredicateForNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lenght = int.Parse(Console.ReadLine());
            var names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Predicate<string> predicate = c => c.Length <= lenght;
            Action<string[]> print = c => Console.WriteLine(string.Join(Environment.NewLine, c));

            names = names.Where(x => predicate(x)).ToArray();
            print(names);
        }
    }
}
