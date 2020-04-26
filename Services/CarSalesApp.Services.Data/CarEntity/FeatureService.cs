using CarSalesApp.Data.Common.Repositories;
using CarSalesApp.Data.Models;
using CarSalesApp.Services.Mapping;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarSalesApp.Services.Data.CarEntity
{
    public class FeatureService : IFeatureService
    {
        private readonly IDeletableEntityRepository<Feature> featureRepository;
        private readonly IDeletableEntityRepository<FeatureType> featureTypeRepository;

        public FeatureService(IDeletableEntityRepository<Feature> featureRepository, IDeletableEntityRepository<FeatureType> featureTypeRepository)
        {
            this.featureRepository = featureRepository;
            this.featureTypeRepository = featureTypeRepository;
        }

        public async Task AddAsync(string name, int typeId)
        {
            var feature = new Feature()
            {
                Name = name,
                TypeId = typeId,
            };

            await this.featureRepository.AddAsync(feature);
            await this.featureRepository.SaveChangesAsync();
        }

        public async Task<ICollection<T>> GetAllOfTypeAsync<T>(string type)
        {
            var currentType = this.featureTypeRepository.All().FirstOrDefault(x => x.Name == type);
            var features = await this.featureRepository.All()
                .Where(x => x.TypeId == currentType.Id)
                .To<T>()
                .ToListAsync();

            return features;
        }

        public async Task<ICollection<T>> GetAllOfTypeByCarIdAsync<T>(string type, int carId)
        {
            var currentType = this.featureTypeRepository.All().FirstOrDefault(x => x.Name == type);
            var features = await this.featureRepository.All()
                .Where(x => x.TypeId == currentType.Id && x.CarsFeatures.Any(y => y.CarId == carId))
                .To<T>()
                .ToListAsync();

            return features;
        }
    }
}
