namespace _08.MathPower
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double num = double.Parse(Console.ReadLine());
            double power = double.Parse(Console.ReadLine());
            num = Power(num, power);
            Console.WriteLine(num);
        }
        static double Power(double a, double b)
        {
            double sum = Math.Pow(a, b);
            return sum;
        }
    }
}