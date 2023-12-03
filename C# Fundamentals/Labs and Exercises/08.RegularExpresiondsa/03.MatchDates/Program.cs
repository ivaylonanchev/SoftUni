using System.Text.RegularExpressions;
using System.Xml.Schema;

namespace _03.MatchDates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"\b(?<day>\d{2})([\.\-\/])(?<month>[A-Z][a-z]{2})\1(?<year>\d{4})\b";

            MatchCollection matches = Regex.Matches(input, pattern);
            foreach (Match match in matches)
            {
                var day = match.Groups["day"].Value;
                var month = match.Groups["month"].Value;
                var year = match.Groups["year"].Value;
                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
            }
        }
    }
}