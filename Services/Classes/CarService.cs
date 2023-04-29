using ShowRoom.Data.DbContext;
using ShowRoom.Data.Tables;

namespace ShowRoom.Services.Classes
{
    public class CarService
    {
        private readonly ShowRoomContext _dbContext;
        public CarService(ShowRoomContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Car> GetAllCars()
        {
            return _dbContext.Set<Car>().ToList();
        }

        public Car GetCarById(int id)
        {
            return _dbContext.Set<Car>().FirstOrDefault(x => x.Id == id);
        }

        public void AddCar(Car car)
        {
            _dbContext.Set<Car>().Add(car);
            _dbContext.SaveChanges();
        }

        public void UpdateCar(Car car)
        {
            _dbContext.Set<Car>().Update(car);
            _dbContext.SaveChanges();
        }

        public void DeleteCar(int id)
        {
            var car = _dbContext.Set<Car>().FirstOrDefault(x => x.Id == id);
            if (car != null)
            {
                _dbContext.Set<Car>().Remove(car);
                _dbContext.SaveChanges();
            }
        }
    }
}
