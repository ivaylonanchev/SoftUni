using System.ComponentModel.Design;

namespace _06.ListManipulationsBasics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();
            string com = Console.ReadLine();
            while (com != "end")
            {
                string[] a = com.Split(' ');
                string command;
                int firstCommandNum;
                int secondNum;
                if (a.Length == 2)
                {
                    command = a[0];
                    string b = a[1];
                    firstCommandNum = int.Parse(b);
                    if (command == "Add")
                    {
                        Add(list, firstCommandNum);
                    }
                    else if (command == "Remove")
                    {
                        Remove(list, firstCommandNum);
                    }
                    else if (command == "RemoveAt")
                    {
                        RemoveAt(list, firstCommandNum);
                    }

                }
                else if (a.Length == 3)
                {
                    command = a[0];
                    string c = a[1];
                    firstCommandNum = int.Parse(c);
                    string d = a[2];
                    secondNum = int.Parse(d);
                    if (command == "Insert")
                    {
                        Insert(list, firstCommandNum, secondNum);
                    }
                }
                com = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", list));
        }
        static List<int> Add(List<int> list, int num)
        {
            list.Add(num);
            return list;
        }
        static List<int> Remove(List<int> list, int num)
        {
            list.Remove(num);
            return list;
        }
        static List<int> RemoveAt(List<int> list, int num)
        {
            list.RemoveAt(num);
            return list;
        }
        static List<int> Insert(List<int> list, int num1, int num2)
        {
            list.Insert(num2, num1);
            return list;
        }
    }
}