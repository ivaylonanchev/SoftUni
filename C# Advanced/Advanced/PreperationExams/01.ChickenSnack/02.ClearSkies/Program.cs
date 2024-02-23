using System;

namespace _02.ClearSkies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int r = 0;
            int c = 0;

            int ECount = 0;
            for (int row = 0; row < n; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col];
                    if (matrix[row, col] == 'E')
                    {
                        ECount++;
                    }
                    if (matrix[row, col] == 'J')
                    {
                        r = row;
                        c = col;
                    }
                }
            }

            int armour = 300;
            while (armour > 0)
            {
                string command = Console.ReadLine();
                Movement(command, matrix, ref r, ref c, n);

                if (matrix[r, c] == 'E')
                {
                    matrix[r, c] = 'J';
                    ECount--;
                    if (ECount == 0)
                    {
                        Console.WriteLine("Mission accomplished, you neutralized the aerial threat!");
                        PrintMatrix(matrix, n);
                        break;
                    }
                    else
                    {
                        armour -= 100;
                        if (armour == 0)
                        {
                            Console.WriteLine($"Mission failed, your jetfighter was shot down! Last coordinates [{r}, {c}]!");
                            PrintMatrix(matrix, n);
                            break;
                        }
                    }

                }
                else if (matrix[r, c] == 'R')
                {
                    matrix[r, c] = 'J';
                    armour = 300;
                }
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
