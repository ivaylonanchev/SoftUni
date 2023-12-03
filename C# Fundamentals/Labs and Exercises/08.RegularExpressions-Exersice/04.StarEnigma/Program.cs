using System.Text;
using System.Text.RegularExpressions;

namespace _04.StarEnigma
{
    class Planet
    {
        public string Name { get; set; }
        public uint Population { get; set; }
        public string AttackType { get; set; }
        public uint SoldierCount { get; set; }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string keyPattern = @"[SsAaTtRr]";
            string mainPattern = @"\@(?<name>[A-Za-z]+)[^\@\-\>\!\:]*:(?<population>\d+)[^\@\-\>\!\:]*\!(?<attackType>A|D)\![^\@\-\>\!\:]*\-\>(?<count>\d+)";
            List<Planet> planets = new List<Planet>();

            for (int i = 0; i < number; i++)
            {

                string input = Console.ReadLine();
                string newInput = CharacterMover(keyPattern, input);
                Match match = Regex.Match(newInput, mainPattern);
                if(!Regex.IsMatch(newInput, mainPattern))
                {
                    continue;
                }
                Planet planet = new Planet()
                {
                    Name = match.Groups["name"].Value,
                    Population = uint.Parse(match.Groups["population"].Value),
                    AttackType = match.Groups["attackType"].Value,
                    SoldierCount = uint.Parse(match.Groups["count"].Value),
                };
                planets.Add(planet);
                

            }
            var planetFilter = planets
                .Where(m =>m.AttackType=="A")
                .OrderBy(m=>m.Name)
                .ToList();

            Console.WriteLine("Attacked planets: " + planetFilter.Count);
            planetFilter.ForEach(m => Console.WriteLine("-> " + m.Name));

            planetFilter = planets
               .Where(m => m.AttackType == "D")
               .OrderBy(m => m.Name)
               .ToList();

            Console.WriteLine("Destroyed planets: " + planetFilter.Count);
            planetFilter.ForEach(m => Console.WriteLine("-> " + m.Name));

        }
        static string CharacterMover(string keyPattern, string input)
        {
            int key = Regex.Matches(input, keyPattern).Count;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                sb.Append((char)(input[i] - key));
            }
            string newString = sb.ToString();
            return newString;
        }
    }
}