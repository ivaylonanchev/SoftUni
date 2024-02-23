using System;
using System.Data;
using System.Runtime.InteropServices;
using System.Security.Principal;

namespace _02.FishingCompetition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            int r = 0;
            int c = 0;
            int catched = 0;
            for (int row = 0; row < size; row++)
            {
                string line = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = line[col];
                    if (matrix[row, col] == 'S')
                    {
                        r = row;
                        c = col;
                    }
                }
            }

            string com;
            while ((com = Console.ReadLine()) != "collect the nets")
            {
                Movement(com, matrix, ref r, ref c, size);

                if (matrix[r, c] == 'W')
                {
                    catched = 0;
                    Console.WriteLine($"You fell into a whirlpool! The ship sank and you lost the fish you caught. Last coordinates of the ship: [{r},{c}]");
                    return;
                }
                else if (char.IsDigit(matrix[r, c]))
                {
                    catched += int.Parse(matrix[r, c].ToString());
                    matrix[r, c] = 'S';
                }
                else
                {
                    matrix[r, c] = 'S';
                }
            }

            if (catched < 20)
            {
                Console.WriteLine($"You didn't catch enough fish and didn't reach the quota! You need {20 - catched} tons of fish more.");
                if (catched > 0)
                {
                    Console.WriteLine($"Amount of fish caught: {catched} tons.");
                }
                PrintMatrix(matrix, size);

            }
            else
            {
                Console.WriteLine("Success! You managed to reach the quota!");
                Console.WriteLine($"Amount of fish caught: {catched} tons.");
                PrintMatrix(matrix, size);
            }
        }
        public static void Movement(string command, char[,] matrix, ref int row, ref int col, int size)
        {
            matrix[row, col] = '-';
            switch (command)
            {
                case "left":
                    if (col - 1 < 0)
                    {
                        col = size - 1;

                    }
                    else
                    {
                        col--;
                    }
                    break;
                case "right":
                    if (col + 1 >= size)
                    {
                        col = 0;
                    }
                    else
                    {
                        col++;
                    }
                    break;
                case "up":
                    if (row - 1 < 0)
                    {
                        row = size - 1;
                    }
                    else
                    {
                        row--;
                    }
                    break;
                case "down":
                    if (row + 1 >= size)
                    {
                        row = 0;
                    }
                    else
                    {
                        row++;
                    }
                    break;

            }
        }
        static void PrintMatrix(char[,] matrix, int size)
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
