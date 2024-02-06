using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FilterByAge
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    /*
5
Lucas, 20
Tomas, 18
Mia, 29
Noah, 31
Simo, 16
older
20
name age
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Person> list = new List<Person>();
            for (int i = 0; i < n; i++)
            {
                var arr = Console.ReadLine()
                    .Split(", ")
                    .ToArray();
                var person = new Person()
                {
                    Name = arr[0],
                    Age = int.Parse(arr[1])
                }; 
                list.Add(person);    
            }

            string a = Console.ReadLine();
            int givenAge = int.Parse(Console.ReadLine());

            if(a == "older")
            {
                list = list.Where(c => c.Age >= givenAge).ToList();
            }
            else if(a == "younger")
            {

                list = list.Where(c => c.Age <= givenAge).ToList();
            }

            string final = Console.ReadLine();
            if(final == "name")
            {
                foreach (var person in list)
                {
                    Console.WriteLine(person.Name);
                }
            }
            else if(final == "age")
            {
                foreach (var person in list)
                {
                    Console.WriteLine(person.Age);
                }
            }
            else if(final == "name age")
            {
                foreach (var person in list)
                {
                    Console.WriteLine($"{person.Name} - {person.Age}");
                }
            }
        }
    }
}
