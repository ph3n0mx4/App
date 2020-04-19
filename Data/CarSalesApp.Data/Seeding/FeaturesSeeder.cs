using CarSalesApp.Data.Models;
using CarSalesApp.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSalesApp.Data.Seeding
{
    public class FeaturesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Features.Any())
            {
                return;
            }

            await dbContext.Features.AddRangeAsync(
                new Feature { Name = "Air conditioning", TypeId = 21 },
                new Feature { Name = "ABS", TypeId = 16 });
        }
    }
}
