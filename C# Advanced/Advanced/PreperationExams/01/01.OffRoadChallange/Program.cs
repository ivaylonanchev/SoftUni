
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace _01.OffRoadChallange
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var initialFuel = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            var consumprion = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            var fuel = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

            int reached = 0;
            for (int i = 0; i < consumprion.Count; i++)
            {
                int l = initialFuel[initialFuel.Count - 1] - consumprion[i];
                if (l >= fuel[i])
                {
                    reached++;
                    Console.WriteLine("John has reached: Altitude " + reached);
                    initialFuel.RemoveAt(initialFuel.Count - 1);
                }
                else
                {
                    Console.WriteLine("John did not reach: Altitude " + (reached + 1));
                    Console.WriteLine("John failed to reach the top.");
                    break;
                }
            }
            if (reached == 4)
            {
                Console.WriteLine("John has reached all the altitudes and managed to reach the top!");
            }
            else if(reached == 0)
            {
                Console.WriteLine("John didn't reach any altitude.");
            }
            else
            {
                var list = new List<string>();
                for (int i = 1; i <= reached; i++)
                {
                    list.Add("Altitude " + i.ToString());
                }
                Console.WriteLine("Reached altitudes: " + string.Join(", ", list));

            }
        }
    }
}
