using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApp.Vehicles
{
    internal class Motorcycle : Vehicle
    {
        public int CylinderVolume { get; private set; }

        public Motorcycle(string registrationNumber, string color, int numberOfWheels, int cylinderVolume)
            : base(registrationNumber, color, numberOfWheels)
        {
            if (cylinderVolume <= 0)
            {
                throw new ArgumentException("Cylinder volume must be greater than zero");
            }

            CylinderVolume = cylinderVolume;
        }

        public override string GetVehicleInfo()
        {
            return base.GetVehicleInfo() + $", Cylinder Volume: {CylinderVolume}";
        }
    }
}
