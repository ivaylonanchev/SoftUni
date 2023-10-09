namespace _06.CalculateRectangleArea
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            Area(a, b);
        }
        static void Area(int a, int b)
        {
            Console.WriteLine(a*b);
        }
    }
}