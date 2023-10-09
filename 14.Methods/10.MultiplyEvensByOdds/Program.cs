using System.Security.Cryptography;

namespace _10.MultiplyEvensByOdds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());
            x = Math.Abs(x);
            string num = Convert.ToString(x);
            int[] allNumbers = new int[num.Length];
            for (int i = 0; i < num.Length; i++)
            {
                allNumbers[i] = x % 10;
                x /= 10;
            }
            int sum = SumOFOdds(num, allNumbers);
            Console.WriteLine(sum);


        }
        static int SumOFOdds(string num, int[] a)
        {
            int odd = 0;
            int even = 0;
            for (int i = 0; i < num.Length; i++)
            {
                if (a[i] % 2 == 0) even += a[i];
                else odd += a[i];
            }
            return odd*even;
        }
    }
}