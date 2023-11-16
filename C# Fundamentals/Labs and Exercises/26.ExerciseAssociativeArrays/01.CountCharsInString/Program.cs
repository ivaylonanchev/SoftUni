namespace _01.CountCharsInString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine()
                .Split(" ")
                .ToList();
            Dictionary<char, int> dictionary = new Dictionary<char, int>();
            foreach (string s in list)
            {
                for (int i = 0; i < s.Length; i++)
                {
                    if (!dictionary.ContainsKey(s[i]))
                    {
                        dictionary[s[i]] = 1;
                    }
                    else
                    {
                        dictionary[s[i]]++;
                    }
                }
            }
            foreach (var dic in dictionary)
            {
                Console.WriteLine($"{dic.Key} -> {dic.Value}");
            }
        }
    }
}