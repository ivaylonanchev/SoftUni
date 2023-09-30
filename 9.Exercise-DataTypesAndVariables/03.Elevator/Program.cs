namespace _3.Elevator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double allpersons = double.Parse(Console.ReadLine());
            int capasity = int.Parse(Console.ReadLine());
            Console.WriteLine(Math.Ceiling(allpersons/capasity));
        }
    }
}