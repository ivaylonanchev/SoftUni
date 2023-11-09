namespace _02.OddOccurrences
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
                string lowWord = list[i].ToLower();
                list[i] = lowWord;
            }
            Dictionary<string,int> pairs = new Dictionary<string,int>();
            foreach(string words in list)
            {
                if (pairs.ContainsKey(words))
                {
                    pairs[words]++;
                }
                else
                {
                    pairs[words] = 1;
                }
            }
            foreach(var pair in pairs)
            {
                if (pair.Value % 2 != 0)
                {
                    Console.Write(pair.Key + " ");
                }
            }
        }
    }
}