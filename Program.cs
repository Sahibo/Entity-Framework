using Microsoft.Extensions.DependencyInjection;
using ShowRoom.Data.DbContext;
using ShowRoom.Services.Classes;
using ShowRoom.Services.Interfaces;

namespace ShowRoom
{
    internal class Program
    {
        static void Main()
        {
            //// configure the service collection
            //var services = new ServiceCollection();
            //services.AddScoped<ICarService, CarService>();
            //services.AddScoped<ConsoleService>();

            //// create an instance of ConsoleService using the service provider
            //var serviceProvider = services.BuildServiceProvider();
            //var consoleService = serviceProvider.GetService<ConsoleService>();

            //consoleService.ShowMenu();
            private readonly ShowRoomContext _db = new ShowRoomContext();
            private readonly CarService _service = new CarService(_db);

            ICarService obj = new CarService(_db);

            obj.GetAllCars();
        }
    }
}