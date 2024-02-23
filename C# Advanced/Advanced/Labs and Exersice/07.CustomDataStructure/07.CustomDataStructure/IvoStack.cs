using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace _07.CustomDataStructure
{
    public class IvoStack
    {
        private const int capacity = 4;
        private int[] items;
        public int Count { get; private set; } = 0;
        public IvoStack()
        {
            Count = 0;
            items = new int[capacity];
        }
        public void Push(int element)
        {
            if(items.Length == Count)
            {
                IncreaseCapacity();
            }
            items[Count] = element;
            Count++;
        }

        public int Pop()
        {
            if (items.Length > 0)
            {
                int current = items[Count - 1];
                items[Count - 1] = 0;
                Count--;
                if (items.Length > Count * 4)
                {
                    Shrink();
                }
                return current;
            }
            else
            {
                throw new Exception("Nqma poveche elementi");
            }
        }
        
        public int Peek()
        {
            if (items.Length > 0)
            {
                return items[Count - 1];
            }
            else
            {
                throw new Exception("Nqma poveche elementi");
            }
        }
        public void ForEach(Action<object> action)
        {
            for (int i = 0; i < items.Length; i++)
            {
                action(items[i]);
            }
        }
        private void Shrink()
        {
            int[] newItems = new int[items.Length / 2];
            for (int i = 0; i < Count; i++)
            {
                newItems[i] = items[i];
            }
            items = newItems;
        }
        private void IncreaseCapacity()
        {
            int[] newItems = new int[items.Length * 2];
            for (int i = 0; i < Count; i++)
            {
                newItems[i] = items[i];
            }
            items = newItems;
        }
    }
}
