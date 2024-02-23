using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Channels;

namespace _04.FindEvenOrOdds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            int start = input[0];
            int end = input[1];

            List<int> list = new List<int>();

            for (int i = start; i <= end; i++)
            {
                list.Add(i);
            }

            string command = Console.ReadLine();
            Predicate<int> predicvate = EvenOdOdd(command);

            var finalNums = list
                .Where(new Func<int, bool>(predicvate))
                .ToArray();

            Console.WriteLine(string.Join(" ", finalNums));
        }
        public static Predicate<int> EvenOdOdd(string command)
        {
            if (command == "odd") return c => c % 2 != 0;
            else if (command == "even") return c => c % 2 == 0;
            else return null;

        }
    }
}
