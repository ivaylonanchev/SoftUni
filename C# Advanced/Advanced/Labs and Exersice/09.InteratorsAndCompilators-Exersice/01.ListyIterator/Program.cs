using System;
using System.Linq;
using System.Threading.Channels;

namespace _01.ListyIterator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var create = Console.ReadLine()
                .Split(new string[] { "Create" , " "}, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            ListyIterator<string> list = new ListyIterator<string>(create);
            string comm;
            while((comm = Console.ReadLine()) != "END")
            {
                var arr = comm.Split(',').ToArray();
                string c = arr[0];
                if(c == "Move")
                {
                    Console.WriteLine(list.Move());
                }
                else if(c == "Print")
                {
                    list.Print();
                }
                else if (c == "HasNext")
                {
                    Console.WriteLine(list.HasNext());
                }
            }
        }
    }
}
