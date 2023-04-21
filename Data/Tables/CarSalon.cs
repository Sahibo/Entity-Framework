namespace ShowRoom.Data.Tables
{
    public class CarSalon
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<Car> Cars { get; set; }
    }
}
