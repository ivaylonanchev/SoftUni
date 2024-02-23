using System.Reflection.Metadata;

namespace _08.BalancedParentheses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            var front = new Stack<string>(); 
            var back = new Stack<string>();
            int count = 0;
            for (int i = 0;i<word.Length;i++)
            {

                string symbol = word[i].ToString();
                int a = word.Length;
                if (i < ((word.Length / 2)))
                {
                    front.Push(symbol);
                    if (front.Peek() == "(")
                    {
                        back.Push(")");
                    }
                    else if(front.Peek() == "[")
                    {
                        back.Push("]");
                    }
                    else if (front.Peek() == "{")
                    {
                        back.Push("}");
                    }
                    else
                    {
                        count++;
                        break;
                    }

                }
                else
                {
                    if(back.Pop() != symbol)
                    {
                        count++;
                        break;
                    }
                }

            }
            if(count == 0)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}