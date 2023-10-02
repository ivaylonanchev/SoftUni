namespace _05.TopIntegers   
{
    internal class Program
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse) 
                .ToArray();
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i+1;j<numbers.Length; j++)
                {
                    if (numbers[i] <= numbers[j])
                    {
                        numbers[i] = default;
                        break;
                    }
                }
            }
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i]!=0) Console.Write(numbers[i]+ " ");
            }
            if (numbers[numbers.Length-1]==0) Console.WriteLine("0");
        }
    }
}