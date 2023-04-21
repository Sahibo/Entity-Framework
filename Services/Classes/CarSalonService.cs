using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShowRoom.Data.DbContext;
using ShowRoom.Data.Tables;
using ShowRoom.Services.Interfaces;

namespace ShowRoom.Services.Classes
{
    public class CarSalonService : ICarSalonService
    {
        private readonly ShowRoomContext _dbContext;

        public CarSalonService(ShowRoomContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<CarSalon> GetAllCarSalons()
        {
            return _dbContext.Set<CarSalon>().Include(x => x.Cars).ToList();
        }

        public CarSalon GetCarSalonById(int id)
        {
            return _dbContext.Set<CarSalon>().Include(x => x.Cars).FirstOrDefault(x => x.Id == id);
        }

        public void AddCarSalon(CarSalon carSalon)
        {
            _dbContext.Set<CarSalon>().Add(carSalon);
            _dbContext.SaveChanges();
        }

        public void UpdateCarSalon(CarSalon carSalon)
        {
            _dbContext.Set<CarSalon>().Update(carSalon);
            _dbContext.SaveChanges();
        }

        public void DeleteCarSalon(int id)
        {
            var carSalon = _dbContext.Set<CarSalon>().FirstOrDefault(x => x.Id == id);
        }
    }
}
