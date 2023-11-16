using System.Reflection;

namespace _07.VehicleCatalogue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string information = Console.ReadLine();
            Catalogue catalogue = new Catalogue();
            
            while (information != "end")
            {
                string[] arr = information.Split('/').ToArray();
                string type = arr[0];
                string brand = arr[1];
                string model = arr[2];
                string a = arr[3];
                if (type == "Car")
                {
                    int horsePower = int.Parse(a);
                    Car car = new Car(brand, model, horsePower);
                    catalogue.Cars.Add(car);
                }
                else if(type == "Truck")
                {
                    int weight = int.Parse(a);
                    Truck truck = new Truck(brand, model, weight);
                    catalogue.Trucks.Add(truck);
                }
                information = Console.ReadLine();
            }
            catalogue.Cars = catalogue.Cars.OrderBy(c => c.Brand).ToList();
            catalogue.Trucks = catalogue.Trucks.OrderBy(c => c.Brand).ToList();
            if (catalogue.Cars.Count > 0)
            {
                Console.WriteLine("Cars:");
                foreach (Car car in catalogue.Cars)
                {
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                }
            }
            if(catalogue.Trucks.Count > 0)
            {
                Console.WriteLine("Trucks:");
                foreach (Truck truck in catalogue.Trucks)
                {
                    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                }
            }
        }
    }
    class Car
    {
        public Car()
        {
            
        }
        public Car(string brand, string model, int horsePower)
        {
            Brand = brand;
            Model = model;
            HorsePower = horsePower;
        }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }

    }
    class Truck
    {
        public Truck()
        {
            
        }
        public Truck(string brand, string model, int weight)
        {
            Brand = brand;
            Model = model;
            Weight = weight;
        }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Weight { get; set; }

    }
    class Catalogue
    {
        public List<Car> Cars { get; set; }
        public List<Truck> Trucks { get; set; }
        public Catalogue()
        {
            Cars = new();
            Trucks = new();
        }

    }
}