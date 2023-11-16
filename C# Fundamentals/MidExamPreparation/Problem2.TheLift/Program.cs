using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace Problem2.TheLift
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            List<int> list = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();
            for (int i = 0; i < list.Count; i++)
            {
                if (people >= 4)
                {
                    people -= 4 - list[i];
                    list[i] = 4;
                }
                else if (people < 4)
                {
                    if (list[i] + people < 4)
                    {
                        list[i] += people;
                        people = 0;
                    }
                    else
                    {
                        people -= 4 - list[i];
                        list[i] = 4;
                    }
                }
                if (people == 0) break;
            }
            bool t = false;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] < 4)
                {
                    t = true;
                    break;
                }
            }
            if (t == true)
            {
                Console.WriteLine("The lift has empty spots!");
                Console.WriteLine(string.Join(" ", list));
            }
            else if (people == 0 && t == false) Console.WriteLine(string.Join(" ", list));
            else
            {
                Console.WriteLine($"There isn't enough space! {people} people in a queue!");
                Console.WriteLine(string.Join(" ", list));
            }
        }
    }
}