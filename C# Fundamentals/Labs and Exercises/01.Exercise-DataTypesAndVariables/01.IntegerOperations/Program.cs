﻿namespace _1.IntegerOperations
{
    internal class Program
    {
        static void Main()
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());
            int num4 = int.Parse(Console.ReadLine());
            num1 += num2;
            num1 /= num3;
            num1 *= num4;
            Console.WriteLine(num1);
        }
    }
}