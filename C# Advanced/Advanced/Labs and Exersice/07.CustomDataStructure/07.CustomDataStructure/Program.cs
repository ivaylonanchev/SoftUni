using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Channels;

namespace _07.CustomDataStructure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("IvoLIst::");
            IvoList list = new IvoList();
            list.Add(5);
            list.Add(6);
            list.RemoveAt(0);
            Console.WriteLine(list[0]);

            list.Add(10);
            list.Swap(0, 1);
            Console.WriteLine(list[1]);


            Console.WriteLine("\nIvoStack::");
            IvoStack stack = new IvoStack();
            stack.Push(5);
            stack.Push(11);
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Peek());
            Action<int> print = Console.WriteLine;
            stack.ForEach(Console.WriteLine);
        }
    }
}
