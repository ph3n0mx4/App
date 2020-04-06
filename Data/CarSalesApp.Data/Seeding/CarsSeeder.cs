using CarSalesApp.Data.Models;
using CarSalesApp.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSalesApp.Data.Seeding
{
    public class CarsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Cars.Any())
            {
                return;
            }

            await dbContext.Cars.AddAsync(new Car
            {
                MakeId = 1,
                ModelId = 1,
                Title = "Opel Astra",
                BodyId = 2,
                Price = 1000,
                DriveId = 1,
                GeneralImg = " ",
                Color = (ColorType)Enum.Parse(typeof(ColorType), "Red"),
                FirstRegistration = new DateTime(2002, 10, 1),
            });
        }
    }
}
