using System.Reflection;

namespace _05.SumEvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int b = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i]%2==0 ) b +=arr[i];
            }
            Console.WriteLine(b);
        }
    }
}