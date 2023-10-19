using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Xml.Linq;

namespace _03.HouseParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> guests = new List<string>();
            for (int i = 0; i < n; i++)
            {
                string com = Console.ReadLine();
                string[] message = com.Split(" ");
                string guest = message[0];
                if(message.Contains("not"))
                {
                    if (guests.Contains(guest)) guests.Remove(guest);
                    else Console.WriteLine($"{guest} is not in the list!");
                }
                else
                {
                    if (guests.Contains(guest)) Console.WriteLine($"{guest} is already in the list!");
                    else guests.Add(guest);
                }
                
            }
            foreach(string m in guests)
            {
                Console.WriteLine(m);
            }
        }
        
    }
}