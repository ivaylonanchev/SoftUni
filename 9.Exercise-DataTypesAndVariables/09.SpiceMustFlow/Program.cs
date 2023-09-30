namespace _9.SpiceMustFlow
{
    internal class Program
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            int sum = 0;
            int timesRun = 0;
            while (num >= 100)
            {
                sum += num - 26;
                num = num - 10;
                timesRun++;
            }
            sum -= 26;
            if (sum < 0) sum= 0;
            Console.WriteLine(timesRun);
            Console.WriteLine(sum);
        }
    }
}