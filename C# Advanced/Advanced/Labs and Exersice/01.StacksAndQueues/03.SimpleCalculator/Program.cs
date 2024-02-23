namespace _03.SimpleCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> expression = Console.ReadLine().Split(" ").ToList();
            expression.Reverse();
            Stack<string> stack = new Stack<string>(expression);
            stack.Reverse();
            int sum = int.Parse(stack.Pop());
            while(stack.Count!=0)
            {
                if (stack.Peek() == "-")
                {
                    stack.Pop();
                    sum -=int.Parse(stack.Pop());
                }
                else if (stack.Peek() == "+")
                {
                    stack.Pop();
                    sum += int.Parse(stack.Pop());
                }
            }
            Console.WriteLine(sum);
        }
    }
}