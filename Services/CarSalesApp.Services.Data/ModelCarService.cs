using CarSalesApp.Data.Common.Repositories;
using CarSalesApp.Data.Models;
using CarSalesApp.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSalesApp.Services.Data
{
    public class ModelCarService : IModelCarService
    {
        private readonly IDeletableEntityRepository<Model> modelRepository;

        public ModelCarService(IDeletableEntityRepository<Model> modelRepository)
        {
            this.modelRepository = modelRepository;
        }

        public IEnumerable<T> GetAll<T>()
        {
            IQueryable query = this.modelRepository.All();
            return query.To<T>().ToList();
        }

        public async Task AddAsync(string name, int makeId)
        {
            var model = new Model()
            {
                Name = name,
                MakeId = makeId,
            };

            await this.modelRepository.AddAsync(model);
            await this.modelRepository.SaveChangesAsync();
        }

        public T GetByName<T>(string name)
        {
            var model = this.modelRepository.All()
                .Where(x => x.Name.ToLower() == name.ToLower())
                .To<T>().FirstOrDefault();
            return model;
        }

        public bool IsHasModelName(string modelName)
        {
            var currentMake = this.modelRepository.All()
                .Where(x => x.Name == modelName)
                .Select(x => x.Name)
                .FirstOrDefault();

            return currentMake == modelName;
        }
    }
}
