using CarSalesApp.Data.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CarSalesApp.Data.Seeding
{
    public class MakesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Makes.Any())
            {
                return;
            }

            await dbContext.Makes.AddRangeAsync(new Make { Name = "Opel", }, new Make { Name = "VW", });
        }
    }
}
