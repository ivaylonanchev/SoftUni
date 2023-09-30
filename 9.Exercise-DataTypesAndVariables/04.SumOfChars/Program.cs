namespace _4.SumOfChars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = 0; i < a; i++)
            {
                char num = char.Parse(Console.ReadLine());
                sum += (int)num;
            }
            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}