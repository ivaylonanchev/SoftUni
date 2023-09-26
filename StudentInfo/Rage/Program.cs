namespace Rage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int games = int.Parse(Console.ReadLine());
            double gm = Convert.ToDouble(games);
            double headset = double.Parse(Console.ReadLine());
            double mouse = double.Parse(Console.ReadLine());
            double keyboard = double.Parse(Console.ReadLine());
            double display = double.Parse(Console.ReadLine());
            double a = 0;
            if (games >= 2) 
            { 
                headset *= Math.Floor(gm / 2);
                a += headset;
            }
            if (games >= 3)
            {
                mouse *= Math.Floor(gm / 3);
                a += mouse;
            }
            if (games >= 6)
            {
                keyboard *= Math.Floor(gm / 6);
                a += keyboard;
            }
            if (games >= 12)
            {
                display *= Math.Floor(gm / 12);
                a += display;
            }
            Console.WriteLine($"Rage expenses: {a:F2} lv.");
        }
    }
}