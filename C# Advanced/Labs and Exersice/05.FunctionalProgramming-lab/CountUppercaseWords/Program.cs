using System;
using System.Linq;
using System.Transactions;

namespace CountUppercaseWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            Predicate<string> pre = c => char.IsUpper(c[0]);
            text = text.Where(c=>pre(c)).ToArray();
            Console.WriteLine(string.Join(Environment.NewLine, text));
        }
    }
}
