using System.Globalization;
using System.Runtime.ExceptionServices;

namespace _04.Student
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>();
            for (int i = 0; i < n; i++)
            {
                string[] a = Console.ReadLine().Split(" ").ToArray();
                string firstName = a[0];
                string lastName = a[1];
                string b = a[2];
                double grade = double.Parse(b);
                Student student = new Student()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Grade = grade
                };
                students.Add(student);
            }
            students = students.OrderBy(c=>c.Grade).ToList();
            students.Reverse();
            foreach (Student student in students)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}: {student.Grade:f2}");
            }
        }
    }
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }
    }
}