using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.CarSaleman
{
    public class Car
    {
        public Engine Engine { get; set; }

        private string carModel;
        private int weight;
        private string color;

        public Car()
        {
            
        }
        public Car(string model, Engine engine)
        {
            this.carModel = model;
            this.Engine = engine; 
        }
        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine($"{this.CarModel}:");
            result.AppendLine($"{this.Engine.EngineModel}");

            if (this.Weight == 0)
            {
                result.AppendLine($"  Weight: n/a");
            }
            else
            {
                result.AppendLine($"  Weight: {this.Weight}");
            }

            if (this.Color == null)
            {
                result.Append($"  Color: n/a");
            }
            else
            {
                result.Append($"  Color: {this.Color}");
            }

            return result.ToString();
        }
        public string CarModel
        {
            get { return carModel; }
            set { carModel = value; }
        }
        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }
        public string Color
        {
            get { return color; }
            set { color = value; }
        }

    }
}
