using System.Text.RegularExpressions;

namespace _01.MatchFullName
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string names = Console.ReadLine();
            string pattern = @"\b[A-Z][a-z]{1,} [A-Z][a-z]{1,}\b";

            MatchCollection matches = Regex.Matches(names, pattern);
            foreach (Match name in matches)
            {
                Console.Write(name.Value + " ");
            }

        }
    }
}