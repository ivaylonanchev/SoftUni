using System.Security.Cryptography;

namespace _2.SumDigits
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            string a = Convert.ToString(num);
            int b = 0;
            for (int i = 0; i < a.Length-1; i++)
            {
                b += num % 10;
                num = num / 10;
            }
            b += num;
            Console.WriteLine(b);
        }
    }
}