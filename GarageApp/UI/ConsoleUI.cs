using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using GarageApp.Vehicles;

namespace GarageApp.UI
{
    internal class ConsoleUI : IConsoleUI
    {
        public void ShowMenu()
        {
            GarageHandler handler = new GarageHandler();
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("1. Create a garage");
                Console.WriteLine("2. Park vehicle");
                Console.WriteLine("3. Remove vehicle");
                Console.WriteLine("4. List vehicles");
                Console.WriteLine("5. Search Car by reg number");
                Console.WriteLine("6. List vehicle Type");
                Console.WriteLine("7. Exit");
                Console.Write("Choose one alternative: ");
                string choice = Console.ReadLine()!;

                try
                {
                    switch (choice)
                    {
                        case "1":
                            Console.Write("Give the capacity: ");
                            int capacity = int.Parse(Console.ReadLine()!);
                            handler.CreateGarage(capacity);
                            Console.WriteLine("Garage is created with the capacity of: " + capacity);
                            break;

                        case "2":
                            Console.Write("Select vehicle type (Airplane, Motorcycle, Car, Bus, Boat): ");
                            string type = Console.ReadLine()!;
                            Console.Write("Reg. number: ");
                            string regNum = Console.ReadLine()!.ToUpper();
                            Console.Write("color: ");
                            string color = Console.ReadLine()!;
                            Console.Write("number of wheels: ");
                            int wheels = int.Parse(Console.ReadLine()!);
                            Console.Write($"{handler.GetUniqueProperty(type)}: ");
                            string uniqueProperty = Console.ReadLine()!;

                            IVehicle vehicle = type switch
                            {
                                "Airplane" => new Airplane(regNum, color, wheels, Convert.ToInt32(uniqueProperty)),
                                "Motorcycle" => new Motorcycle(regNum, color, wheels, Convert.ToInt32(uniqueProperty)),
                                "Car" => new Car(regNum, color, wheels, "Gasoline"),
                                "Bus" => new Bus(regNum, color, wheels, Convert.ToInt32(uniqueProperty)),
                                "Boat" => new Boat(regNum, color, wheels, Convert.ToInt32(uniqueProperty)),
                                _ => throw new ArgumentException("Invalid vehicle type")
                            };

                            if (handler.ParkVehicle(vehicle))
                            {
                                Console.WriteLine("Vehicle parked!");
                            }
                            else
                            {
                                Console.WriteLine("vehicle cant be parked. try again");
                            }
                            break;

                        case "3":
                            Console.Write("enter the reg number of the Vehicle to remove: ");
                            string removeRegNum = Console.ReadLine()!;
                            if (handler.RemoveVehicle(removeRegNum))
                            {
                                Console.WriteLine("Vehicle removed!");
                            }
                            else
                            {
                                Console.WriteLine("Vehicle not found.");
                            }
                            break;

                        case "4":
                            var vehicles = handler.GetAllVehicles();
                            foreach (var v in vehicles)
                            {
                                Console.WriteLine(v.GetVehicleInfo());
                            }
                            break;

                        case "5":
                            Console.Write("Enter reg number: ");
                            string searchRegNum = Console.ReadLine()!;
                            var foundVehicle = handler.FindVehicle(searchRegNum);
                            if (foundVehicle != null)
                            {
                                Console.WriteLine(foundVehicle.GetVehicleInfo());
                            }
                            else
                            {
                                Console.WriteLine("Vehicle not found.");
                            }
                            break;

                        case "6":
                            var vehicleTypesCount = handler.GetVehicleTypesCount();
                            foreach (var kvp in vehicleTypesCount)
                            {
                                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
                            }
                            break;

                        case "7":
                            running = false;
                            break;

                        default:
                            Console.WriteLine("Wrong choice enter from 1-7.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("exception found: " + ex.Message);
                }

                Console.WriteLine("Press a key to continue .....");
                Console.ReadKey();
            }
        }
    }
}
