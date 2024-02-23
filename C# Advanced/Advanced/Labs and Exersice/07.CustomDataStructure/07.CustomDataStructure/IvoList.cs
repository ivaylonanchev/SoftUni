using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _07.CustomDataStructure
{
    public class IvoList
    {
        private const int listSize = 2;
        private int[] items;
        public int Count { get; private set; } = 0;
        public int this[int index]
        {
            get
            {
                if(index<0 && index >= Count)
                {
                    throw new ArgumentOutOfRangeException("index not right");
                }
                return items[index];
            }
            set
            {
                items[index] = value;
            }
        }

        public IvoList()        {
            items = new int[listSize];
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            for(int i = 0; i < Count;i++)
            {
                sb.Append(items[i] + " ");
            }
            return sb.ToString().TrimEnd();
        }
        public void Add(int element)
        {
            if (Count >= items.Length)
            {
                IncreaseCapacity();
            }
            items[Count] = element;
            Count++;
        }

        public void RemoveAt(int index)
        {
            if (index >= 0 && index < Count)
            {
                items[index] = 0;
                for (int i = index; i < Count - 1; i++)
                {
                    items[i] = items[i + 1];
                }
                Count--;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
            if (Count <= items.Length / 4)
            {
                Shrink();
            }
        }

        public bool Contains(int element)
        {
            for (int i = 0; i < Count; i++)
            {
                if (items[i] == element)
                {
                    return true;
                }
            }
            return false;

        }
        public void Swap(int firstElement, int secondElement)
        {
            if (firstElement>=0 && firstElement<Count
                &&secondElement>=0 && secondElement<Count)
            {
                int first = items[firstElement];
                items[firstElement] = items[secondElement];
                items[secondElement] = first;
            }
            else
            {
                throw new OutOfMemoryException();
            }
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
        private void Shrink()
        {
            int[] newItems = new int[items.Length / 2];
            for (int i = 0; i < Count; i++)
            {
                newItems[i] = items[i];
            }
            items = newItems;
        }
    }
}
