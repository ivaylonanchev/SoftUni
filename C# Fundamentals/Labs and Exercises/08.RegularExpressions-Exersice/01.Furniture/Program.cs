using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace _01.Furniture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @">>(?<name>[A-za-z]+)<<(?<price>\d+\.\d+|\d+)\!(?<quantity>\d+)";
            List<Furniture> furnitures = new List<Furniture>();


            while (input != "Purchase")
            {
                foreach (Match match in Regex.Matches(input, pattern))
                {
                    Furniture f = new Furniture()
                    {
                        Name = match.Groups["name"].Value,
                        Price = decimal.Parse(match.Groups["price"].Value),
                        Quantity = int.Parse(match.Groups["quantity"].Value)
                    };
                    furnitures.Add(f);
                }
                input = Console.ReadLine();

            }
            decimal sum = 0;
            Console.WriteLine("Bought furniture:");
            foreach (Furniture f in furnitures)
            {
                Console.WriteLine(f.Name);
                sum += f.Sum();
            }
            Console.WriteLine($"Total money spend: {sum:F2}");


        }
    }
    class Furniture
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Sum()
        {
            return Price * Quantity;
        }
    }
}