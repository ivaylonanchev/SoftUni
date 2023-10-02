using System.Diagnostics.Metrics;
using System.Runtime.ExceptionServices;

namespace _08.EqualElements
{
    internal class Program
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            int number = 0;
            int count = 1;
            int maxCount = 1;
            for (int i = 0; i < numbers.Length-1; i++)
            {
                if (numbers[i] > numbers[i + 1])
                {
                    count++;
                    if (count > maxCount)
                    {
                        maxCount = count;
                        number = numbers[i];
                    }
                }
                else count = 1;
            }

            int[] finalNumbers = new int[maxCount];
            for (int i = 0; i < finalNumbers.Length; i++)
            {
                finalNumbers[i] = number;
            }
            Console.Write(string.Join(" ", finalNumbers));
        }
    }
}