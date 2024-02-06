namespace EvenLines
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\Files\text.txt";
            Console.WriteLine(ProcessLines(inputFilePath));
        }
        public static string ProcessLines(string inputFilePath)
        {
            int a = 0;
            var sb = new StringBuilder();
            using(var reader = new StreamReader(inputFilePath))
            {
                string current = reader.ReadLine();
                while(current != null)
                {
                    if (a % 2 == 0)
                    {
                        string replacedLine = Replace(current);
                        
                        var reversed = replacedLine
                            .Split()
                            .Reverse()
                            .ToArray();
                        sb.AppendLine(string.Join(' ', reversed));
                    }
                    a++;
                    current = reader.ReadLine();
                }
            }
            return sb.ToString();
        }
        public static string Replace(string line)
        {
            return line.Replace("-", "@")
                        .Replace(",", "@")
                        .Replace(".", "@")
                        .Replace("!", "@")
                        .Replace("?", "@");
        }
    }
}
