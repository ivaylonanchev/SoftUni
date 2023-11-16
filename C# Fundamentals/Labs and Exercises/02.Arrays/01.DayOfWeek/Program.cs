namespace _01.DayOfWeek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            string[] b = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"};
            if(a<=0 || a>b.Length-1) Console.WriteLine("Invalid day!");
            else Console.WriteLine(b[a-1]);
        }
    }
}