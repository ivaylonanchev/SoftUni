namespace _06.StudentAcademy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            var dictionary = new Dictionary<string, List<double>>();
            for (int i = 0; i < num; i++)
            {
                string name = Console.ReadLine();
                double rating = double.Parse(Console.ReadLine());
                if (!dictionary.ContainsKey(name))
                {
                    dictionary.Add(name, new List<double>());
                    dictionary[name].Add(rating);
                    dictionary[name].Add(1);
                }
                else
                {
                    dictionary[name][0] += rating;
                    dictionary[name][1]+=1;
                }
            }
            foreach(var dic in dictionary)
            {
                double average = dic.Value[0] / dic.Value[1];
                if (average >= 4.5)
                {
                    Console.WriteLine($"{dic.Key} -> {average:f2}");
                }
            }
        }
    }
}