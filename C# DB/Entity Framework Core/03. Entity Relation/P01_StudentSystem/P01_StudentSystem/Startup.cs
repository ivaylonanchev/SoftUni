using P01_StudentSystem.Data;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem
{
    using Data;
    using System.Text;
    public class StartUp
    {
        public static void Main()
        {
            StudentSystemContext context = new StudentSystemContext();
            Console.WriteLine("Hello, EF!");
        }
    }
}