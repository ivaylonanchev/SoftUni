using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace WordCount
{
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }
        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            var dic = new Dictionary<string, int>();
            using(var reader = new StreamReader(wordsFilePath))
            {
                dic.Add(reader.ReadLine(), 0);
            }
            using(var reader = new StreamReader(textFilePath))
            {
                string current = reader.ReadLine();
                if(dic.ContainsKey(current))
                {
                    dic[current] ++;
                }
            }
            dic.OrderBy(x => x.Value);
            using(var writer = new StreamWriter(outputFilePath))
            {
                foreach(var item in dic)
                {
                    writer.WriteLine($"{item.Key} - {item.Value}");
                }
            }
        }
    }
}


