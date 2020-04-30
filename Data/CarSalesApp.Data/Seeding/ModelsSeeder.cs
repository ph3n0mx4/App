namespace CarSalesApp.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using CarSalesApp.Data.Models;

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
