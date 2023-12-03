namespace Problem3.P_rates
{
    class Ship
    {
        /*
Tortuga||345000||1250
Santo Domingo||240000||630
Havana||410000||1100
Sail
Plunder=>Tortuga=>75000=>380
Prosper=>Santo Domingo=>180
End

Nassau||95000||1000
San Juan||930000||1250
Campeche||270000||690
Port Royal||320000||1000
Port Royal||100000||2000
Sail
Prosper=>Port Royal=>-200
Plunder=>Nassau=>94000=>750
Plunder=>Nassau=>1000=>150
Plunder=>Campeche=>150000=>690
End
         */
        public string City { get; set; }
        public int Population { get; set; }
        public int Gold { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Ship> ships = new List<Ship>();
            string input = "";
            while ((input = Console.ReadLine()) != "Sail")
            {
                string[] arr = input.Split("||").ToArray();
                string city = arr[0].ToString();
                int population = int.Parse(arr[1].ToString());
                int gold = int.Parse(arr[2].ToString());
                int check = 0;
                foreach (Ship s in ships)
                {
                    if (s.City == city)
                    {
                        s.Population += population;
                        s.Gold += gold;
                        check++;
                    }
                }
                if (check == 0)
                {
                    Ship ship = new Ship()
                    {
                        City = city,
                        Population = population,
                        Gold = gold
                    };

                    ships.Add(ship);
                }
            }
            while ((input = Console.ReadLine()) != "End")
            {
                string[] arr = input.Split("=>").ToArray();
                string command = arr[0].ToString();
                string city = arr[1].ToString();
                if (command == "Plunder")
                {
                    int peopleToKill = int.Parse(arr[2].ToString());
                    int goldToTake = int.Parse(arr[3].ToString());
                    foreach (Ship s in ships)
                    {
                        if (s.City == city)
                        {
                            s.Population -= peopleToKill;
                            s.Gold -= goldToTake;
                            Console.WriteLine($"{s.City} plundered! {goldToTake} gold stolen, {peopleToKill} citizens killed.");
                            if (s.Population <= 0 || s.Gold <= 0)
                            {
                                Console.WriteLine($"{s.City} has been wiped off the map!");
                                ships.Remove(s);
                                break;
                            }
                        }
                    }
                }
                else if (command == "Prosper")
                {
                    int goldToAdd = int.Parse((string)arr[2].ToString());
                    foreach (Ship s in ships)
                    {
                        if (s.City == city)
                        {
                            if (goldToAdd <= 0)
                            {
                                Console.WriteLine("Gold added cannot be a negative number!");
                            }
                            else
                            {
                                s.Gold += goldToAdd;
                                Console.WriteLine($"{goldToAdd} gold added to the city treasury. {s.City} now has {s.Gold} gold.");
                            }
                        }
                    }
                }
            }
            if (ships.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {ships.Count} wealthy settlements to go to:");
                foreach (Ship s in ships)
                {
                    Console.WriteLine($"{s.City} -> Population: {s.Population} citizens, Gold: {s.Gold} kg");
                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }
    }
}