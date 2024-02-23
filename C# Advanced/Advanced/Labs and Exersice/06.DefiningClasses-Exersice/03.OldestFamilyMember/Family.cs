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
        public Person GetOldestMember()
        {
            var i = persons.OrderByDescending(x => x.Age);
            return i.FirstOrDefault();
        }
    }
}
