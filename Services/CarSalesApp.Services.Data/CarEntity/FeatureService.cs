using CarSalesApp.Data.Common.Repositories;
using CarSalesApp.Data.Models;
using CarSalesApp.Services.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSalesApp.Services.Data.CarEntity
{
    public class FeatureService : IFeatureService
    {
        private readonly IDeletableEntityRepository<Feature> featureRepository;

        public FeatureService(IDeletableEntityRepository<Feature> featureRepository)
        {
            this.featureRepository = featureRepository;
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

        public async Task<IEnumerable<T>> GetAllOfTypeAsync<T>(string type)
        {
            var features = await this.featureRepository.All()
                .Where(x => x.Type.Name == type)
                .To<T>()
                .ToListAsync();

            return features;
        }
    }
}
