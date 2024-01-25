using System.Numerics;

namespace _05.SquareWithMaxSum
{
    /* 
3, 6
7, 1, 3, 3, 2, 1
1, 3, 9, 8, 5, 6
4, 6, 7, 9, 1, 0
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            var a = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();
            int rows = a[0];
            int cols = a[1];


            var matrix = new int[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                var arr = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = arr[col];
                }
            }

            int indexRow = 0;
            int indexCol = 0;
            int sum = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (row + 1 < rows && col + 1 < cols)
                    {
                        int currentSum = matrix[row, col]
                            + matrix[row, col + 1]
                            + matrix[row + 1, col]
                            + matrix[row + 1, col + 1];
                        if (currentSum > sum)
                        {
                            sum = currentSum;
                            indexRow = row;
                            indexCol = col;
                        }
                    }
                }
            }

            Console.WriteLine($"{matrix[indexRow, indexCol]} {matrix[indexRow, indexCol + 1]}");
            Console.WriteLine($"{matrix[indexRow + 1, indexCol]} {matrix[indexRow + 1, indexCol + 1]}");
            Console.WriteLine(sum);

        }
    }
}