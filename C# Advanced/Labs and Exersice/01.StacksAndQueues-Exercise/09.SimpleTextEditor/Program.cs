using System.Text;

namespace _09.SimpleTextEditor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int commandsCount = int.Parse(Console.ReadLine());

            var stack = new Stack<string>();
            var text = new StringBuilder();

            for (int i = 0; i < commandsCount; i++)
            {
                string[] arr = Console.ReadLine()
                    .Split(" ")
                    .ToArray();
                int com = int.Parse(arr[0]);

                if (com == 1)
                {
                    stack.Push(text.ToString());
                    string word = arr[1];
                    text.Append(word);
                }
                else if (com == 2)
                {
                    stack.Push(text.ToString());
                    int count = int.Parse(arr[1]);
                    text.Remove(text.Length - count,count);
                }
                else if (com == 3)
                {
                    int index = int.Parse(arr[1])-1;
                    if(index>=0 && index < text.Length)
                    {
                        Console.WriteLine(text[index]);
                    }
                }
                else if(com == 4)
                {
                    text.Clear();
                    text.Append(stack.Pop());   
                }
            }
        }
    }
}