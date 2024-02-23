using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.SpeedRacing
{/*
2
AudiA4 23 0.3
BMW-M2 45 0.42
Drive BMW-M2 56
Drive AudiA4 5
Drive AudiA4 13
End

3
AudiA4 18 0.34
BMW-M2 33 0.41
Ferrari-488Spider 50 0.47
Drive Ferrari-488Spider 97
Drive Ferrari-488Spider 35 
Drive AudiA4 85 
Drive AudiA4 50
End
  */
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < n; i++)
            {
                var arr = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                var car = new Car
                {
                    Model = arr[0],
                    FuelAmount = double.Parse(arr[1]),
                    FuelConsumptionPerKilometer = double.Parse(arr[2]),

                };
                cars.Add(car);
            }
            string comm;
            while ((comm = Console.ReadLine()) != "End")
            {
                var arr = comm
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string name = arr[1];
                double km = double.Parse(arr[2]);
                if (arr[0] == "Drive")
                {
                    foreach (var car in cars)
                    {
                        if (car.Model == name)
                        {
                            car.Drive(km);
                        }
                    }
                }
            }
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}
