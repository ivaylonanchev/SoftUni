using System.ComponentModel.Design;
using System.Threading.Channels;

namespace Problem1._1.ActivationKeys
{
    /*
abcdefghijklmnopqrstuvwxyz
Slice>>>2>>>6
Flip>>>Upper>>>3>>>14
Flip>>>Lower>>>5>>>7
Contains>>>def
Contains>>>deF 
Generate
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            string input;
            while ((input = Console.ReadLine()) != "Generate")
            {
                string[] arr = input.Split(">>>").ToArray();
                string command = arr[0].ToString();
                if (command == "Slice")
                {
                    int startIndex = int.Parse(arr[1].ToString());
                    int endIndex = int.Parse(arr[2].ToString());
                    word = word.Remove(startIndex, endIndex - startIndex);
                    Console.WriteLine(word);
                }
                else if (command == "Flip")
                {
                    string side = arr[1].ToString();
                    int startIndex = int.Parse(arr[2].ToString());
                    int endIndex = int.Parse(arr[3].ToString());
                    if (side == "Upper")
                    {
                        string a = word.Substring(startIndex, endIndex - startIndex);
                        word = word.Remove(startIndex, endIndex - startIndex);
                        a = a.ToUpper();
                        word = word.Insert(startIndex, a);
                    }
                    else if (side == "Lower")
                    {
                        string a = word.Substring(startIndex, endIndex - startIndex);
                        word = word.Remove(startIndex, endIndex - startIndex);
                        a = a.ToLower();
                        word = word.Insert(startIndex, a);
                    }
                    Console.WriteLine(word);
                }
                else if (command == "Contains")
                {
                    string toContain = arr[1].ToString();
                    if (word.Contains(toContain))
                    {
                        Console.WriteLine($"{word} contains {toContain}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                }
            }
            Console.WriteLine($"Your activation key is: {word}");
        }
    }
}