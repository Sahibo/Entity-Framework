using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowRoom.DbContext.Tables
{
    public class CarSalon
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<Car> Cars { get; set; }
    }
}
