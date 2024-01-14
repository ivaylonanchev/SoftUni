namespace _05.PrintEvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();
            Queue<int> queue = new Queue<int>(numbers);
            List<int> list = new List<int>();
            while (queue.Count > 0)
            {
                if(queue.Peek()%2 == 0)
                {
                    list.Add(queue.Dequeue());
                }
                else
                {
                    queue.Dequeue();
                }
            }
            Console.WriteLine(string.Join(", ", list));
        }
    }
}