namespace _04.WordFilter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine()
                .Split(" ")
                .Where(x => x.Length%2 == 0)
                .ToList();
            foreach (string str in list)
            {
                Console.WriteLine(str); 
            }
        }
    }
}