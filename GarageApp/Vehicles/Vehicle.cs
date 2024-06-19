using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApp.Vehicles
{

    public class Vehicle : IVehicle
    {
        public string RegistrationNumber { get; private set; }
        public string Color { get; private set; }
        public int NumberOfWheels { get; private set; }

        public Vehicle(string registrationNumber, string color, int numberOfWheels)
        {
            if (string.IsNullOrWhiteSpace(registrationNumber))
            {
                throw new ArgumentException("Registration number cannot be empty");
            }
            if (numberOfWheels <= 0)
            {
                throw new ArgumentException("Number of wheels must be greater than zero");
            }

            RegistrationNumber = registrationNumber;
            Color = color;
            NumberOfWheels = numberOfWheels;
        }

        public virtual string GetVehicleInfo()
        {
            return $"{GetType().Name} [RegNo: {RegistrationNumber}, Color: {Color}, Wheels: {NumberOfWheels}]";
        }
    }


}
