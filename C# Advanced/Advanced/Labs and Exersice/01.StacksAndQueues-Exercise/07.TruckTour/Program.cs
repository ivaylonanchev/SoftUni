namespace _07.TruckTour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var difference = new Queue<int>();
            for (int i = 0; i < n; i++)
            {
                var arr = Console.ReadLine()
                    .Split(" ")
                    .Select(int.Parse)
                    .ToArray();
                int litters = arr[0];
                int km = arr[1];
                difference.Enqueue(litters-km);
            }   
            int index = 0;
            while(true)
            {
                var copyDifference = new Queue<int>(difference);
                int fuel = 0;
            }
            Console.WriteLine(index);
        }
    }
}