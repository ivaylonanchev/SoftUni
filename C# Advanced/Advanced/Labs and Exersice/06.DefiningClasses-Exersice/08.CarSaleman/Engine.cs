using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.CarSaleman
{
    public class Engine
    {
        private string engineModel;
        private int power;
        private int displacement;
        private string efficiency;

       
        public string EngineModel
        {
            get { return engineModel; }
            set { this.engineModel = value; }
        }
        public int Power
        {
            get { return power; }
            set { power = value; }
        }
        public int Displacement
        {
            get { return displacement; }
            set { displacement = value; }
        }
        public string Efficiency
        {
            get { return efficiency; }
            set { efficiency = value; }
        }


    }
}
