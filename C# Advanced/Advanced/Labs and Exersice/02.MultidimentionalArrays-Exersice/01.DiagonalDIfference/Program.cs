using System;
using System.Linq;

namespace _01.DiagonalDIfference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var matrix = new double[n,n];
            double leftSum = 0;
            double rightSum = 0;
            for (int row = 0; row < n; row++)
            {
                var arr = Console.ReadLine()
                    .Split(" ")
                    .Select(double.Parse)
                    .ToArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = arr[col];
                }
                leftSum += matrix[row, row];
            }
            int num = 0;
            for (int row = n-1;row >= 0; row--)
            {
                rightSum += matrix[row, num];
                num++;
            }
            double difference = leftSum - rightSum;
            Console.WriteLine(Math.Abs(difference));
        }
    }
}
