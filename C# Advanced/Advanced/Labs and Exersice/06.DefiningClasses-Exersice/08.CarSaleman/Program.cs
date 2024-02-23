using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.CarSaleman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Engine> engines = new List<Engine>();
            for (int i = 0; i < n; i++)
            {
                var eng = Console.ReadLine()
                    .Split(' ')
                    .ToArray();
                string model = eng[0];
                int power = int.Parse(eng[1]);

                var engine = new Engine
                {
                    EngineModel = model,
                    Power = power,
                };
                if (eng.Length == 3)
                {
                    if (char.IsDigit(eng[2][0]))
                    {
                        int displacement = int.Parse(eng[2]);
                        engine.Displacement = displacement;
                    }
                    else
                    {
                        string efficiency = eng[3];
                        engine.Efficiency = efficiency;
                    }
                }
                else if(eng.Length == 4)
                {
                    int displacement = int.Parse(eng[2]);
                    string efficiency = eng[3];

                    engine.Displacement = displacement;
                    engine.Efficiency = efficiency;
                }
                engines.Add(engine);
            }

            int m = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < m; i++)
            {
                var c = Console.ReadLine()
                    .Split(" ")
                    .ToArray();

                string model = c[0];
                string engineModel = c[1];
                Engine engine = new Engine();
                engine = engines.Single(x => x.EngineModel == engineModel);
                var car = new Car(model, engine);

                if (c.Length == 3)
                {
                    if (char.IsDigit(c[2][0]))
                    {
                        int weight = int.Parse(c[2]);
                        car.Weight = weight;
                    }
                    else
                    {
                        string color = c[2];
                        car.Color = color;
                    }
                }
                else if (c.Length == 4)
                {
                    int weight = int.Parse(c[2]);
                    string color = c[3];

                    car.Color = color;
                    car.Weight = weight;
                }
                cars.Add(car);
            }
            /*foreach(var car in cars)
            {
                Console.WriteLine(car.CarModel+ ":");
                Console.WriteLine($" {car.Engine.EngineModel}");
                Console.WriteLine($"  Power: {car.Engine.Power}");

                if (car.Engine.Displacement != null)
                {
                    Console.WriteLine($"  Displacement: {car.Engine.Displacement}");
                }
                else
                {
                    Console.WriteLine("  Displacement: n/a");
                }
                if(car.Engine.Efficiency != null)
                {
                    Console.WriteLine($"  Efficiency: {car.Engine.Efficiency}");
                }
                else
                {
                    Console.WriteLine("  Efficiency: n/a");
                }

                if (car.Weight != 0)
                {
                    Console.WriteLine($" Weight: {car.Weight}");
                }
                else
                {
                    Console.WriteLine(" Weight: n/a");
                }
                if (car.Color != null)
                {
                    Console.WriteLine($" Color: {car.Color}");
                }
                else
                {
                    Console.WriteLine(" Color: n/a");
                }
            }*/
            foreach(var car in cars)
            {
                Console.WriteLine(car);
            }

        }
    }
}
