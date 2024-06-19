using Xunit;
using GarageApp;
using GarageApp.Vehicles;
using System.Collections.Generic;
using System.Linq;

namespace G.Test
{
    public class Tests
    {
        [Fact]
        public void ParkVehicle_CapacityAvailable_VehicleParked()
        {
            // Arrange
            var garage = new Garage<IVehicle>(10);
            var car = new Car("ABC123", "Red", 4, "Gasoline");

            // Act
            var result = garage.ParkVehicle(car);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void RemoveVehicle_VehicleExists_VehicleRemoved()
        {
            // Arrange
            var garage = new Garage<IVehicle>(10);
            var car = new Car("ABC123", "Red", 4, "Gasoline");
            garage.ParkVehicle(car);

            // Act
            var result = garage.RemoveVehicle("ABC123");

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void FindVehicle_VehicleExists_VehicleFound()
        {
            // Arrange
            var garage = new Garage<IVehicle>(10);
            var car = new Car("ABC123", "Red", 4, "Gasoline");
            garage.ParkVehicle(car);

            // Act
            var result = garage.FindVehicleByRegistration("ABC123");

            // Assert
            Assert.NotNull(result);
            Assert.Equal("ABC123", result.RegistrationNumber);
        }
    }
}