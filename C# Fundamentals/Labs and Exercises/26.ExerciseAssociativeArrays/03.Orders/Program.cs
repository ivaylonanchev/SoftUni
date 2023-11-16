using System.IO.Pipes;
using System.Runtime;

namespace _03.Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var dictionary = new Dictionary<string, List<double>>();
            while (input!="buy")
            {
                string[] arr = input.Split(" ").ToArray();
                string product = arr[0];
                string a = arr[1];
                string b = arr[2];

                double price = double.Parse(a);
                double quantity = double.Parse(b);

                if(!dictionary.ContainsKey(product))
                {
                    dictionary.Add(product, new List<double>());
                    dictionary[product].Add(price);
                    dictionary[product].Add((double)quantity);
                }
                else
                {
                    dictionary[product][0] = price;
                    dictionary[product][1]+=quantity;
                }
                input = Console.ReadLine();
            }
            foreach(var dic in dictionary)
            {
                double sum = dic.Value[0] * dic.Value[1];
                Console.WriteLine($"{dic.Key} -> {sum:f2}");
            }
        }
    }
}