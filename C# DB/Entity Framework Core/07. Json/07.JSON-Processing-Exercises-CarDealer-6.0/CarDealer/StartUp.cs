using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Migrations;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext context = new CarDealerContext();

            //string  carsText = File.ReadAllText("../../../Datasets/parts.json");
            //var user = JsonConvert.DeserializeObject<List<Part>>(carsText);
            //context.Parts.AddRange(user);
            //context.SaveChanges();

        }
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var text = JsonConvert.DeserializeObject<List<Supplier>>(inputJson);

            context.Suppliers.AddRange(text);
            context.SaveChanges();

            return $"Successfully imported {text.Count}.";
        }
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var parts = JsonConvert.DeserializeObject<List<Part>>(inputJson);

            var validSupplierIds = context.Suppliers
                .Select(x => x.Id)
                .ToArray();

            var partsWithValidSupplierIds = parts
                .Where(p => validSupplierIds.Contains(p.SupplierId))
                .ToArray();

            context.Parts.AddRange(partsWithValidSupplierIds);
            context.SaveChanges();

            return $"Successfully imported {partsWithValidSupplierIds.Length}.";
        }
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carsDtos = JsonConvert.DeserializeObject<List<ImportCarDto>>(inputJson);

            var cars = new HashSet<Car>();
            var partsCars = new HashSet<PartCar>();

            foreach (var carDto in carsDtos)
            {
                var newCar = new Car()
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TraveledDistance = carDto.TraveledDistance
                };

                cars.Add(newCar);
                foreach (var partId in carDto.PartsId.Distinct())
                {
                    partsCars.Add(new PartCar()
                    {
                        Car = newCar,
                        PartId = partId
                    });
                }
            }
            context.Cars.AddRange(cars);
            context.PartsCars.AddRange(partsCars);

            context.SaveChanges();

            return $"Successfully imported {cars.Count}.";
        }
    }
}