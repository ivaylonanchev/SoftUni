using System;
using System.Collections.Generic;
using System.IO;

namespace _06.UniqueNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var set = new HashSet<string>();
            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                if (!set.Contains(name))
                {
                    set.Add(name);
                }
            }
            foreach (string name in set)
            {
                Console.WriteLine(name);
            }
        }
    }
}
