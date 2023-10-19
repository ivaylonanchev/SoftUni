using System.Globalization;

namespace _02.ChangeList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();
            string com = Console.ReadLine();
            while (com != "end")
            {
                string[] commands = com.Split(" ");
                string commandFirst = commands[0];
                string a = commands[1];
                int firstNum = int.Parse(a);
                if (commandFirst == "Delete")
                {
                    Delete(list, firstNum);
                }
                else if (commandFirst == "Insert")
                {
                    string b = commands[2];
                    int secondNum = int.Parse(b);
                    Insert(list, firstNum, secondNum);
                }
                com = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", list));
        }
        static void Delete(List<int> list, int num)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == num)
                {
                    list.RemoveAt(i);
                    i--;
                }
            }
        }
        static void Insert(List<int> list, int num1, int num2)
        {
            list.Insert(num2,num1);
        }
    }
}