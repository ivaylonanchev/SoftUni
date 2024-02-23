using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.SpeedRacing
{
    public class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumptionPerKilometer;
        private double travelledDistance;

        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public double FuelAmount
        {
            get { return fuelAmount; }
            set { fuelAmount = value; }
        }
        public double FuelConsumptionPerKilometer
        {
            get { return fuelConsumptionPerKilometer; }
            set { fuelConsumptionPerKilometer = value; }
        }
        public double TravelledDistance
        {
            get { return travelledDistance; }
            set { travelledDistance = value; }
        }
        public void Drive(double km)
        {
            if (fuelConsumptionPerKilometer * km <= fuelAmount)
            {
                double distance = fuelConsumptionPerKilometer * km;
                fuelAmount -= distance;
                travelledDistance += km;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
