namespace CopyBinaryFile
{
    using System;
    using System.IO;

    public class CopyBinaryFile
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\Files\copyMe.png";
            string outputFilePath = @"..\..\..\Files\copyMe-copy.png";
            CopyFile(inputFilePath, outputFilePath);
        }
        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            using (var inputStream = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read))
            {
                using (var outputStream = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write))
                {
                    byte[] buffer = new byte[4096];
                    int bytesRead = 0;

                    while ((bytesRead = inputStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        outputStream.Write(buffer, 0, bytesRead);
                    }
                }
            }
        }
    }
}
