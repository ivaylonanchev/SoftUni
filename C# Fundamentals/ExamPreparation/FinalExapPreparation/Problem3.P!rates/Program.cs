namespace Problem3.P_rates
{
    class Ship
    {
        public string City { get; set; }
        public int Population { get; set; }
        public int Gold { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Ship> ships = new List<Ship>();
            string input;
            while ((input = Console.ReadLine()) != "Sail")
            {
                string[] arr = input.Split("||").ToArray();
                string city = arr[0].ToString();
                int population = int.Parse(arr[1].ToString());
                int gold = int.Parse(arr[2].ToString());
                Ship ship = new Ship()
                {
                    City = city,
                    Population = population,
                    Gold = gold
                };
                ships.Add(ship);
            }
            while((input = Console.ReadLine()) != "End")
            {
                string[] arr = input.Split("=>").ToArray();
                string command = arr[0].ToString();
                string city = arr[1].ToString();
                if (command == "Plunder")
                {
                    int peopleToKill = int.Parse(arr[2].ToString());
                    int goldToTake = int.Parse(arr[3].ToString());
                }
                else if (command == "Prosper")
                {
                    int goldToTake = int.Parse((string)arr[2].ToString());
                }
            }
        }
    }
}