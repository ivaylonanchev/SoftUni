using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.PartyReservationFilterModule
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            var names2 = names.ToList();
            string a;
            var currentNames = names.ToList();
            while ((a = Console.ReadLine()) != "Print")
            {
                names2 = names.ToList();
                var arr = a.Split(";").ToList();
                string typeFilter = arr[0].ToString();
                string filter = arr[1];
                string lether = arr[2];

                Func<string, bool> predicate = GetPredicate(filter, lether);
                switch (typeFilter)
                {
                    case "Add filter":
                        currentNames = AddFilter(currentNames, names2, predicate);
                        break;
                    case "Remove filter":
                        currentNames = RemoveFilter(currentNames, names2, predicate);
                        break;
                }


            }
            Console.WriteLine(string.Join(" ",currentNames));
        }
        private static Func<string, bool> GetPredicate(string command, string s)
        {
            if (command == "Starts with")
            {
                return c => c.StartsWith(s);
            }
            else if (command == "Ends with")
            {
                return c => c.EndsWith(s);
            }
            else if (command == "Length")
            {
                return c => c.Length == int.Parse(s);
            }
            else if (command == "Contains")
            {
                return c => c.Contains(s);
            }
            return default;
        }
        static List<string> AddFilter(List<string> current, List<string> namesList, Func<string, bool> predicate)
        {

            var toRemvoe = namesList.Where(predicate).ToList();
            foreach (var item in toRemvoe)
            {
                current.Remove(item);
            }

            return current;
        }
        static List<string> RemoveFilter(List<string> current,List<string> list, Func<string, bool> predicate)
        {
            var now = list.Where(predicate).ToList();
            foreach (string c in current)
            {
                now.Add(c);
            }
            var list2 = list.ToList();
            foreach(var item in list2)
            {
                if (!now.Contains(item))
                {
                    list.Remove(item);
                }
            }

            return list;
        }
        