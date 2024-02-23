using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ChickenSnack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var a = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            var money = new Stack<int>(a);
            var b = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            var price = new Queue<int>(b);

            int lenght = price.Count;

            int left = 0;
            int foodCount = 0;
            for (int i = 0; i < lenght; i++)
            {
                int currentMoney = money.Pop() + left;
                int currentPrice = price.Dequeue();
                left = 0;

                if (currentMoney == currentPrice)
                {
                    foodCount++;
                }
                else if (currentMoney < currentPrice)
                {

                }
                else if (currentMoney > currentPrice)
                {
                    left = currentMoney - currentPrice;
                    foodCount++;
                }
            }
            if (foodCount >= 4)
            {
                Console.WriteLine($"Gluttony of the day! Henry ate {foodCount} foods.");
            }

            else if (foodCount > 1)
            {
                Console.WriteLine($"Henry ate: {foodCount} foods.");
            }
            else if (foodCount == 1)
            {
                Console.WriteLine($"Henry ate: {foodCount} food.");
            }
            else if(foodCount == 0)
            {
                Console.WriteLine("Henry remained hungry. He will try next weekend again.");
            }

        }
    }
}
