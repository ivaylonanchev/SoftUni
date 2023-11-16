namespace _03.RoundingNumbers_Split
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string a = Console.ReadLine();
            string[] arr = a.Split(' ');
            double[] items = new double[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                items[i] = double.Parse(arr[i]);
            }
            for (int i = 0;i < items.Length; i++)
            {
                Console.WriteLine(Math.Round(items[i], 1));
            }
        }
    }
}