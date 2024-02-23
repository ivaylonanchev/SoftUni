using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _01.ListyIterator
{
    public class ListyIterator<T>
    {
        private List<T> list;
        private int Index { get; set; } = 0;

        public ListyIterator(T[] elements)
        {
            list = new List<T>(elements);

        }
        public bool Move()
        {
            if (Index + 1 <= list.Count)
            {
                Index++;
                return true;
            }
            return false;
        }
        public bool HasNext()
        {
            if (Index + 1 < list.Count)
            {
                return true;
            }

            return false;
        }
        public void Print()
        {
            if(list.Count == 0)
            {
                Console.WriteLine("Invalid Operation!");
            }
            else
            {
                Console.WriteLine(list[Index]);
            }
        }
    }
}
