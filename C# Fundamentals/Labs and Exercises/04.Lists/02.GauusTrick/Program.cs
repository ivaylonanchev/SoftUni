namespace _02.GauusTrick
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .ToList();
            int count = numbers.Count/2;
            int n = numbers.Count-1;
            for (int i = 0; i < (count); i++)
            {
                numbers[i] += numbers[n];
                numbers.RemoveAt(n);
                n--;
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}