using CarSalesApp.Data.Common.Repositories;
using CarSalesApp.Data.Models;
using CarSalesApp.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    }
}
