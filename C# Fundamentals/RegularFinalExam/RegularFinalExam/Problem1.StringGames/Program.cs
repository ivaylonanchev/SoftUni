using System.Runtime.Serialization;

namespace Problem1.StringGames
{
    internal class Program
    {
        /*
//Th1s 1s my str1ng!//
Change 1 i
Includes string
End my
Uppercase
FindIndex I
Cut 5 5
Done

*S0ftUni is the B3St Plac3**
Change 2 o
Includes best
End is
Uppercase
FindIndex P
Cut 3 7
Done
        */
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            string input;
            while ((input = Console.ReadLine()) != "Done")
            {
                string[] arr = input.Split(" ").ToArray();
                string command = arr[0].ToString();
                if(command == "Change")
                {
                    string letter = arr[1].ToString();
                    string replacment = arr[2].ToString();
                    word = word.Replace(letter, replacment);
                    Console.WriteLine(word);
                }
                else if (command == "Includes")
                {
                    string substring = arr[1].ToString();
                    if(word.Contains(substring))
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }
                else if (command == "End")
                {
                    string substring = arr[1].ToString();
                    int subLenght = substring.Length-1; 
                    int num = 0;
                    for(int i = word.Length - 1; i > word.Length - substring.Length; i--)
                    {
                        if (word[i] != substring[subLenght])
                        {
                            num++;
                            break;
                        }
                        subLenght--;
                    }
                    if(num > 0)
                    {
                        Console.WriteLine("False");
                    }
                    else
                    {
                        Console.WriteLine("True");
                    }
                }
                else if(command == "Uppercase")
                {
                    word = word.ToUpper();
                    Console.WriteLine(word);
                }
                else if (command == "FindIndex")
                {
                    string find = arr[1].ToString();
                    foreach(char c in find)
                    {
                        if(c.ToString() == find)
                        {
                            Console.WriteLine(word.IndexOf(c));
                        }
                    }
                }
                else if (command == "Cut")
                {
                    int startIndex = int.Parse(arr[1].ToString());
                    int count = int.Parse((string)arr[2].ToString());
                    string cut = "";
                    cut = word.Substring(startIndex, count);
                    Console.WriteLine(cut);
                }
            }
        }
    }
}