using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApp.Vehicles
{
    public class Car : Vehicle
    {
        public string FuelType { get; private set; }

        public Car(string registrationNumber, string color, int numberOfWheels, string fuelType)
            : base(registrationNumber, color, numberOfWheels)
        {
            if (string.IsNullOrWhiteSpace(fuelType))
            {
                throw new ArgumentException("Fuel type cannot be empty");
            }

            FuelType = fuelType;
        }

        public override string GetVehicleInfo()
        {
            return base.GetVehicleInfo() + $", Fuel: {FuelType}";
        }
    }
}

