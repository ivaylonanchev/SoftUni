using System;
using System.Linq;

namespace _03_MaximalSum
{/* 
4 5
1 5 5 2 4
2 1 4 14 3
3 7 11 2 8
4 8 12 16 4
  */
    internal class Program
    {
        static void Main(string[] args)
        {
            var dimentions = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();

            int rows = dimentions[0];
            int cols = dimentions[1];

            var matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var arr = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = arr[col];
                }
            }
            int sum = int.MinValue;
            int indexRow = int.MinValue;
            int indexCol = int.MinValue;

            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {

                    int currentSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2]
                        + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2]
                        + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                    if (currentSum > sum)
                    {
                        sum = currentSum;
                        indexRow = row;
                        indexCol = col;

                    }
                }

            }
            Console.WriteLine("Sum = " + sum);
            Console.WriteLine($"{matrix[indexRow, indexCol]} {matrix[indexRow, indexCol + 1]} {matrix[indexRow, indexCol + 2]}");
            Console.WriteLine($"{matrix[indexRow + 1, indexCol]} {matrix[indexRow + 1, indexCol + 1]} {matrix[indexRow + 1, indexCol + 2]}");
            Console.WriteLine($"{matrix[indexRow + 2, indexCol]} {matrix[indexRow + 2, indexCol + 1]} {matrix[indexRow + 2, indexCol + 2]}");
        }
    }
}
