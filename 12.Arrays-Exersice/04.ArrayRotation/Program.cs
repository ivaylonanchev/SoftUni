namespace _04.ArrayRotation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            int[] arr2 = new int[arr.Length];
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                if (i % 2 == 0) {
                    for (int j = 0; j < arr.Length; j++)
                    {
                        if (j < arr.Length - 1) arr2[j] = arr[j + 1];
                        else if (j == arr.Length - 1) arr2[j] = arr[0];
    
                    }
                }
                else
                {
                    for (int j = 0; j < arr.Length; j++)
                    {
                        if (j < arr.Length - 1) arr[j] = arr2[j + 1];
                        else if (j == arr.Length - 1) arr[j] = arr2[0];

                    }
                }
            }
            if(n%2==0) Console.WriteLine(string.Join(" ", arr));
            else Console.WriteLine(string.Join(" ", arr2));
        }
    }
}