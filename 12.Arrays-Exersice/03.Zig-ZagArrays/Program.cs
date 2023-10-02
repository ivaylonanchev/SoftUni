namespace _03.Zig_ZagArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] a = new int[n];
            int[] b = new int[n];
            for (int i = 1; i < n + 1; i++)
            {
                int[] s = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();
                if (i % 2 == 0)
                {
                    a[i - 1] = s[0];
                    b[i - 1] = s[1];
                }
                else
                {
                    b[i - 1] = s[0];
                    a[i - 1] = s[1];
                }
            }
            foreach (var bb in b)
                {
                    Console.Write(bb+ " ");
                }
            Console.WriteLine();
            foreach (var aa in a)
            {
                Console.Write(aa+ " ");
            }
        }

        }
}