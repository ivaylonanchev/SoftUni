namespace _04.CaeserCipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine()
                .Split(" ")
                .ToList();
            for (int i = 0; i < list.Count; i++)
            {
                ConvertWords(list[i]);
                if (i < list.Count - 1)
                {
                    Console.Write("#");
                }
            }
        }
        static void ConvertWords(string word)
        {
            List<string> newWord = new List<string>();
            for (int i = 0; i < word.Length; i++)
            {
                int a = word[i] + 3;
                char b = Convert.ToChar(a);
                Console.Write(b.ToString());
            }
            
        }
    }
}