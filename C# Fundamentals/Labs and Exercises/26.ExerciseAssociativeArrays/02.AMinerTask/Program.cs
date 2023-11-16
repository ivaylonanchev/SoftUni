namespace _02.AMinerTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var dictionary = new Dictionary<string, int>();
            while (input != "stop")
            {
                int resource = int.Parse(Console.ReadLine());
                if (!dictionary.ContainsKey(input))
                {
                    dictionary[input] = resource;
                }
                else
                {
                    dictionary[input] += resource;
                }
                input = Console.ReadLine();
            }
            foreach(var dic in dictionary)
            {
                Console.WriteLine($"{dic.Key} -> {dic.Value}");
            }
        }
    }
}