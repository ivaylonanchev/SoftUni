namespace _11.SnowBalls
{
    internal class Program
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            double ValueAll = 0;
            int snow = 0;
            int time = 0;
            int quality = 0;
            for (int i = 0; i < number; i++)
            {
                double snowballValue;
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());
                snowballValue = Math.Pow((snowballSnow / snowballTime),  snowballQuality);
                if (snowballValue > ValueAll)
                {
                    ValueAll = snowballValue;
                    snow = snowballSnow;
                    time = snowballTime;
                    quality = snowballQuality;
                }
            }
            Console.WriteLine($"{snow} : {time} = {ValueAll} ({quality})");
        }
    }
}