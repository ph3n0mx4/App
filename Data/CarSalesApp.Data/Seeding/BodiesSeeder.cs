using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CarSalesApp.Data.Models;
using CarSalesApp.Data.Models.Enums;

namespace CarSalesApp.Data.Seeding
{
    public class BodiesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Bodies.Any())
            {
                return;
            }

            await dbContext.Bodies.AddAsync(new Body
            {
                Seats = 4,
                Doors = (DoorType)Enum.Parse(typeof(DoorType), "2"),
                Category = (CategoryType)Enum.Parse(typeof(CategoryType), "2"),
            });
        }
    }
}
