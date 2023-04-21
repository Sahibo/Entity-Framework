using ShowRoom.Data.Tables;

namespace ShowRoom.Services.Interfaces
{
    public interface ICarSalonService
    {
        List<CarSalon> GetAllCarSalons();
        CarSalon GetCarSalonById(int id);
        void AddCarSalon(CarSalon carSalon);
        void UpdateCarSalon(CarSalon carSalon);
        void DeleteCarSalon(int id);
    }
}
