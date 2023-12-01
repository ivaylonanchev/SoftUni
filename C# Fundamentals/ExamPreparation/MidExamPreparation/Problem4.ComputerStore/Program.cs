namespace Problem4.ComputerStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string components = Console.ReadLine();
            double total = 0;
            double taxes = 0;
            double totalAll = 0;
            while (components != "special" && components != "regular")
            {
                double prices = double.Parse(components);
                if (prices <= 0) Console.WriteLine("Invalid price!");
                else
                {
                    total += prices;
                }
                components = Console.ReadLine();
            }
            taxes = total * 0.2;
            if (components == "special")
            {
                totalAll = total + taxes;
                totalAll -= totalAll * 0.1; 
            }
            else if(components == "regular")
            {
                totalAll = total + taxes;
            }
            if (totalAll <= 0) Console.WriteLine("Invalid order!");
            else
            {
                Console.WriteLine("Congratulations you've just bought a new computer!");
                Console.WriteLine($"Price without taxes: {total:f2}$");
                Console.WriteLine($"Taxes: {taxes:f2}$");
                Console.WriteLine("-----------");
                Console.WriteLine($"Total price: {totalAll:f2}$");
            }
        }
    }
}