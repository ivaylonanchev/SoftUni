namespace _03.Substring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string erasor = Console.ReadLine().ToLower();
            string word = Console.ReadLine();
            while(word.Contains(erasor))
            {
                word = word.Replace(erasor, string.Empty);
            }
            Console.WriteLine(string.Join("", word));
        }
    }
}