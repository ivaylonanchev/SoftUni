using System.Runtime.InteropServices;

string coins = Console.ReadLine();
double all = 0; ;
while (coins != "Start")
    {
        if (coins == "2" || coins == "1" || coins == "0.5" || coins == "0.2" || coins == "0.1")
        {
            all += double.Parse(coins);
        }
        else if (coins == "Start")
        {
            break;
        }
        else
        {
            Console.WriteLine($"Cannot accept {coins}");

        }
        coins = Console.ReadLine();

}
string products = Console.ReadLine();
while (products != "End")
{ 
    if (products == "Nuts")
    {
        if (all >= 2)
        {
            all -= 2;
            Console.WriteLine($"Purchased nuts");
        }
        else Console.WriteLine("Sorry, not enough money");
    }
    else if (products == "Water")
    {
        if (all >= 0.7)
        {
            all -= 0.7;
            Console.WriteLine($"Purchased water");
        }
        else Console.WriteLine("Sorry, not enough money");
    }
    else if (products == "Crisps")
    {
        if (all >= 1.5)
        {
            all -= 1.5;
            Console.WriteLine($"Purchased crisps");
        }
        else Console.WriteLine("Sorry, not enough money");
    }
    else if (products == "Soda")
    {
        if (all >= 0.8)
        {
            all -= 0.8;
            Console.WriteLine($"Purchased soda");
        }
        else Console.WriteLine("Sorry, not enough money");
    }
    else if (products == "Coke")
    {
        if (all >= 1)
        {
            all -= 1;
            Console.WriteLine($"Purchased coke");
        }
        else Console.WriteLine("Sorry, not enough money");
    }
    else if (products == "End") break;
    else Console.WriteLine("Invalid product");
    products = Console.ReadLine();

}
if (all>=0) Console.WriteLine($"Change: {all:F2}");