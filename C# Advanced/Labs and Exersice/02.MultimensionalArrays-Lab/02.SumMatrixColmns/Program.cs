namespace _02.SumMatrixColmns
{
    /*
3, 6
7 1 3 3 2 1
1 3 9 8 5 6
4 6 7 9 1 0
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            int rows = arr[0];
            int cols = arr[1];

            var matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var currentRow = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            for (int col = 0; col < cols; col++)
            {
                int sum = 0;
                for (int row = 0;row<rows; row++)
                {
                    sum+= matrix[row, col];
                }
                Console.WriteLine(sum);
            }

        }
    }
}