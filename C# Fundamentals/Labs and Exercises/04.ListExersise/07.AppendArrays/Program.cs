using Microsoft.VisualBasic;

namespace _07.AppendArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> numsAsString = Console.ReadLine()
                .Split('|')
                .ToList();
            List<int> numsAsInt = new List<int>();
            for (int i = 0; i < numsAsString.Count; i++)
            {
                string a = numsAsString[i];
                string[] str = a.Split(' ');
                for (int j = str.Length-1; j >= 0; j--)
                {
                    if (str[j] != "")
                    {
                        string b = str[j].ToString();
                        int c = int.Parse(b);
                        numsAsInt.Insert(0, c);
                    }
                }
            }
            Console.WriteLine(string.Join(" ", numsAsInt));

        }
    }
}