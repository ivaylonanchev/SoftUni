namespace Problem1.GuineaPig
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double food = double.Parse(Console.ReadLine());
            double hay = double.Parse(Console.ReadLine());
            double cover = double.Parse(Console.ReadLine());
            double pigWeight = double.Parse(Console.ReadLine());
            food *= 1000;
            hay *= 1000; 
            cover*= 1000;
            pigWeight *= 1000;

            for (int i = 1; i <= 30; i++)
            {
                food -= 300;
                if (i % 2 == 0)
                {
                    hay -= food * 0.05;
                }
                if (i % 3 == 0)
                {
                    cover -= Math.Round(pigWeight / 3);
                }
                if (food < 0 || cover < 0 || hay < 0)
                {
                    Console.WriteLine("Merry must go to the pet store!");
                    break;
                }
            }
            if (food > 0 && hay > 0 && cover > 0)
            {
                food /= 1000;
                hay /= 1000;
                cover /= 1000;
                Console.WriteLine($"Everything is fine! Puppy is happy! Food: {food:f2}, Hay: {hay:f2}, Cover: {cover:f2}.");
            }
        }
    }
}