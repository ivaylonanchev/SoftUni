namespace DefiningClasses
{
    public class Person
    {
        private string name;
        private int age;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public Person()
        {
            name = "No name";
            age = 1;
        }
        public Person(int age) : this()
        {
            this.age = age;
        }
        public Person(int age, string name) :this()
        {
            this.name = name;
            this.age = age;
        }
    }
}
