using System.Globalization;

namespace _02.VowelsCount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string a = Console.ReadLine();
            Console.WriteLine(NumberOfVolews(a));
        }
        static int NumberOfVolews(string a)
        {
            int nums = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == 'a' || a[i] == 'e' || a[i] == 'i' || a[i] == 'o' || a[i] == 'u' ||
                   a[i] == 'A' || a[i] == 'E' || a[i] == 'I' || a[i] == 'O' || a[i] == 'U') nums++;
            }
            return nums;
        }
    }
}