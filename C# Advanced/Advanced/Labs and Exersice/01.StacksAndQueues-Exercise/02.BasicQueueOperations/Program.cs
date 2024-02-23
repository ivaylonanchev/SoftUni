namespace _02.BasicQueueOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();
            int[] atherNums = Console.ReadLine()
                 .Split(" ")
                 .Select(int.Parse)
                 .ToArray();
            int N = nums[0];
            int S = nums[1];
            int X = nums[2];
            List<int> list = new List<int>();
            var queue = new Queue<int>(atherNums);
            for (int i = 0; i < S; i++)
            {
                list.Add(queue.Dequeue());
            }
            if (queue.Contains(X))
            {
                Console.WriteLine("true");
            }
            else if (queue.Any())
            {
                Console.WriteLine(queue.Min());
            }
            else
            {
                Console.WriteLine("0");
            }
        }
    }
}