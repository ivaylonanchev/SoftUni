using System.Reflection.Metadata.Ecma335;

namespace _01.SmallestOfThreeNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SmallestNumber());
        }
        static int SmallestNumber()
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int[] arr = { a, b, c };
            Array.Sort(arr);
            return arr[0];
        }
    }
}