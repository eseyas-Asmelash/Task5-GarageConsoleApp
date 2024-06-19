using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApp.Vehicles
{
    internal class Boat : Vehicle
    {
        public int Length { get; private set; }

        public Boat(string registrationNumber, string color, int numberOfWheels, int length)
            : base(registrationNumber, color, numberOfWheels)
        {
            if (length <= 0)
            {
                throw new ArgumentException("Length must be greater than zero");
            }

            Length = length;
        }

        public override string GetVehicleInfo()
        {
            return base.GetVehicleInfo() + $", Length: {Length}";
        }
    }
}
