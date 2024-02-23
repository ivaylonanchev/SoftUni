using System;
using System.Linq;

namespace _04.MatrixShuffling
{/* 
2 3
1 2 3
4 5 6
swap 0 0 1 1
swap 10 9 8 7
swap 0 1 1 0
END

1 2
Hello World
0 0 0 1
swap 0 0 0 1
swap 0 1 0 0
END
  */
    internal class Program
    {
        static void Main(string[] args)
        {
            var dimentions = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            var matrix = new string[dimentions[0], dimentions[1]];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var input = Console.ReadLine()
                    .Split(" ")
                    .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            string secondInput;
            while ((secondInput = Console.ReadLine()) != "END")
            {
                var arr = secondInput.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (arr[0] == "swap")
                {
                    if (arr.Length - 1 == 4)
                    {
                        int row1 = int.Parse(arr[1]);
                        int col1 = int.Parse(arr[2]);
                        int row2 = int.Parse(arr[3]);
                        int col2 = int.Parse(arr[4]);

                        if (row1 < matrix.GetLength(0)
                            && col1 < matrix.GetLength(1)
                            && row2 < matrix.GetLength(0)
                            && col2 < matrix.GetLength(1))
                        {
                            string currentNum = matrix[row1, col1];

                            matrix[row1, col1] = matrix[row2, col2];
                            matrix[row2, col2] = currentNum;

                            PrintMatrix(matrix);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }
        private static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }

                Console.WriteLine();
            }
        }
    }
}
