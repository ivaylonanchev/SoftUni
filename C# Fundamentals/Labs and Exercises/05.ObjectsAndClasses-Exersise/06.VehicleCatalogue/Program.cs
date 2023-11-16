namespace _06.VehicleCatalogue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Catalogue catalogue = new Catalogue();
            while (input != "End")
            {
                string[] arr = input.Split(" ").ToArray();
                string typeOfVehicle = arr[0];
                string model = arr[1];
                string color = arr[2];
                string a = arr[3];
                int horsePower = int.Parse(a);

                Vehicle vehicle = new Vehicle()
                {
                    Type = typeOfVehicle,
                    Model = model,
                    Color = color,
                    HorsePower = horsePower
                };
                catalogue.Vehicles.Add(vehicle);
                input = Console.ReadLine();
            }

            double truckAverageHP = 0;
            int truckCount = 0;
            double carAverageHP = 0;
            int carCount = 0;

            string typeInput = Console.ReadLine();
            while (typeInput != "Close the Catalogue")
            {
                foreach (Vehicle vehicle in catalogue.Vehicles)
                {
                    if (vehicle.Model == typeInput)
                    {
                        if (vehicle.Type == "truck")
                        {
                            vehicle.Type = "Truck";
                        }
                        if (vehicle.Type == "car")
                        {
                            vehicle.Type = "Car";
                        }
                        Console.WriteLine("Type: " + vehicle.Type);
                        Console.WriteLine("Model: " + vehicle.Model);
                        Console.WriteLine("Color: " + vehicle.Color);
                        Console.WriteLine("Horsepower: " + vehicle.HorsePower);

                    }
                }
                typeInput = Console.ReadLine();
            }
            foreach (Vehicle vehicle in catalogue.Vehicles)
            {
                if (vehicle.Type == "car" || vehicle.Type == "Car")
                {
                    carAverageHP += vehicle.HorsePower;
                    carCount++;
                }
                else if (vehicle.Type == "truck" || vehicle.Type == "Truck")
                {
                    truckAverageHP += vehicle.HorsePower;
                    truckCount++;
                }
            }

            truckAverageHP /= truckCount;
            carAverageHP /= carCount;
            if (carCount > 0)
            {
                Console.WriteLine($"Cars have average horsepower of: {carAverageHP:f2}.");
            }
            else
            {
                Console.WriteLine($"Cars have average horsepower of: {0:f2}.");
            }
            if (truckCount > 0)
            {
                Console.WriteLine($"Trucks have average horsepower of: {truckAverageHP:f2}.");
            }
            else
            {
                Console.WriteLine($"Trucks have average horsepower of: {0:f2}.");
            }
        }
    }
    class Vehicle
    {
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int HorsePower { get; set; }

    }
    class Catalogue
    {
        public List<Vehicle> Vehicles = new List<Vehicle>();
        public Catalogue()
        {
            Vehicles = new();
        }
    }
}