using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApp.Vehicles
{
    internal class Bus : Vehicle
    {
        public int NumberOfSeats { get; private set; }

        public Bus(string registrationNumber, string color, int numberOfWheels, int numberOfSeats)
            : base(registrationNumber, color, numberOfWheels)
        {
            if (numberOfSeats <= 0)
            {
                throw new ArgumentException("Number of seats must be greater than zero");
            }

            NumberOfSeats = numberOfSeats;
        }

        public override string GetVehicleInfo()
        {
            return base.GetVehicleInfo() + $", Seats: {NumberOfSeats}";
        }
    }

}
