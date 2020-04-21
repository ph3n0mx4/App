using CarSalesApp.Data.Common.Repositories;
using CarSalesApp.Data.Models;
using System;
using System.Collections.Generic;
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
    }
}
