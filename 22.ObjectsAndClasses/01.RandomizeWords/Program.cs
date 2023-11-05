namespace _01.RandomizeWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine()
                .Split(' ')
                .ToList();
            var random = new Random();
            int count = words.Count;
            for (int i = 0; i < count; i++)
            {
                int randomNum = random.Next(0, words.Count);
                Console.WriteLine(words[randomNum]);
                words.RemoveAt(randomNum);
            }
        }
    }
}