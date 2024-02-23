using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class Family : Person
    {
        Person person;
        private List<Person> persons = new List<Person>();

       

        public void AddMember(Person member)
        {
            persons.Add(member);
        }
        public void GetNames()
        {
            var i = persons.OrderBy(x => x.Name).Where(x=>x.Age>30);
            foreach(var person in i)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
