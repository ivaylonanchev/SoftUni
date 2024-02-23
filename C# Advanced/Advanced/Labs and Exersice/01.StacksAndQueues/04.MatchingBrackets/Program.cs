using System.Reflection.Metadata.Ecma335;

namespace _04.MatchingBrackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    stack.Push(i);
                }
                else if (expression[i] == ')')
                {
                    int start = stack.Pop();
                    int end = i;

                    string inBrackets = expression.Substring(start, end - start +1);
                    Console.WriteLine(inBrackets);
                }

            }
        }
    }
}