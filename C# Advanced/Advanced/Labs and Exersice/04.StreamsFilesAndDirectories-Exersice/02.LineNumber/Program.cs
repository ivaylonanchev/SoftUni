using System;
using System.IO;
using System.Text;

namespace LineNumbers
{
    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\Files\text.txt";
            string outputFilePath = @"..\..\..\Files\output.txt";
            ProcessLines(inputFilePath, outputFilePath);
        }
        public static void ProcessLines(string inputFilePath, string outputFilePath) 
        {

            using(var reader = new StreamReader(inputFilePath))
            {
                using (var writer = new StreamWriter(outputFilePath))
                {
                    string currentLine = reader.ReadLine();
                    int letters = 0;
                    int marks = 0;
                    int line = 1;
                    while (currentLine != null)
                    {
                        foreach (char c in currentLine.ToCharArray())
                        {
                            if (Char.IsLetter(c))
                            {
                                letters++;
                            }
                            else if (Char.IsPunctuation(c))
                            {
                                marks++;
                            }
                        }
                        writer.WriteLine($"Line {line++}: {currentLine} ({letters})({marks})");
                        currentLine = reader.ReadLine();
                        letters = 0;
                        marks = 0;
                    }
                    
                }

            }
        }
    }
}
