namespace _01.SumMatrixElements
{

    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();
            int sum = 0;
            int[,] matrix = new int[arr[0], arr[1]];
            Console.WriteLine(arr[0]);
            Console.WriteLine(arr[1]);
            for (int i = 0; i < arr[0]; i++)
            {
                int[] nums = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();
                for(int j = 0; j < arr[1]; j++)
                {
                    matrix[i,j] = nums[j];
                    sum+= nums[j];
                }
            }
            Console.WriteLine(sum);

        }
    }
}