using System.Security;

namespace Problem2.TaxCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine()
                .Split(">>")
                .ToList();
            double allTaxes = 0;
            for (int i = 0; i < list.Count; i++)
            {
                string a = list[i];
                string[] b = a.Split(" ");
                string type = b[0];
                string c = b[1];
                int year = int.Parse(c);
                string v = b[2];
                int km = int.Parse(v);

                int Tax = 0;
                int Tax2 = 0;
                int carTax = 0;
                int kmTax = 0;
                if (type == "family")
                {
                    Tax = 50;
                    Tax2 = 12;
                    carTax = 5;
                    kmTax = 3000;
                    Tax -= carTax * year;
                    Tax += Tax2 * (int)(km / kmTax);
                    allTaxes += Tax;
                    Console.WriteLine($"A {type} car will pay {Tax:f2} euros in taxes.");
                }
                else if (type == "heavyDuty")
                {
                    Tax = 80;
                    Tax2 = 14;
                    carTax = 8;
                    kmTax = 9000;
                    Tax -= carTax * year;
                    Tax += Tax2 * (int)(km / kmTax);
                    allTaxes += Tax;
                    Console.WriteLine($"A {type} car will pay {Tax:f2} euros in taxes.");
                }
                else if (type == "sports")
                {
                    Tax = 100;
                    Tax2 = 18;
                    carTax = 9;
                    kmTax = 2000;
                    Tax -= carTax * year;
                    Tax += Tax2 * (int)(km / kmTax);
                    allTaxes += Tax;
                    Console.WriteLine($"A {type} car will pay {Tax:f2} euros in taxes.");
                }
                else
                {
                    Console.WriteLine("Invalid car type.");
                }
            }
            Console.WriteLine($"The National Revenue Agency will collect {allTaxes:f2} euros in taxes.");
        }
    }
}