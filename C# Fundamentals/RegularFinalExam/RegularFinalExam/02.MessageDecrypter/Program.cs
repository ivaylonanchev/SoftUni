using System.Text;
using System.Text.RegularExpressions;

namespace _02.MessageDecrypter
{
    /*
4
$Request$: [73]|[115]|[105]|
%Taggy$: [73]|[73]|[73]|
%Taggy%: [118]|[97]|[108]|
$Request$: [73]|[115]|[105]|[32]|[75]|
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            string pattern = @"(?<!.)([\$\%])(?<name>[A-Z]{1}[a-z]{2,})(\1): (\[(?<number1>[0-9]+)\]\|)(\[(?<number2>[0-9]+)\]\|)(\[(?<number3>[0-9]+)\]\|)(?!\[|[A-z])";
            for (int i = 0; i < num; i++)
            {
                string word = Console.ReadLine();
                List<int> list = new List<int>();
                string name = "";
                foreach (Match match in Regex.Matches(word, pattern))
                {
                    list.Add(int.Parse(match.Groups["number1"].Value));
                    list.Add(int.Parse(match.Groups["number2"].Value));
                    list.Add(int.Parse(match.Groups["number3"].Value));
                    name = match.Groups["name"].Value;
                }
                StringBuilder stringBuilder = new StringBuilder();
                for (int j = 0; j < list.Count; j++)
                {
                    char symbol = Convert.ToChar(list[j]);
                    stringBuilder.Append(symbol);
                }
                if (list.Count > 1)
                {
                    Console.WriteLine($"{name}: {stringBuilder}");
                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }
            }
        }
    }
}