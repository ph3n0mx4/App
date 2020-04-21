using CarSalesApp.Data.Common.Repositories;
using CarSalesApp.Data.Models;
using CarSalesApp.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSalesApp.Services.Data.CarEntity
{
    public class FeatureTypeService : IFeatureTypeService
    {
        private readonly IDeletableEntityRepository<FeatureType> featureTypeRepository;

        public FeatureTypeService(IDeletableEntityRepository<FeatureType> featureTypeRepository)
        {
            this.featureTypeRepository = featureTypeRepository;
        }

        public IEnumerable<T> GetAll<T>()
        {
            IQueryable<FeatureType> query = this.featureTypeRepository.All();
            return query.To<T>().ToList();
        }

        public T GetByName<T>(string name)
        {
            var type = this.featureTypeRepository.All()
                .Where(x => x.Name.ToLower() == name.ToLower())
                .To<T>().FirstOrDefault();
            return type;
        }

        public bool IsHasTypeName(string typeName)
        {
            var currentType = this.featureTypeRepository.All()
                .Where(x => x.Name == typeName)
                .Select(x => x.Name)
                .FirstOrDefault();

            return currentType == typeName;
        }

        public async Task<int> AddAsync(string name)
        {
            var type = new FeatureType
            {
                Name = name,
            };

            await this.featureTypeRepository.AddAsync(type);
            await this.featureTypeRepository.SaveChangesAsync();
            return type.Id;
        }
    }
}
