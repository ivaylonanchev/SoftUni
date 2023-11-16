using System.Diagnostics;

namespace _04.SoftUniParking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var dictionary = new Dictionary<string, string>();
            for (int i = 0; i < n; i++)
            {
                string[] arr = Console.ReadLine()
                    .Split(" ")
                    .ToArray();
                string command = arr[0];
                string name = arr[1];

                if (command == "register")
                {
                    string number = arr[2];

                    if (!dictionary.ContainsKey(name))
                    {
                        dictionary[name] = number;
                        Console.WriteLine($"{name} registered {number} successfully");
                    }
                    else
                    {
                        Console.WriteLine("ERROR: already registered with plate number " + number);
                    }
                }
                else if (command == "unregister")
                {
                    if (dictionary.ContainsKey(name))
                    {
                        dictionary.Remove(name);
                        Console.WriteLine($"{name} unregistered successfully");
                    }

                    else Console.WriteLine($"ERROR: user {name} not found");
                }
            }
            foreach (var dic in dictionary)
            {
                Console.WriteLine($"{dic.Key} => {dic.Value}");
            }
        }
    }
}