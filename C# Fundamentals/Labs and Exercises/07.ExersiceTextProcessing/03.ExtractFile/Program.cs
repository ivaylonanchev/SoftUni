namespace _03.ExtractFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine()
                .Split("\\")
                .ToList();
            List<string> names = list[list.Count-1]
                .Split(".")
                .ToList();
            Console.WriteLine("File name: " + names[0]);
            Console.WriteLine("File extension: "+ names[1]);
        }
    }
}