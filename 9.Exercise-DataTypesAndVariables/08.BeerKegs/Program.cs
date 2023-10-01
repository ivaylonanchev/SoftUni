using System.Security.Cryptography;

namespace _8.BeerKegs
{
    internal class Program
    {
        static void Main()
        {
            //
            int n = int.Parse(Console.ReadLine());
            double size = 0;
            string bigkeg = "";
            for (int i = 0; i < n; i++)
            {
                string keg = Console.ReadLine();
                double r = double.Parse(Console.ReadLine());
                double h = double.Parse(Console.ReadLine());
                if (size < (Math.PI * r * r * h))
                {
                    size = Math.PI * r * r * h;
                    bigkeg = keg;
                }
            }
            Console.WriteLine(bigkeg);

        }
    }
}