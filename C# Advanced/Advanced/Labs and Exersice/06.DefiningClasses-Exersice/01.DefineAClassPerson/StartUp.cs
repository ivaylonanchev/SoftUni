using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var first = new Person();

            int secondAge = int.Parse(Console.ReadLine());
            var second = new Person(secondAge);

            int thirdAge = int.Parse(Console.ReadLine());
            string thirdName = Console.ReadLine();
            var third = new Person(thirdAge, thirdName);
        }
    }
}
