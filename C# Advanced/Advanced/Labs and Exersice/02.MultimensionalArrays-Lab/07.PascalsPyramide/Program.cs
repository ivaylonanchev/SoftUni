using System.Diagnostics.Tracing;
using System.Numerics;

namespace _07.PascalsPyramide
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int turns = 1;
            var pyramide = new int[n, n];
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < turns; col++)
                {
                    if (turns == 1)
                    {
                        pyramide[row, col] = 1;
                    }
                    else if (turns == 2)
                    {
                        pyramide[row, col] = 1;
                    }
                    else
                    {
                        if (col == 0 || col == turns - 1)
                        {
                            pyramide[row, col] = 1;
                        }
                        else
                        {
                            pyramide[row, col] = pyramide[row - 1, col - 1] + pyramide[row - 1, col];
                        }
                    }
                }
                turns++;
            }
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (pyramide[row, col] > 0)
                    {
                        Console.Write(pyramide[row, col] + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}