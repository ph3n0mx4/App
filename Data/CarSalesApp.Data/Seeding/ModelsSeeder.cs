using CarSalesApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSalesApp.Data.Seeding
{
    public class ModelsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Models.Any())
            {
                return;
            }

            await dbContext.Models.AddRangeAsync(new Model { Name = "Astra", MakeId = 1 }, new Model { Name = "Golf", MakeId = 2 });
        }
    }
}
