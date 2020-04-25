namespace CarSalesApp.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using CarSalesApp.Data.Models;

    public class FeatureTypesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.FeatureTypes.Any())
            {
                return;
            }

            await dbContext.FeatureTypes.AddRangeAsync(
                new FeatureType { Name = "Safety & Security" },
                new FeatureType { Name = "Comfort & Convenience" },
                new FeatureType { Name = "Entertainment & Media" },
                new FeatureType { Name = "Extras" });
        }
    }
}
