using System;
using System.IO;

namespace OddLines
{
    public class OddLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\Files\input.txt";
            string outputFilePath = @"..\..\..\Files\output.txt";
            ExtractOddLines(inputFilePath, outputFilePath);
        }
        public static void ExtractOddLines(string input, string output)
        {
            int i = 0;
            using (StreamReader reader = new StreamReader(input))
            {
                using (StreamWriter writer = new StreamWriter(output))
                {
                    if (i % 2 == 0)
                    {
                        while (!reader.EndOfStream)
                        {
                            writer.WriteLine(reader.ReadLine());
                            Console.WriteLine(reader.ReadLine());
                        }
                    }
                    i++;
                }
            }
        }
    }
}
