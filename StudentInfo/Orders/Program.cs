using System.Security.Cryptography;

namespace Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double pricePerCapsule = double.Parse(Console.ReadLine());
            int daysInMonth = int.Parse(Console.ReadLine());
            int capsulesCount = int.Parse(Console.ReadLine());
            int a = 0;
            double momentPrice = 0;
            double totalPrice = 0;
            while (a < n)
            {
                momentPrice+= ((daysInMonth * capsulesCount) * pricePerCapsule);
                Console.WriteLine($"The price for the coffee is: ${momentPrice:F2}");
                totalPrice += momentPrice;
                momentPrice = 0;
                if (a + 1 < n)
                {
                    pricePerCapsule = double.Parse(Console.ReadLine());
                    daysInMonth = int.Parse(Console.ReadLine());
                    capsulesCount= int.Parse(Console.ReadLine());
                }
                
                a++;
            }
            Console.WriteLine($"Total: ${totalPrice:F2}");

        }
    }
}