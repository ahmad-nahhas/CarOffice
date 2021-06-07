using CarOffice.Shared.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace CarOffice.Shared
{
    public class CarOfficeDbContext : IdentityDbContext
    {
        public CarOfficeDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            string[] brands = { "Acura", "Alfa Romeo", "Audi", "Bentley", "Buick", "BMW", "Cadillac", "Chevrolet", "Chrysler", "Dodge", "Fiat", "Ford", "GMC", "Genesis", "Honda", "Hyundai", "Infiniti", "Jaguar", "Jeep", "Kia", "Land Rover", "Lexus", "Lincoln", "Lotus", "Maserati", "Mazda", "Mercedes-Benz", "Mercury", "Mini", "Mitsubishi", "Nikola", "Nissan", "Polestar", "Pontiac", "Porsche", "Ram", "Rivian", "Rolls-Royce", "Saab", "Scion", "Smart", "Subaru", "Suzuki", "Tesla", "Toyota", "Volkswagen", "Volvo" };

            foreach (var brand in brands)
            {
                var id = Guid.NewGuid();

                builder.Entity<CarBrand>().HasData(new CarBrand { Id = id, Name = brand });

                builder.Entity<Car>().HasData(new Car
                {
                    Id = id,
                    BrandId = id,
                    Type = CarType.ForSale,
                    Status = CarStatus.New,
                    Gearbox = Gearbox.Automatic,
                    FuelType = FuelType.Petrol,
                    ShowInHome = true,
                    Price = 2500000000,
                    ModelYear = 2021,
                    Mileage = 100,
                    SeatCount = 6,
                    Color = "White",
                    WeightTotal = 5000,
                    Description = "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.",
                    CarExtras = "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights"
                });

                builder.Entity<CarImage>().HasData(new CarImage
                {
                    CarId = id,
                    Path = "product-1-720x480.jpg"
                }, new CarImage
                {
                    CarId = id,
                    Path = "product-2-720x480.jpg"
                }, new CarImage
                {
                    CarId = id,
                    Path = "product-3-720x480.jpg"
                }, new CarImage
                {
                    CarId = id,
                    Path = "product-4-720x480.jpg"
                }, new CarImage
                {
                    CarId = id,
                    Path = "product-5-720x480.jpg"
                }, new CarImage
                {
                    CarId = id,
                    Path = "product-6-720x480.jpg"
                });
            }

            base.OnModelCreating(builder);
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<CarBrand> Brands { get; set; }
        public DbSet<CarImage> Images { get; set; }
    }
}