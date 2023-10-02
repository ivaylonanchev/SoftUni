namespace _06.EqualSums
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            int sumLeft = 0;
            int sumRight = 0;
            int n = 0;
            for (int i = 1; i < numbers.Length; i++)
            {
                for (int j = 0; j < numbers.Length; j++)
                {
                    if (j < i)
                    {
                        sumLeft += numbers[j];
                    }
                    else if (j > i)
                    {
                        sumRight += numbers[j];
                    }
                }
                if (sumLeft == sumRight)
                {
                    Console.WriteLine(i);
                    return;
                }
                else
                {
                    sumLeft = 0;
                    sumRight = 0;
                }
            }
            if (numbers.Length == 1) 
            { 
                Console.WriteLine("0"); 
                return;
            }
            Console.WriteLine("no");
        }
    }
}