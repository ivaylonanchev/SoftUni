using System.Net.Security;

namespace Problem6.MemoryGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine()
                .Split(' ')
                .ToList();
            int moves = 0;
            string indexes = Console.ReadLine();
            while (indexes != "end")
            {
                string[] arr = indexes.Split(' ');
                string a = arr[0];
                int firstIndex = int.Parse(a);
                string b = arr[1];
                int secondIndex = int.Parse(b);
                moves++;
                if (firstIndex == secondIndex
                    || firstIndex < 0
                    || firstIndex >= list.Count
                    || secondIndex < 0
                    || secondIndex >= list.Count)
                {
                    int m = list.Count / 2;
                    list.Insert(m, "-" + moves + "a");
                    list.Insert(m, "-" + moves + "a");
                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                }
                else
                {
                    Twins(list, firstIndex, secondIndex);
                }

                if (list.Count == 0)
                {
                    Console.WriteLine($"You have won in {moves} turns!");
                    break;
                }
                indexes = Console.ReadLine();
            }
            if (indexes == "end")
            {
                Console.WriteLine("Sorry you lose :(");
                Console.WriteLine(string.Join(" ", list));
            }
        }
        static void Twins(List<string> list, int firstIndex, int secondIndex)
        {
            if (list[firstIndex] == list[secondIndex])
            {
                Console.WriteLine($"Congrats! You have found matching elements - {list[firstIndex]}!");
                if (firstIndex > secondIndex)
                {
                    list.RemoveAt(firstIndex);
                    list.RemoveAt(secondIndex);
                }
                else
                {
                    list.RemoveAt(secondIndex);
                    list.RemoveAt(firstIndex);
                }
            }
            else Console.WriteLine("Try again!");
        }
    }
}