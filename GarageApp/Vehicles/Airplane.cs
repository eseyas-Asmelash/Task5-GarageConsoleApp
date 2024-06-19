using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApp.Vehicles
{
    internal class Airplane : Vehicle
    {
        public int NumberOfEngines { get; private set; }

        public Airplane(string registrationNumber, string color, int numberOfWheels, int numberOfEngines)
            : base(registrationNumber, color, numberOfWheels)
        {
            if (numberOfEngines <= 0)
            {
                throw new ArgumentException("Number of engines must be greater than zero");
            }

            NumberOfEngines = numberOfEngines;
        }

        public override string GetVehicleInfo()
        {
            return base.GetVehicleInfo() + $", Engines: {NumberOfEngines}";
        }
    }

}
