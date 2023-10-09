using System;
using System.ComponentModel.Design;
using System.Data;
using System.Globalization;

namespace _09.GreaterOfTwoValues
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string a = Console.ReadLine();
            if (a == "int")
            {
                int int1 = int.Parse(Console.ReadLine());
                int int2 = int.Parse(Console.ReadLine());
                int result=MaxInt(int1, int2);
                Console.WriteLine(result);
            }
            else if (a == "char")
            {
                char char1 = char.Parse(Console.ReadLine());
                char char2 = char.Parse(Console.ReadLine());
                char result= MaxChar(char1, char2);
                Console.WriteLine(result);
            }
            else if (a == "string")
            {
                string str1 = Console.ReadLine();
                string str2 = Console.ReadLine();
                string result=MaxString(str1, str2);
                Console.WriteLine(result);
            }
        }
        static int MaxInt(int a , int b)
        {
            if (a > b) return a;
            else return b;
            
        }
        static char MaxChar(char a , char b)
        {
            if (a > b) return a;
            else return b;
        }
        static string MaxString(string a , string b)
        {
            if (a.CompareTo(b) >= 0) return a;
            else return b;
        }

    }
}