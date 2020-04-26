namespace CarSalesApp.Data.Seeding
{
    using CarSalesApp.Data.Models;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

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
