namespace _02.PritsReverseNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] a = new int[n];
            for (int i = 0; i < n; i++)
            {
                int b = int.Parse(Console.ReadLine());
                a[i] = b;
                
            }
            for (int i = a.Length;i > 0; i--)
            {
                Console.WriteLine(a[i-1]);
            }
        }
    }
}