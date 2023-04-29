using ShowRoom.Services.Classes;

namespace ShowRoom
{
    internal class Program
    {
        static void Main()
        {
            var _consoleService = new ConsoleService();
            _consoleService.ShowMenu();
        }
    }
}