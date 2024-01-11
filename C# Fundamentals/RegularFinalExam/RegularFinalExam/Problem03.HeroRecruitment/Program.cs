using System.Runtime.InteropServices;

namespace Problem03.HeroRecruitment
{
    /*
Enroll Stefan
Enroll Peter
Enroll Stefan
Learn Stefan ItShouldWork
Learn John ItShouldNotWork
Unlearn George Dispel
Unlearn Stefan ItShouldWork
End

Enroll Stefan
Enroll Peter
Enroll John
Learn Stefan Spell
Learn Peter Dispel
End
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            List<Hero> heroes = new List<Hero>();
            while ((input = Console.ReadLine()) != "End")
            {
                string[] arr = input.Split(" ").ToArray();
                string command = arr[0].ToString();
                string heroName = arr[1].ToString();
                if (command == "Enroll")
                {
                    int num = 0;
                    foreach (Hero hero in heroes)
                    {
                        if (hero.Name == heroName)
                        {
                            num++;
                            break;
                        }
                    }
                    if (num > 0)
                    {
                        Console.WriteLine(heroName + " is already enrolled.");
                    }
                    else
                    {
                        Hero hero = new Hero()
                        {
                            Name = heroName,
                            SpellName = new List<string>(),
                    };
                        heroes.Add(hero);
                    }
                }
                else if (command == "Learn")
                {
                    string spell = arr[2].ToString();
                    int num = 0;
                    foreach (Hero hero in heroes)
                    {
                        if (hero.Name == heroName)
                        {
                            int n = 0;
                            if (hero.SpellName == null)
                            {
                                hero.SpellName.Add(spell);
                            }
                            else
                            {
                                int count = hero.SpellName.Count;
                                for (int k = 0; k < hero.SpellName.Count; k++)
                                {
                                    if (hero.SpellName[k] == spell)
                                    {
                                        n++;
                                        break;
                                    }
                                }
                                if (n == 0)
                                {
                                    hero.SpellName.Add(spell);
                                }
                                else
                                {
                                    Console.WriteLine($"{hero.Name} has already learnt {spell}");
                                }
                                num++;
                                break;
                            }
                        }
                    }
                    if (num == 0)
                    {
                        Console.WriteLine(heroName + " doesn't exist.");
                    }
                }
                else if(command == "Unlearn")
                {
                    string spell = arr[2].ToString();
                    int num = 0;
                    foreach (Hero hero in heroes)
                    {
                        if (hero.Name == heroName)
                        {
                            int n = 0;
                            if (hero.SpellName.Count == 0)
                            {
                                Console.WriteLine($"{hero.Name} doesn't know {spell}");
                            }
                            else
                            {
                                for (int k = 0; k < hero.SpellName.Count; k++)
                                {
                                    if (hero.SpellName[k] == spell)
                                    {
                                        n++;
                                        break;
                                    }
                                }
                                if (n > 0)
                                {
                                    hero.SpellName.Remove(spell);
                                }
                                else
                                {
                                    Console.WriteLine($"{hero.Name} doesn't know {spell}");
                                }
                                num++;
                                break;
                            }
                        }
                    }
                    if (num == 0)
                    {
                        Console.WriteLine(heroName + " doesn't exist.");
                    }

                }
            }
            Console.WriteLine("Heroes:");
            foreach (Hero hero in heroes)
            {
                Console.Write("== " + hero.Name + ": ");
                Console.Write(string.Join(", ", hero.SpellName));
                Console.WriteLine();
            }
        }
    }
    class Hero
    {
        public string Name { get; set; }
        public List<string> SpellName { get; set; }
        public Hero()
        {
            SpellName = new List<string>();
        }
    }
}