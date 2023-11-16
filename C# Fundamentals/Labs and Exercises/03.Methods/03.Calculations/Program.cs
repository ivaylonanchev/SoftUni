namespace _03.Calculations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string calcs = Console.ReadLine();
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());
            if (calcs == "add") Add(number1, number2);
            else if (calcs =="multiply") Multiply(number1, number2);
            else if (calcs =="divide") Divide(number1, number2);
            else if (calcs =="subtract") Subtract(number1, number2);

        }
        static void Add(int a, int b)
        {
            a+= b;
            Console.WriteLine(a);
        }
        static void Multiply(int a, int b)
        {
            a *= b;
            Console.WriteLine(a);
        }
        static void Divide(int a, int b)
        {
            a /= b;
            Console.WriteLine(a);
        }
        static void Subtract(int a, int b)
        {
            a -= b;
            Console.WriteLine(a);
        }
    }
}