namespace _03.MergingLists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<double> firstNumbers = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .ToList();
            List<double> secondNumbers = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .ToList();
            List<double> final = new List<double>();
            int count;
            int index ;
            if (firstNumbers.Count > secondNumbers.Count)
            {
                count = secondNumbers.Count;
                index = 1;
                for (int i = 0; i < count; i++)
                {
                    firstNumbers.Insert(index, secondNumbers[0]);
                    secondNumbers.RemoveAt(0);
                    index += 2;
                }
                Console.WriteLine(string.Join(" ", firstNumbers));
            }
            else
            {
                index = 0;
                count = firstNumbers.Count;
                for (int i = 0; i < count; i++)
                {
                    secondNumbers.Insert(index, firstNumbers[0]);
                    firstNumbers.RemoveAt(0);
                    index += 2;
                }
                Console.WriteLine(string.Join(" ", secondNumbers));
            }
        }
    }
}