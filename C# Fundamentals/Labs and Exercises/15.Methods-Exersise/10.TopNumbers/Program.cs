using System;

namespace _10.TopNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            for (int i = 17; i <= num; i++)
            {
                if (SumOfDigits(i) == true &&
                    OneOddDigit(i) == true)
                {
                    Console.WriteLine(i);
                }

            }
        }
        static bool SumOfDigits(int num)
        {
            int sum = 0;
            string b = num.ToString();
            for (int i = 0; i < b.Length; i++)
            {
                sum += num % 10;
                num /= 10;
            }
            if (sum % 8 == 0) return true;
            else return false;
        }
        static bool OneOddDigit(int num)
        {
            string b = num.ToString();
            for (int i = 0; i < b.Length; i++)
            {
                int sum = num % 10;
                if (sum % 2 == 1) return true;
                num /= 10;
            }
            return false;
        }
    }
}