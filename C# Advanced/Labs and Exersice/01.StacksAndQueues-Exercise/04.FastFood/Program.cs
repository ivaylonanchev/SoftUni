using System.Text;

namespace _04.FastFood
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int allOrders = int.Parse(Console.ReadLine());
            var arr = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();
            var queue = new Queue<int>(arr);
            var sb = new StringBuilder();
            Console.WriteLine(queue.Max());
            while(queue.Count > 0)
            {
                if(allOrders- queue.Peek() >= 0)
                {
                    allOrders-= queue.Dequeue();
                }
                else
                {
                    sb.AppendLine(string.Join(" ", queue));
                    Console.WriteLine("Orders left: " + sb);
                    break;
                }
            }
            if (queue.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}