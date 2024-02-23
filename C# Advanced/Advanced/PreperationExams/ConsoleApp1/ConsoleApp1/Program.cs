using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string a = "str";
            string a1 = a;
            string a3 = "str";
            string a2 = new string(a);
            Console.WriteLine(a==a1);//true
            Console.WriteLine(a.Equals(a1));//true
            Console.WriteLine(a2==a1);//false
            Console.WriteLine(a2.Equals(a));//true
            Console.WriteLine(a==a3);


        }
    }
}
