using System.Reflection.Metadata;
using System.Threading.Channels;

namespace _07.ListManipulatorAdvanced
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
            bool use = false;
            while (com != "end")
            {
                string[] a = com.Split(' ');
                string firstCommand = a[0];
                if (a.Length == 1)
                {
                    if (firstCommand == "PrintEven") PrintEven(list);
                    else if (firstCommand == "PrintOdd") PrintOdd(list);
                    else if (firstCommand == "GetSum") GetSum(list);
                }
                else if (a.Length == 2)
                {
                    string b = a[1];
                    int secondComandNum = int.Parse(b);
                    if (firstCommand == "Contains") Contains(list, secondComandNum);
                    else if (firstCommand == "Add")
                    {
                        Add(list, secondComandNum);
                        use = true;
                    }
                    else if (firstCommand == "Remove")
                    {
                        Remove(list, secondComandNum);
                        use = true;
                    }
                    else if (firstCommand == "RemoveAt")
                    {
                        RemoveAt(list, secondComandNum);
                        use = true;
                    }

                }
                else if (a.Length == 3)
                {
                    string secondCommand = a[1];
                    string c = a[2];
                    int thirdCommmand = int.Parse(c);
                    if (firstCommand == "Filter")
                    {
                        Filter(list, secondCommand, thirdCommmand);
                    }
                    else if (firstCommand == "Insert")
                    {
                        int secondCommandNum = int.Parse(secondCommand);
                        Insert(list, secondCommandNum, thirdCommmand);
                        use = true;
                    }
                }
                com = Console.ReadLine();
            }
            if (use == true) Console.WriteLine(string.Join(" ", list));
        }
        static void PrintEven(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] % 2 == 0)
                {
                    Console.Write(list[i] + " ");
                }
            }
            Console.WriteLine();
        }
        static void PrintOdd(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] % 2 == 1)
                {
                    Console.Write(list[i] + " ");
                }
            }
            Console.WriteLine();
        }
        static void GetSum(List<int> list)
        {
            int sum = 0;
            for (int i = 0; i < list.Count; i++)
            {
                sum += list[i];
            }
            Console.WriteLine(sum);
        }
        static void Contains(List<int> list, int num)
        {
            if (list.Contains(num) == true)
            {
                Console.WriteLine("Yes");
            }
            else Console.WriteLine("No such number");
        }
        static void Filter(List<int> list, string secondCommand, int thirdCommand)
        {
            if (secondCommand == "<")
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] < thirdCommand)
                    {
                        Console.Write(list[i] + " ");
                    }
                }
            }
            else if (secondCommand == ">")
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] > thirdCommand)
                    {
                        Console.Write(list[i] + " ");
                    }
                }
            }
            else if (secondCommand == "<=")
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] <= thirdCommand)
                    {
                        Console.Write(list[i] + " ");
                    }
                }
            }
            else if (secondCommand == ">=")
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] >= thirdCommand)
                    {
                        Console.Write(list[i] + " ");
                    }
                }
            }
            Console.WriteLine();
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