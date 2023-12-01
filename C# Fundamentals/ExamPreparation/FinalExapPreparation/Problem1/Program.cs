using Microsoft.Win32.SafeHandles;
using System.Diagnostics;
using System.Text;
using System.Threading.Channels;
using System.Linq;

namespace Problem1_
{
    /*
heVVodar!gniV
ChangeAll:|:V:|:l
Reverse:|:!gnil
InsertSpace:|:5
Reveal

Hiware?uiy
ChangeAll:|:i:|:o
Reverse:|:?uoy
Reverse:|:jd
InsertSpace:|:3
InsertSpace:|:7
Reveal
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string a;
            while ((a = Console.ReadLine()) != "Reveal")
            {
                string[] arr = a.Split(":|:");
                string command = arr[0];

                if (command == "InsertSpace")
                {
                    int index = int.Parse(arr[1]);
                    input = input.Insert(index, " ");
                }
                else if (command == "ChangeAll")
                {
                    string letter = arr[1];
                    string replacement = arr[2];
                    input = input.Replace(letter, replacement);
                }
                else if (command == "Reverse")
                {
                    string toReverse =  arr[1];
                    int toReverseIndex = input.IndexOf(toReverse);
                    if (toReverseIndex < 0)
                    {
                        Console.WriteLine("error");
                        continue;
                    }

                    input = input.Remove(toReverseIndex, toReverse.Length);
                    string reversed = new string(toReverse.Reverse().ToArray());
                    input += reversed;
                }
                
                Console.WriteLine(input);
            }
            Console.WriteLine("You have a new text message: " + input);
        }


    }
}