namespace Padawan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double saber = double.Parse(Console.ReadLine());
            double robe = double.Parse(Console.ReadLine());
            double belt = double.Parse(Console.ReadLine());

            saber = saber*Math.Ceiling(students*1.1);
            double st = Convert.ToDouble(students);

            belt = belt * (students - (Math.Floor(st / 6))); 
            
            robe = robe * students;
            double a = saber+belt+robe ;

            if(money-a>=0) Console.WriteLine($"The money is enough - it would cost {a:F2}lv.");
            else Console.WriteLine("John will need {0:F2}lv more.",a-money );

        }
    }
}