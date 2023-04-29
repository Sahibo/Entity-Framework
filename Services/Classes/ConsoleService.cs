using ShowRoom.Data.DbContext;
using ShowRoom.Data.Tables;


namespace ShowRoom.Services.Classes
{
    public class ConsoleService
    {
        private readonly CarService _carService;
        private readonly CarSalonService _carSalonService;

        public ConsoleService()
        {
            var dbContext = new ShowRoomContext();
            _carService = new CarService(dbContext);
            _carSalonService = new CarSalonService(dbContext);
        }
        //Menu
        public void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("Select an option");
                Console.WriteLine();

                Console.WriteLine("Cars options:");
                Console.WriteLine("1. Show all cars");
                Console.WriteLine("2. Add a car");
                Console.WriteLine("3. Edit a car");
                Console.WriteLine("4. Delete a car");

                Console.WriteLine();

                Console.WriteLine("ShowRooms options:");
                Console.WriteLine("5. Show all showrooms");
                Console.WriteLine("6. Add a showroom");
                Console.WriteLine("7. Edit a showroom");
                Console.WriteLine("8. Delete a showroom");

                Console.WriteLine();

                Console.WriteLine("9. Exit");
                Console.WriteLine("0. Clean");

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
                        ShowAllCarSalons();
                        break;
                    case 6:
                        ShowAddCarSalon();
                        break;
                    case 7:
                        ShowEditCarSalon();
                        break;
                    case 8:
                        ShowDeleteCarSalon();
                        break;

                    case 9:
                        Console.WriteLine("Mercedes > BMW");
                        return;
                    case 0:
                        Console.Clear();
                        break;
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
            List<Car> cars = _carService.GetAllCars();

            if (cars != null)
            {
                foreach (var car in cars)
                {
                    Console.WriteLine($"ID: {car.Id}, Make: {car.Make}, Model: {car.Model}, Year: {car.Year}, Price: {car.Price}");
                }
            }
        }

        public void ShowAddCar()
        {
            Console.Write("Enter the showroom ID: ");
            var showroomid = int.Parse(Console.ReadLine());

            Console.Write("Enter the make of the car: ");
            var make = Console.ReadLine();

            Console.Write("Enter the model of the car: ");
            var model = Console.ReadLine();

            Console.Write("Enter the year of the car: ");
            var year = int.Parse(Console.ReadLine());

            Console.Write("Enter the price of the car: ");
            var price = decimal.Parse(Console.ReadLine());

            var car = new Car
            {
                CarSalonId = showroomid,
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
            Console.Write("Enter new make (leave blank to keep current value): ");

            var make = Console.ReadLine();
            if (!string.IsNullOrEmpty(make))
            {
                car.Make = make;
            }

            Console.WriteLine($"Current model: {car.Model}");
            Console.Write("Enter new model (leave blank to keep current value): ");
            var model = Console.ReadLine();

            if (!string.IsNullOrEmpty(model))
            {
                car.Model = model;
            }

            Console.WriteLine($"Current year: {car.Year}");
            Console.Write("Enter new year (leave blank to keep current value): ");
            var yearString = Console.ReadLine();

            if (!string.IsNullOrEmpty(yearString))
            {
                var year = int.Parse(yearString);
                car.Year = year;
            }

            Console.WriteLine($"Current price: {car.Price}");
            Console.Write("Enter new price (leave blank to keep current value): ");
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
            Console.Write("Enter the ID of the car you want to delete:");
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

        //CarSalon

        public void ShowAllCarSalons()
        {
            List<CarSalon> carsalons = _carSalonService.GetAllCarSalons();

            if (carsalons != null)
            {
                foreach (var carsalon in carsalons)
                {
                    Console.WriteLine($"ID: {carsalon.Id}, Name: {carsalon.Name}, Count of cars: {carsalon.Cars.Count}");
                }
            }
        }

        public void ShowAddCarSalon()
        {
            Console.Write("Enter the name of the showroom: ");
            var name = Console.ReadLine();

            var carsalon = new CarSalon
            {
                Name = name,
            };

            _carSalonService.AddCarSalon(carsalon);

            Console.WriteLine("Showroom added successfully!");
        }

        public void ShowEditCarSalon()
        {
            Console.WriteLine("Enter the ID of the showroom you want to edit: ");
            var id = int.Parse(Console.ReadLine());

            var carsalon = _carSalonService.GetCarSalonById(id);

            if (carsalon == null)
            {
                Console.WriteLine($"Showroom with ID: {id} not found!");
                return;
            }

            Console.WriteLine($"Editing Showroom with ID {carsalon.Id}");
            Console.WriteLine($"Current name: {carsalon.Name}");
            Console.Write("Enter new name (leave blank to keep current value): ");

            var name = Console.ReadLine();

            if (!string.IsNullOrEmpty(name))
            {
                carsalon.Name = name;
            }


            _carSalonService.UpdateCarSalon(carsalon);

            Console.WriteLine($"Showroom with ID {carsalon.Id} updated successfully!");
        }

        public void ShowDeleteCarSalon()
        {
            Console.Write("Enter the ID of the showroom you want to delete:");
            var id = int.Parse(Console.ReadLine());

            var carsalon = _carSalonService.GetCarSalonById(id);

            if (carsalon == null)
            {
                Console.WriteLine($"Showroom with ID {id} not found!");
                return;
            }

            _carSalonService.DeleteCarSalon(id);

            Console.WriteLine($"Showroom with ID {id} deleted successfully!");
        }

    }
}
