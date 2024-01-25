using System;
using System.Data;

namespace _07.KnightsGame
{/*
5
0K0K0
K000K
00K00
K000K
0K0K0
  */
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var matrix = new char[n, n];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var arr = Console.ReadLine()
                    .ToCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = arr[col];
                }
            }

            int removedKnights = 0;
            while (true)
            {
                int maxAttacker = 0;
                int rowToRemove = 0;
                int colToRemove = 0;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col] == 'K')
                        {
                            int currentAttacks = Attacks(matrix, row, col);
                            if (currentAttacks > maxAttacker)
                            {
                                maxAttacker = currentAttacks;
                                rowToRemove = row;
                                colToRemove = col;
                            }
                        }
                    }
                }
                if( maxAttacker > 0)
                {
                    matrix[rowToRemove, colToRemove] = '0';
                    removedKnights++;
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine(removedKnights);
        }
        private static bool isValid(int row, int col, char[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0)
                && col >= 0 && col < matrix.GetLength(1)
                && matrix[row, col] == 'K';
        }
        private static int Attacks(char[,] matrix, int row, int col)
        {
            int attacks = 0;
            if (isValid(row - 2, col + 1, matrix))
            {
                attacks++;
            }
            if (isValid(row - 2, col - 1, matrix))
            {
                attacks++;
            }
            if (isValid(row - 1, col - 2, matrix))
            {
                attacks++;
            }
            if (isValid(row + 1, col - 2, matrix))
            {
                attacks++;
            }
            if (isValid(row + 2, col - 1, matrix))
            {
                attacks++;
            }
            if (isValid(row + 2, col + 1, matrix))
            {
                attacks++;
            }
            if (isValid(row - 1, col + 2, matrix))
            {
                attacks++;
            }
            if (isValid(row + 1, col + 2, matrix))
            {
                attacks++;
            }
            return attacks;
        }
    }
}
