using System;
using System.Linq;
using System.Security.Claims;

namespace _02.SquaresInMatrix
{
    /*
3 4
A B B D
E B B B
I J B B
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            var dimetions = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();
            int rows = dimetions[0];
            int cols = dimetions[1];

            var matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var arr = Console.ReadLine()
                    .Split(" ")
                    .ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = arr[col];
                }
            }
            int count = 0;
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    string current = matrix[row, col];
                    if (row < rows - 1 && col < cols - 1)
                    {
                        if (current == matrix[row, col + 1]
                            && current == matrix[row + 1, col]
                            && current == matrix[row + 1, col + 1])
                        {
                            count++;
                        }
                    }
                }
            }
            Console.WriteLine(count);
        }
    }
}
