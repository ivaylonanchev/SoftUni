namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.CompilerServices;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            var reportContent = TraverseDirectory(path);

            WriteReportToDesktop(reportContent, reportFileName);
        }
        public static Dictionary<string, List<FileInfo>> TraverseDirectory(string inputFolderPath)
        {
            Dictionary<string, List<FileInfo>> fileDictionary = new();

            string[] files = Directory.GetFiles(inputFolderPath);

            foreach (string file in files)
            {
                var info = new FileInfo(file);
                string extension = info.Extension;
                if (!fileDictionary.ContainsKey(extension))
                {
                    fileDictionary.Add(extension, new List<FileInfo>());
                }
                fileDictionary[extension].Add(info);
            }
            return fileDictionary;
        }
        public static void WriteReportToDesktop(Dictionary<string, List<FileInfo>> fileDictionary, string reportFileName)
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + reportFileName;
            using StreamWriter writer = new StreamWriter(path);

            foreach (var item in fileDictionary
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key))
            {
                writer.WriteLine($"{item.Key}");

                foreach (var file in item.Value.OrderBy(c => c.Length))
                {
                    writer.WriteLine($"--{file.Name} - {Math.Ceiling((double)file.Length / 1024)}kb");
                }
            }

        }
    }
}
