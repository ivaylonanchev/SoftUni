using System.Security.Cryptography;

namespace _01.Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> vagons = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();
            int capacity = int.Parse(Console.ReadLine());
            for (int i = 0; i < vagons.Count; i++)
            {
                if (vagons[i] > capacity)
                {

                    int left = capacity - vagons[i];
                    vagons[i] = capacity;
                    if (i < vagons.Count - 1) vagons[i + 1] += left;
                    else if (i >=vagons.Capacity) vagons.Add(left);
                }
            }
            string com = Console.ReadLine();
            while(com != "end")
            {
                string[] commands = com.Split(" ");
                if(commands.Length == 1 )
                {
                    
                    int passengers = int.Parse(com);
                    AddNumbers(vagons, passengers, capacity);
                }
                else if(commands.Length == 2 )
                {
                    string firstCom = commands[0];
                    string a = commands[1];
                    int secondCom = int.Parse(a);
                    Add(vagons, secondCom);
                }
                com = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ",vagons));
        }
        static void Add(List<int> vagons, int passengers)
        {
            vagons.Add(passengers);
        }
        static void AddNumbers(List<int> vagons, int passengers, int maxPassengers)
        {
            for (int i = 0; i < vagons.Count; i++)
            {
                if (vagons[i] + passengers <= maxPassengers)
                {
                    vagons[i] += passengers;
                    break;
                }
            }
        }
    }
}