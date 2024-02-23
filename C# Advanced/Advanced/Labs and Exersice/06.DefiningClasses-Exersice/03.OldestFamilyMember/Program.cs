using System;
using System.Linq;

namespace DefiningClasses
{
    public class Program
    {
        static void Main(string[] args)
        {
            var family = new Family();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var arr = Console.ReadLine()
                   .Split(" ")
                   .ToArray();
                var person = new Person
                {
                    Name = arr[0],
                    Age = int.Parse(arr[1]),
                };
                family.AddMember(person);
            }
            var oldestPerson = family.GetOldestMember();
            Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");
        }
    }
}
