using Microsoft.EntityFrameworkCore;
using ShowRoom.Data.Tables;
using ShowRoom.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowRoom.Services.Classes
{
    public class ConsoleService
    {
        private readonly ICarService _carService;

        //Menu
        public void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Show all cars");
                Console.WriteLine("2. Add a car");
                Console.WriteLine("3. Edit a car");
                Console.WriteLine("4. Delete a car");
                Console.WriteLine("5. Exit");

                int result = Int32.Parse(Console.ReadLine());

                switch (result)
                {
                    case 1:
                        ShowAllCars();
                        break;
                    case 2:
                        ShowAddCar();
                        break;
                    case 3:
                        ShowEditCar();
                        break;
                    case 4:
                        ShowDeleteCar();
                        break;
                    case 5:
                        Console.WriteLine("Mercedes > BMW");
                        return;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }

                Console.WriteLine();
            }
        }


        //Car
        public void ShowAllCars()
        {
            var cars = _carService?.GetAllCars();
            if (cars != null)
            {
                foreach (var car in cars)
                {
                    Console.WriteLine($"Make: {car.Make}, Model: {car.Model}, Year: {car.Year}, Price: {car.Price}");
                }
            }
        }

        public void ShowAddCar()
        {
            Console.WriteLine("Enter the make of the car:");
            var make = Console.ReadLine();

            Console.WriteLine("Enter the model of the car:");
            var model = Console.ReadLine();

            Console.WriteLine("Enter the year of the car:");
            var year = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the price of the car:");
            var price = decimal.Parse(Console.ReadLine());

            var car = new Car
            {
                Make = make,
                Model = model,
                Year = year,
                Price = price
            };

            _carService.AddCar(car);

            Console.WriteLine("Car added successfully!");
        }

        public void ShowEditCar()
        {
            Console.WriteLine("Enter the ID of the car you want to edit: ");
            var id = int.Parse(Console.ReadLine());

            var car = _carService.GetCarById(id);

            if (car == null)
            {
                Console.WriteLine($"Car with ID: {id} not found!");
                return;
            }

            Console.WriteLine($"Editing car with ID {car.Id}");
            Console.WriteLine($"Current make: {car.Make}");
            Console.WriteLine($"Enter new make (leave blank to keep current value): ");

            var make = Console.ReadLine();
            if (!string.IsNullOrEmpty(make))
            {
                car.Make = make;
            }

            Console.WriteLine($"Current model: {car.Model}");
            Console.WriteLine($"Enter new model (leave blank to keep current value):");
            var model = Console.ReadLine();
            if (!string.IsNullOrEmpty(model))
            {
                car.Model = model;
            }

            Console.WriteLine($"Current year: {car.Year}");
            Console.WriteLine($"Enter new year (leave blank to keep current value):");
            var yearString = Console.ReadLine();
            if (!string.IsNullOrEmpty(yearString))
            {
                var year = int.Parse(yearString);
                car.Year = year;
            }

            Console.WriteLine($"Current price: {car.Price}");
            Console.WriteLine($"Enter new price (leave blank to keep current value):");
            var priceString = Console.ReadLine();
            if (!string.IsNullOrEmpty(priceString))
            {
                var price = decimal.Parse(priceString);
                car.Price = price;
            }

            _carService.UpdateCar(car);

            Console.WriteLine($"Car with ID {car.Id} updated successfully!");
        }

        public void ShowDeleteCar()
        {
            Console.WriteLine("Enter the ID of the car you want to delete:");
            var id = int.Parse(Console.ReadLine());

            var car = _carService.GetCarById(id);

            if (car == null)
            {
                Console.WriteLine($"Car with ID {id} not found!");
                return;
            }

            _carService.DeleteCar(id);

            Console.WriteLine($"Car with ID {id} deleted successfully!");
        }
    }
}
