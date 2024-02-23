using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;

namespace _06.JaggedArrayManipulation
{
/*
5
10 20 30
1 2 3
2
2
10 10
Add 0 10 10
Add 0 0 10
Subtract -3 0 10
Subtract 3 0 10
End
 */
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] matrix = new int[rows][];
            for (int row = 0; row < rows; row++)
            {
                var arr = Console.ReadLine()
                    .Split(" ")
                    .Select(int.Parse)
                    .ToArray();
                matrix[row] = new int[arr.Length];
                for (int col = 0; col < arr.Length; col++)
                {
                    matrix[row][col] = arr[col];
                }
            }

            for (int row = 0; row < rows; row++)
            {
                if (row + 1 < rows)
                {
                    if (matrix[row].Length == matrix[row + 1].Length)
                    {
                        for (int col = 0; col < matrix[row].Length; col++)
                        {
                            matrix[row][col] *= 2;
                        }
                        for (int col = 0; col < matrix[row + 1].Length; col++)
                        {
                            matrix[row+1][col] *= 2;
                        }
                    }
                    else
                    {
                        for (int col = 0; col < matrix[row].Length; col++)
                        {
                            matrix[row][col] /= 2;
                        }
                        for (int col = 0; col < matrix[row + 1].Length; col++)
                        {
                            matrix[row+1][col] /= 2;
                        }
                    }
                }
            }

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                var arr = input.Split(" ").ToArray();
                string command = arr[0];

                int row = int.Parse(arr[1]);
                int col = int.Parse(arr[2]);
                int value = int.Parse(arr[3]);

                if (command == "Add")
                {

                    try
                    {
                        matrix[row][col] += value;
                    }
                    catch (IndexOutOfRangeException ex)
                    {

                    }
                }
                else if (command == "Subtract")
                {
                    try
                    {
                        matrix[row][col] -= value;
                    }
                    catch (IndexOutOfRangeException ex)
                    {

                    }
                }
            }
            PrintArray(matrix);

        }
        static void PrintArray(int[][] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col]+" ");
                }
                Console.WriteLine();
            }
        }
    }
}
