namespace _08.CondenceArrayToNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] a = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            if(a.Length == 1)
            {
                Console.WriteLine($"{a[0]} is already condensed to number");
            }
            int l = a.Length;
            if (a.Length > 1)
            {
                for (int i = 0; i < a.Length - 1; i++)
                {
                    for (int j = 0; j < l; j++)
                    {
                        if (j < a.Length - 1)
                        {
                            a[j] = a[j] + a[j + 1];
                        }
                    }
                    l -= 1;
                }
                Console.WriteLine(a[0]);
            }
        }
    }
}