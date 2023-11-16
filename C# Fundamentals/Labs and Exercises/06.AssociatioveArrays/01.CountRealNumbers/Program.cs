namespace _01.CountRealNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine()
                .Split(" ")
                .Select(double.Parse)
                .ToList();
            SortedDictionary<double, int> result = new SortedDictionary<double, int>();
            for (int i = 0; i < numbers.Count; i++)
            {
                if (result.ContainsKey(numbers[i]))
                {
                    result[numbers[i]]++;
                }
                else
                {
                    result[numbers[i]] = 1;
                }
            }
            foreach (var res in result)
            {
                Console.WriteLine(res.Key + " -> " + res.Value);
            }
        }
    }
}