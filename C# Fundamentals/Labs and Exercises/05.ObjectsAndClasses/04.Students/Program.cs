using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;

namespace _04.Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string names = Console.ReadLine();
            List<Student> std = new List<Student>();
            while (names != "end")
            {
                string[] list = names.Split(' ').ToArray();
                string firstName = list[0];
                string lastName = list[1];
                string a = list[2];
                int age = int.Parse(a);
                string homeTown = list[3];

                Student student = new Student(firstName, lastName, age, homeTown);
                std.Add(student);
                names = Console.ReadLine();
            }
            string city = Console.ReadLine();

            for (int i = 0; i < std.Count; i++)
            {
                Student currentStudent = std[i];
                if (city == currentStudent.HomeTown)
                {
                    Console.WriteLine($"{currentStudent.FirstName} {currentStudent.LastName} is {currentStudent.Age} years old.");
                }
            }
        }
    }
    class Student
    {
        public Student()
        {
            
        }
        public Student(string firstName, string lastName, int age, string homeTown)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            HomeTown = homeTown;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string HomeTown { get; set; }
    }
}