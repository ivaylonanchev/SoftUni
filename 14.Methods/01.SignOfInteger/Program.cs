namespace _01.SignOfInteger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            Check(a);


        }
        static void Check(int number)
        {
            if (number == 0) Console.WriteLine($"The number {number} is zero. ");
            else if (number > 0) Console.WriteLine($"The number {number} is positive. ");
            else Console.WriteLine($"The number {number} is negative. ");
        }
    }
}