using System.Data;
using System.Diagnostics.Contracts;

namespace _05.Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string a = Console.ReadLine();
            int num1 = int.Parse(Console.ReadLine());
            double num = Convert.ToDouble(num1);
            if (a == "water") Water(num);
            else if (a == "coffee") Coffee(num);
            else if (a == "coke") Coke(num);
            else if (a =="snacks") Snacks(num);
        }
        static void Water(double a)
        {
            Console.WriteLine($"{a * 1.00:f2}");
        }
        static void Coffee(double a)
        {
            Console.WriteLine($"{a * 1.50:f2}");
        }
        static void Coke(double a)
        {
            Console.WriteLine($"{a * 1.4:f2}");
        }
        static void Snacks(double a)
        {
            Console.WriteLine($"{a * 2.00:f2}");
        }
    }
}