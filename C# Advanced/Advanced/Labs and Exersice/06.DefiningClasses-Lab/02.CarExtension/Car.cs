﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManufacturer
{
    class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;

        public Car()
        {
            
        }
        public string Make
        {
            get
            {
                return this.make;
            }
            set
            {
                this.make = value;
            }
        }
        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                this.model = value;
            }
        }
        public int Year
        {
            get
            {
                return this.year;
            }
            set
            {
                this.year = value;
            }
        }
        public double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }
            set
            {
                this.fuelQuantity = value;
            }
        }
        public double FuelConsumption
        {
            get
            {
                return this.fuelConsumption;
            }
            set
            {
                this.fuelConsumption = value;
            }
        }
        public void Drive(double distance)
        {
            if (FuelQuantity - (distance * FuelConsumption) > 0)
            {
                FuelQuantity-= distance * FuelConsumption;
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }
        public string WhoImI()
        {
            return ($"Make: {this.Make} \nModel: { this.Model} \nYear: { this.Year} \nFuel: { this.FuelQuantity:F2} ");
        }
    }
}
