namespace _01.BasicStackOperations
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
            var stack = new Stack<int>(atherNums);
            for (int i = 0; i < S; i++)
            {
                list.Add(stack.Pop());
            }
            if (stack.Contains(X))
            {
                Console.WriteLine("true");
            }
            else if (stack.Any())
            {
                Console.WriteLine(stack.Min());
            }
            else
            {
                Console.WriteLine("0");
            }

            
        }
    }
}