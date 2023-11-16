namespace _02.CommonElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] a = Console.ReadLine()
                .Split(' ')
                .ToArray();
            string[] b = Console.ReadLine()
                .Split(' ')
                .ToArray();
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < b.Length; j++)
                {
                    if (a[i] == b[j])
                    {
                        Console.Write(a[i] + " ");
                    }
                    }
            }
        }
    }
}