using System.Numerics;
namespace _02.BigInt
{ 
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            BigInteger i = 1;
            for (int j = 2; j <= num; j++)
            {
                i *= j;
            }
            Console.WriteLine(i);
        }
    }
}