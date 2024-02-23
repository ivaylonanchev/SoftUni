namespace _07.HotPotatoe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine()
                .Split(" ")
                .ToArray();
            int passes = int.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>(names);

            while (queue.Count > 1)
            {

                for (int i = 0; i < passes - 1; i++)
                {
                    string current = queue.Dequeue();
                    queue.Enqueue(current);
                }
                Console.WriteLine("Removed " + queue.Dequeue());
            }
            Console.WriteLine("Last is " + queue.Dequeue());
        }
    }
}