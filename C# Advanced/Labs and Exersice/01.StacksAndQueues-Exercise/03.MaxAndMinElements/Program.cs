using System.Diagnostics;
using System.Text;

namespace _03.MaxAndMinElements
{
    /*  
9
1 97
2
1 20
2
1 26
1 20
3
1 91
4
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            int queries = int.Parse(Console.ReadLine());

            var stack = new Stack<int>();
            var stringBuilder = new StringBuilder();
            for (int i = 0; i < queries; i++)
            {
                int[] arr = Console.ReadLine()
                    .Split(" ")
                    .Select(int.Parse)
                    .ToArray();
                int command = arr[0];
                if (command == 1)
                {
                    int num = arr[1];
                    stack.Push(num);
                }
                else if (command == 2)
                {
                    if (stack.Count > 0)
                    {
                        stack.Pop();
                    }
                }
                else if (command == 3)
                {
                    if (stack.Count > 0)
                    {
                        Console.WriteLine(stack.Max());
                    }
                }
                else if (command == 4)
                {
                    if (stack.Count > 0)
                    {
                        Console.WriteLine(stack.Min());
                    }
                }
            }
            stringBuilder.AppendLine(string.Join(", ", stack));
            Console.WriteLine(stringBuilder);
        }
    }
}