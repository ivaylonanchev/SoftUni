namespace _04.SymbolInMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int rows = n;
            int cols = n;
            var matrix = new string[cols, rows];

            for (int row = 0; row < rows; row++)
            {
                string[] arr = Console.ReadLine()
                    .Split()
                    .ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = arr[col];
                }
            }
            string symbol = Console.ReadLine();
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] == symbol)
                    {
                        Console.WriteLine($"{row}, {col}");
                        break;
                    }
                }
            }
        }
    }
}