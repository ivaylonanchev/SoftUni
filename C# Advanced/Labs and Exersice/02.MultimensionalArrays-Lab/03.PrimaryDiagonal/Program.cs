namespace _03.PrimaryDiagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int rows = n;
            int cols = n;
            var matrix = new double[cols, rows];

            double sum = 0;
            for ( int row = 0; row < rows; row++)
            {
                double[] arr = Console.ReadLine()
                    .Split(" ")
                    .Select(double.Parse)
                    .ToArray();
                for ( int col = 0; col < cols; col++)
                {
                    matrix[row, col] = arr[col];
                    if(row==col)
                    {
                        sum += arr[col];
                    }
                }
            }
            Console.WriteLine( sum);
        }
    }
}