namespace _07.RepeatString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string a = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());
            Repeat(a,n);
        }
        static void Repeat(string a, int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write(a);
            }
        }
    }
}