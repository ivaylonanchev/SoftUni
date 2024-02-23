using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization.Formatters;

namespace _09.PredicateParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            string command;

            Func<string, int, bool> byLenght = (x, y) => x.Length == y;
            Func<string, string, bool> startsWith = (x, starts) =>
            {
                bool isItTrue = true;
                for (int i = 0; i < starts.Length; i++)
                {
                    if (x[i] == starts[i])
                    {
                        continue;
                    }
                    else
                    {
                        isItTrue = false;
                        break;
                    }
                }
                return isItTrue;
            };

            while ((command = Console.ReadLine()) != "Party!")
            {
                var commands = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string first = commands[0].ToString();
                string second = commands[1].ToString();
                string word = commands[2].ToString();


                Func<string, bool> predicate = GetPredicate(second, word);
                switch (first)
                {
                    case "Remove":
                        names = Remove(names, predicate);
                        break;
                    case "Double":
                        names = Double(names, predicate); 
                        break;
                }

                
            }
            Console.WriteLine(names.Any()
                    ? $"{string.Join(", ", names)} are going to the party!"
                    : "Nobody is going to the party!"
                    );
        }

        private static Func<string, bool> GetPredicate(string command, string s)
        {
            if (command == "StartsWith")
            {
                return c => c.StartsWith(s);
            }
            else if (command == "EndsWith")
            {
                return c => c.EndsWith(s);
            }
            else if (command == "Length")
            {
                return c => c.Length == int.Parse(s);
            }
            return default;
        }

        static List<string> Double(List<string> guestsList, Func<string, bool> predicate)
        {
            List<string> result = new List<string>();
            foreach (string s in guestsList)
            {
                if (predicate(s))
                {
                    result.Add(s);
                }
                result.Add(s);
            }

            return result;
        }
        static List<string> Remove(List<string> guestsList, Func<string, bool> predicate)
        {

            guestsList = guestsList.Where(x => predicate(x) == false).ToList();
            return guestsList;
        }
    }
}
