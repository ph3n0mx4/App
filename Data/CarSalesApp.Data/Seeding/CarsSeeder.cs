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
                BodyId = 1,
                Price = 1000,
                DriveId = 1,
                GeneralImg = "https://prod.pictures.autoscout24.net/listing-images/f2497c98-7bb6-487f-e053-e250040ad15e_9cb26a4c-65e9-4efb-aa2f-81e9b3f96977.jpg/1280x960.jpg",
                Color = (ColorType)Enum.Parse(typeof(ColorType), "Red"),
                FirstRegistration = new DateTime(2002, 10, 1),
            });
        }
    }
}
