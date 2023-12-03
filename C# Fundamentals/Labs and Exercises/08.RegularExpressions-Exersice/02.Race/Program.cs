using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace _02.Race
{
    /*
    
Ivan, Peter, James, Kyle
I4v@43an%66?77!!@
G1@!3u$s445s6@
B3@i@#245ll
I&v54a%66n@
7P%et^#e5346r
J$a553m&e6s
K2y3=l/^e23
end of race

     */
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine()
                .Split(", ")
                .ToList();
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            foreach (string str in list)
            {
                dictionary.Add(str, 0);
            }
            string input = Console.ReadLine();
            string patternNumber = @"[0-9]";
            string patternLetter = @"[A-Za-z]+";
            while (input != "end of race")
            {
                string name = "";
                int km = 0;
                foreach (Match match in Regex.Matches(input, patternLetter))//Imeto
                {
                    name = name + match.Value;
                }
                foreach (Match match in Regex.Matches(input, patternNumber))//Kilometrite
                {
                    km += int.Parse(match.Value);
                }

                if (dictionary.ContainsKey(name))
                {
                    dictionary[name] += km;
                }
                input = Console.ReadLine();
            }
            dictionary = dictionary.OrderByDescending(c=>c.Value).ToDictionary(c => c.Key, c=>c.Value);

            int n = 0;
            foreach (var dic in dictionary)
            {
                if(n==0)
                {
                    Console.WriteLine("1st place: " + dic.Key);
                }
                else if(n==1)
                {
                    Console.WriteLine("2nd place: " + dic.Key);
                }
                else if (n==2)
                {
                    Console.WriteLine("3rd place: " + dic.Key);
                    break;
                }
                n++;
            }
        }
    }
}