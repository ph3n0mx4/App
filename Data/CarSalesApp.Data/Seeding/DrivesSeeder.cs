using CarSalesApp.Data.Models;
using CarSalesApp.Data.Models.Enums;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CarSalesApp.Data.Seeding
{
    public class DrivesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Drives.Any())
            {
                return;
            }

            await dbContext.Drives.AddAsync(
                new Drive { ModelId = 1, Displacement = 1686, Gear = 5, Power = 75, GearType = (GearType)Enum.Parse(typeof(GearType), "Manual"), Fuel = (FuelType)Enum.Parse(typeof(FuelType), "Petrol") });
        }
    }
}
