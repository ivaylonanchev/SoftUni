using System.Globalization;

namespace _02.StackSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();
            Stack<int> stack = new Stack<int>(list);
            string input;
            while ((input = Console.ReadLine().ToLower()) != "end")
            {
                string[] arr = input.Split(" ");
                string command = arr[0].ToString();
                if (command == "add")
                {
                    int firstNum = int.Parse(arr[1].ToString());
                    int secondNum = int.Parse(arr[2].ToString());
                    stack.Push(firstNum);
                    stack.Push(secondNum);
                }
                else if (command == "remove")
                {
                    int remove = int.Parse(arr[1].ToString());
                    if (stack.Count >= remove)
                    {

                        for (int i = 0; i < remove; i++)
                        {
                            stack.Pop();
                        }
                    }
                }
            }
            Console.WriteLine("Sum: " + stack.Sum());
        }
    }
}