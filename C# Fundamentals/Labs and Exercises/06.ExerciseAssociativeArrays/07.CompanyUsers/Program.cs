namespace _07.CompanyUsers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var dictionary = new Dictionary<string, List<string>>();
            while (input != "End")
            {
                string[] arr = input.Split(" -> ").ToArray();
                string name = arr[0];
                string number = arr[1];
                if (!dictionary.ContainsKey(name))
                {
                    dictionary.Add(name, new List<string>());
                    dictionary[name].Add(number);
                }
                else
                {
                    int n = 0;
                    foreach (var dic in dictionary)
                    {
                        if (dic.Value.Contains(number))
                        {
                            n++;
                            break;
                        }
                    }
                    if (n == 0)
                    {
                        dictionary[name].Add(number);
                    }
                }
                input = Console.ReadLine();
            }
            foreach (var dic in dictionary)
            {
                Console.WriteLine(dic.Key);
                for (int i = 0; i < dic.Value.Count; i++)
                {
                    Console.WriteLine("-- " + dic.Value[i]);
                }
            }
        }
    }
}