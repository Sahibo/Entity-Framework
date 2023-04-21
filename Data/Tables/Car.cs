namespace ShowRoom.Data.Tables
{
    public class Car
    {
        public int Id { get; set; }
        public string Make { get; set; } = null!;
        public string Model { get; set; } = null!;
        public int Year { get; set; }
        public decimal Price { get; set; }

        public int CarSalonId { get; set; }
        public CarSalon CarSalon { get; set; }
    }
}
