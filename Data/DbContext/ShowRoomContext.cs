using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShowRoom.Data.Tables;

namespace ShowRoom.Data.DbContext
{
    public class ShowRoomContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarSalon> CarSalons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ConfigurationBuilder builder = new();

            builder.AddJsonFile("appsettings.json");

            IConfigurationRoot config = builder.Build();

            var connectionString = config.GetConnectionString("ShowRoom");

            optionsBuilder.UseSqlServer(connectionString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Make).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Model).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Year).IsRequired();
                entity.Property(e => e.Price).IsRequired().HasColumnType("decimal(18,2)");

                entity.HasOne(cs => cs.CarSalon).WithMany(c => c.Cars)
                    .HasForeignKey(cs => cs.CarSalonId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<CarSalon>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
            });
        }

    }
}
