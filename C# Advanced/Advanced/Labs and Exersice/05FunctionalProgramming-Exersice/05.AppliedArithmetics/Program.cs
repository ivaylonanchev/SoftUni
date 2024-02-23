using System;
using System.ComponentModel.Design;
using System.Linq;

namespace _05.AppliedArithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Action<int[]> print = c => Console.WriteLine(string.Join(' ', c));
            Func<int, int> func = x => x;

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "add")
                {
                    func = x => x + 1;
                }
                else if (command == "multiply")
                {
                    func = x => x * 2;
                }
                else if (command == "subtract")
                {
                    func = x => x - 1;
                }
                else if (command == "print")
                {
                    print(numbers);
                    continue;
                }
                numbers = numbers
                    .Select(x => func(x))
                    .ToArray();
            }
        }

    }
}
