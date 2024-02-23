using System;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Transactions;

namespace _05.SnakeMoves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dimentions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string snake = Console.ReadLine();
            var sb = new StringBuilder();

            for (int i = snake.Length-1; i >=0; i--)
            {
                sb.Append(snake[i]);
            }

            string reverseSnake = sb.ToString();

            var matrix = new string[dimentions[0], dimentions[1]];

            int indexSnake = 0;
            int indexReverse = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if(row%2== 0)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        matrix[row, col] = snake[indexSnake].ToString();
                        indexSnake++;
                        if (indexSnake >= snake.Length)//-1
                        {
                            indexSnake = 0; 
                        }
                    }
                }
                else
                {
                    for (int col = matrix.GetLength(1)-1; col >= 0; col--)
                    {
                        matrix[row, col] = snake[indexSnake].ToString();
                        indexSnake++;
                        if (indexSnake >= snake.Length)//-1
                        {
                            indexSnake = 0;
                        }
                    }
                }
            }
            PrintMatrix(matrix);
        }
        private static void PrintMatrix(string[,] matirx)
        {
            for (int row = 0; row < matirx.GetLength(0); row++)
            {
                for (int col = 0; col < matirx.GetLength(1); col++)
                {
                    Console.Write(matirx[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
