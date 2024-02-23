namespace _06.Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Queue<string> queue = new Queue<string>();
            while (input !="End")
            {
                if (input != "Paid")
                {
                    queue.Enqueue(input);
                }
                else
                {
                    while (queue.Count > 0)
                    {
                        Console.WriteLine(queue.Dequeue());
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(queue.Count + " people remaining.");
        }
    }
}