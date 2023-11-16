namespace _05.AddAndSubtract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());

            int result = Add(firstNum, secondNum);
            Console.WriteLine(Subtract(result, thirdNum));
        }
        static int Add(int first, int second)
        {
            return first + second;
        }
        static int Subtract(int result, int third)
        {
            return result - third;
        }
    }
}