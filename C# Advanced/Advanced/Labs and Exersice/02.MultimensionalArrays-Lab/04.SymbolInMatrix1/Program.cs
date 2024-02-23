namespace _04.SymbolInMatrix1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int rows = n;
            int cols = n;

            var matrix = new char[cols, rows];

            for (int row = 0; row < rows; row++)
            {
                string currentRow = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }
            char symbol = char.Parse(Console.ReadLine());
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] == symbol)
                    {
                        Console.WriteLine($"({row}, {col})");
                        return;
                    }
                }
            }
            Console.WriteLine(symbol + " does not occur in the matrix");
        }
    }
}