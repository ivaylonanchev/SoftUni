namespace _03.CharactersInRange
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char a = char.Parse(Console.ReadLine());
            char b = char.Parse(Console.ReadLine());
            PrintCharactersInRange(a, b);
        }
        static void PrintCharactersInRange(char start, char end)
        {
            if (start <= end)
            {
                for (char i = (char)(start + 1); i < end; i++)
                {
                    Console.Write($"{i} ");
                }
            }
            else
            {
                for (char i = (char)(end + 1); i < start; ++i)
                {
                    Console.Write($"{i} ");
                }
            }
        }
    }
}