using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GarageApp.Vehicles;

namespace GarageApp
{
    public class GarageHandler
    {
        private Garage<IVehicle> garage;

        public void CreateGarage(int capacity)
        {
            garage = new Garage<IVehicle>(capacity);
        }

        public bool ParkVehicle(IVehicle vehicle)
        {
            if (garage == null)
            {
                throw new InvalidOperationException("you have to create a garage to park");
            }
            return garage.ParkVehicle(vehicle);
        }

        public bool RemoveVehicle(string registrationNumber)
        {
            return garage.RemoveVehicle(registrationNumber);
        }

        public string GetUniqueProperty(string val)
        {
            switch (val)
            {
                case "Car":
                    return "Fuel Type";
                case "Bus":
                    return "Number Of Seats";
                case "Boat":
                    return "Lenght of the Boat";
                case "Airplane":
                    return "Number Of Engines";
                default:
                    return "";
            }
        }

        public IVehicle FindVehicle(string registrationNumber)
        {
            return garage.FindVehicleByRegistration(registrationNumber);
        }

        public IEnumerable<IVehicle> GetAllVehicles()
        {
            return garage.ToList();
        }

        public Dictionary<string, int> GetVehicleTypesCount()
        {
            return garage.GroupBy(v => v.GetType().Name)
                         .ToDictionary(g => g.Key, g => g.Count());
        }

    }

}