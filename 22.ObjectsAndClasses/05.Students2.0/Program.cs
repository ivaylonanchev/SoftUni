namespace _05.Students2._0
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
                if (IsStudentExist(std, firstName, lastName, age, homeTown))
                {
                    IsStudentExist(std, firstName, lastName, age, homeTown);
                }
                else
                {
                    Student student = new Student()
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Age = age,
                        HomeTown = homeTown
                    };
                    std.Add(student);
                }
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
        static bool IsStudentExist(List<Student> students, string firstName, string lastName, int age, string homeTown)
        {
            foreach (Student student in students)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    student.Age = age;
                    student.HomeTown = homeTown;
                    return true;
                }
            }
            return false;
        }
    }
    class Student
    {
        public Student()
        {

        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string HomeTown { get; set; }
    }
}