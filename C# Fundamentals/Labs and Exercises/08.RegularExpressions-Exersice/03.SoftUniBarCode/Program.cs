using System.Text.RegularExpressions;

namespace _03.SoftUniBarCode
{/*
%George%<Croissant>|2|10.3$
%Peter%<Gum>|1|1.3$
%Maria%<Cola>|1|2.4$
end of shift

%InvalidName%<Croissant>|2|10.3$
%Peter%<Gum>1.3$
%Maria%<Cola>|1|2.4
%Valid%<Valid>valid|10|valid20$
end of shift
  */
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\%(?<name>[A-z][a-z]+)\%[^\|\$\%\.]*\<(?<product>\w+)\>[^\|\%\$\.]*\|*(?<count>\d+)\|[^\|\$\%\.]*?(?<price>\d+(\.\d+)?)\$";
            string input = Console.ReadLine();
            List<Order> orders = new List<Order>();
            while (input != "end of shift")
            {
                foreach (Match match in Regex.Matches(input, pattern))
                {
                    Order order = new Order()
                    {
                        Customer = match.Groups["name"].Value,
                        Product = match.Groups["product"].Value,
                        Count = int.Parse(match.Groups["count"].Value),
                        Price = decimal.Parse(match.Groups["price"].Value),
                    };
                    orders.Add(order);
                }


                input = Console.ReadLine();
            }
            decimal total = 0;
            foreach (Order ord in orders)
            {
                Console.WriteLine($"{ord.Customer}: {ord.Product} - {ord.Calculate():f2}");
                total += ord.Calculate();
            }
            Console.WriteLine($"Total income: {total:f2}");
        }
    }
    class Order
    {
        public string Customer { get; set; }
        public string Product { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public decimal Calculate()
        {
            return Count * Price;
        }

    }
}