using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GarageApp.Vehicles;

namespace GarageApp
{
    public interface IGarageHandler
    {
        public void CreateGarage(int capacity);
        bool ParkVehicle(IVehicle vehicle);
        string GetUniqueProperty(string val);
        bool RemoveVehicle(string registrationNumber);
        IVehicle FindVehicle(string registrationNumber);

        IEnumerable<IVehicle> GetAllVehicles();
        Dictionary<string, int> GetVehicleTypesCount();

    }
}

