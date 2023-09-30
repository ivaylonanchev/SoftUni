namespace _10.Pokemon
{
    internal class Program
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            int M = int.Parse(Console.ReadLine());
            int Y = int.Parse(Console.ReadLine());
            int n = N;
            int pokeCount = 0;
            while (n >= M)
            {
                n -= M;
                pokeCount++;
                if (n == N * 0.5 && Y!=0)
                {
                    n = n / Y;
                }

            }
            Console.WriteLine(n);
            Console.WriteLine(pokeCount);

        }
    }
}