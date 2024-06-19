using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GarageApp.Vehicles;

namespace GarageApp
{
    public class Garage<T> : IEnumerable<T> where T : IVehicle
    {
        private T[] vehicles;
        private int capacity;
        private int count;

        public Garage(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentException("Capacity must be greater than zero");
            }

            this.capacity = capacity;
            vehicles = new T[capacity];
            count = 0;
        }

        public bool ParkVehicle(T vehicle)
        {
            if (count >= capacity)
            {
                throw new InvalidOperationException("Garage is full");
            }
            if (vehicles.Any(v => v?.RegistrationNumber == vehicle.RegistrationNumber))
            {
                throw new InvalidOperationException("Vehicle with the same registration number already exists");
            }


            vehicles[count++] = vehicle;
            return true;
        }

        public bool RemoveVehicle(string registrationNumber)
        {
            for (int i = 0; i < count; i++)
            {
                if (vehicles[i].RegistrationNumber.Equals(registrationNumber, StringComparison.OrdinalIgnoreCase))
                {
                    vehicles[i] = vehicles[--count];
                    vehicles[count] = default;
                    return true;
                }
            }
            return false;
        }

        public T FindVehicleByRegistration(string registrationNumber)
        {
            
            return vehicles.FirstOrDefault(v => v?.RegistrationNumber?.Equals(registrationNumber, StringComparison.OrdinalIgnoreCase) ?? false)!;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return vehicles[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}
