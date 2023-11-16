namespace _03.WordSynonym
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
            for (int i = 0; i < n; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();
                if (!dictionary.ContainsKey(word))
                {
                    dictionary[word] = new List<string> { synonym };
                }
                else
                {
                    dictionary[word].Add(synonym);
                }
            }
            foreach(var dic in dictionary)
            {
                Console.WriteLine(dic.Key + " - " + string.Join(", ",dic.Value));

            }
        }
    }
}