namespace _08.FactorialDivision
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            long firstFactorial = Factorial(firstNumber);
            long secondFactorial = Factorial(secondNumber);

            double finalNumber = (double)firstFactorial / secondFactorial;
            Console.WriteLine($"{finalNumber:f2}");

        }
        static long Factorial(int number)
        {
            long factorial = 1;
            for (int i = 2; i <= number; i++)
            {
                factorial *= i;
            }
            return factorial;
        }
    }
}