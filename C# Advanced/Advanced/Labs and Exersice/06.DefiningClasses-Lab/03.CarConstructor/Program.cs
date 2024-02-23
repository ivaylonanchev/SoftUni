using System;

namespace CarManufacturer
{
    public class StartUp
    {
        public static void Main()
        {
            var car = new Car("Mazda", "6", 2025, 200, 10);

            Console.WriteLine(car.WhoImI());
        }
    }
}
