namespace CarSalesApp.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using CarSalesApp.Data.Models;

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
