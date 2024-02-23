using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace _07.RawData
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < n; i++)
            {
                var arr = Console.ReadLine()
                    .Split(" ")
                    .ToArray();
                var engine = new Engine
                {
                    Speed = int.Parse(arr[1]),
                    Power = int.Parse(arr[2]),
                };
                var cargo = new Cargo
                {
                    Type = arr[4],
                    Weight = int.Parse(arr[3]),
                };
                var tire = new Tire[4]
                {
                    new Tire(double.Parse(arr[5]), int.Parse(arr[6])),
                    new Tire(double.Parse(arr[7]), int.Parse(arr[8])),
                    new Tire(double.Parse(arr[9]), int.Parse(arr[10])),
                    new Tire(double.Parse(arr[11]), int.Parse(arr[12])),
                };

                var car = new Car(arr[0], engine, cargo, tire);
                cars.Add(car);
            }

            string comm = Console.ReadLine();

            if (comm == "fragile")
            {
               cars = cars.Where(x => x.Cargo.Type == "fragile").Where(x=>x.Tire.Any(x1=>x1.Pressure<1)).ToList();
                foreach(var car in cars)
                {
                    Console.WriteLine(car.Model);
                }
            }
            else if (comm == "flammable")
            {
                cars = cars.Where(x => x.Cargo.Type == "flammable").Where(x => x.Engine.Power > 250).ToList();
                foreach (var car in cars)
                {
                    Console.WriteLine(car.Model);
                }
            }
        }
    }
}
