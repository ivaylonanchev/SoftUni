namespace _05.FashionBoutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();
            var stack = new Stack<int>(arr);

            int rack = int.Parse(Console.ReadLine());
            int racks = rack;
            int rackCount = 1;
            while (stack.Count > 0)
            {
                if(racks-stack.Peek()>0) 
                {
                    racks-=stack.Pop();
                }
                else
                {
                    racks = rack;
                    rackCount++;
                }
            }
            Console.WriteLine(rackCount);
        }
    }
}