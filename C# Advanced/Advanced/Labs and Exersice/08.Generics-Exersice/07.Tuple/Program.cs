using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.Tuple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var arr1 = Console.ReadLine()
                .Split(" ")
                .ToArray();
            Tuple<string, string> tuple1 = new Tuple<string, string>(arr1[0] + " " + arr1[1], arr1[2]);
            Console.WriteLine(tuple1);

            var arr2 = Console.ReadLine()
                .Split(" ")
                .ToArray();
            Tuple<string, int> tuple2 = new Tuple<string, int>(arr2[0], int.Parse(arr2[1]));
            Console.WriteLine(tuple2);

            var arr3 = Console.ReadLine()
                .Split(" ")
                .ToArray();
            Tuple<int, double> tuple3 = new Tuple<int, double>(int.Parse(arr3[0]), double.Parse(arr3[1]));
            Console.WriteLine(tuple3);
        }
    }
}
