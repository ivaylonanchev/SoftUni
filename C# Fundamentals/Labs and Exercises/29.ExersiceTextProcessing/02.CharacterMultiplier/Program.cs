using System.Reflection.Metadata.Ecma335;

namespace _02.CharacterMultiplier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine().Split(" ").ToArray();
            int sum = 0;
            Multyplayer(arr[0], arr[1], sum);
        }
        static void Multyplayer(string first, string second, int sum)
        {

            if (first.Length > second.Length)
            {
                for (int i = 0; i < second.Length; i++)
                {
                    sum += first[i] * second[i];
                }
                for (int i = first.Length-1; i >= second.Length; i--)
                {
                    sum += first[i];
                }
            }
            else if(second.Length > first.Length)
            {
                for (int i = 0; i < first.Length; i++)
                {
                    sum += first[i] * second[i];
                }
                for (int i = second.Length-1; i >= first.Length; i--)
                {
                    sum+= second[i];
                }
            }
            else
            {
                for (int i = 0; i < first.Length; i++)
                {
                    sum += first[i] * second[i];
                }
            }
            Console.WriteLine(sum);
        }
    }
}