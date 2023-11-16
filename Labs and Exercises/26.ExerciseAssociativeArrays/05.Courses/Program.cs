namespace _05.Courses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var dictionary = new Dictionary<string, List<string>>();
            while (input != "end")
            {
                string[] arr = input.Split(" : ").ToArray();
                string course = arr[0];
                string name = arr[1];
                if (!dictionary.ContainsKey(course))
                {
                    dictionary.Add(course, new List<string>());
                    dictionary[course].Add(name);
                }
                else
                {
                    int n = 0;
                    foreach (var dic in dictionary)
                    {
                        if (dic.Value.Contains(name))
                        {
                            n++;
                            break;
                        }
                    }
                    if (n == 0)
                    {
                        dictionary[course].Add(name);
                    }
                }
                input = Console.ReadLine();
            }
            foreach (var dic in dictionary)
            {
                Console.WriteLine(dic.Key + ": " + dic.Value.Count);
                for (int i = 0; i < dic.Value.Count; i++)
                {
                    Console.WriteLine("-- " + dic.Value[i]);
                }
            }
        }
    }
}