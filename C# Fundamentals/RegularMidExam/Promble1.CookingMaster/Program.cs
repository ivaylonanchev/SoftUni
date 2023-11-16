namespace Promble1.CookingMaster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budjet = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double flour = double.Parse(Console.ReadLine());
            double egg = double.Parse(Console.ReadLine());
            double apron = double.Parse(Console.ReadLine());
            double all = 0;

            apron *=(students+ (int)Math.Ceiling(0.2 * students));
            double freeflour = 0;
            if (students >= 5)
            {
                freeflour = (int)students / 5;
                flour *=(students-freeflour) ;
            }
            else
            {
                flour *= students;
            }
            egg *= 10*students;

            all = flour + egg + apron;
            if (budjet >= all)
            {
                Console.WriteLine($"Items purchased for {all:f2}$.");
            }
            else
            {
                Console.WriteLine($"{all-budjet:f2}$ more needed.");
            }
        }
    }
}