using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace _07.RawData
{
    public class Car
    {
        private string model;
        public Engine Engine;
        public Cargo Cargo;
        public Tire[] Tire;

        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public Car(string model, Engine engine, Cargo cargo, Tire[] tire)
        {
            this.model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.Tire = tire;
        }

    }
    public class Engine
    {
        private int speed;
        private int power;

        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        public int Power
        {
            get { return power; }
            set { power = value; }
        }
    }
    public class Cargo
    {
        private string type;
        private double weight;

        public string Type
        {
            get { return type; }
            set { type = value; }   
        }
        public double Weight
        {
            get { return weight; }
            set { weight = value; }
        }
    }
    public class Tire
    {
        private int age;
        private double pressure;

        public int Age
        {
            get { return age; }
            set { age = value;}
        }
        public double Pressure
        {
            get { return pressure; }
            set { pressure = value; }
        }
        public Tire(double pressure, int age)
        {
            this.Pressure = pressure;
            this.Age = age;
        }
    }
}
