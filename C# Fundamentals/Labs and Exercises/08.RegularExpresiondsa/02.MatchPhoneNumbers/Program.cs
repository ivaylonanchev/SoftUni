using System.Text.RegularExpressions;

namespace _02.MatchPhoneNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"\+(\d{3})([\-\ ])(\d{1})\2(\d{3})\2(\d{4})(?=,| |$)";


            MatchCollection match = Regex.Matches(input, pattern);
            Console.Write(string.Join(", ",match));

        }
    }
}