namespace _05.BombNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();
            List<int> powers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();
            int number = powers[0];
            int power = powers[1];

            Bomb(numbers, number, power);

        }
        static void Bomb(List<int> numbers, int number, int power)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == number)
                {
                    int m = i;
                    for (int j = power; j > 0; j--)
                    {
                        if (m > 0)
                        {
                            numbers.RemoveAt(m - 1);
                            m--;
                            i--;
                        }
                    }
                    for (int j = 0; j < power; j++)
                    {
                        if (m < numbers.Count - 1)
                        {
                            numbers.RemoveAt(m + 1);
                            
                        }
                        m++;
                    }
                    numbers.RemoveAt(i);
                    i--;
                }
            }
            Console.WriteLine(numbers.Sum());
        }
    }
}