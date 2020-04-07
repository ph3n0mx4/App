using CarSalesApp.Data.Common.Repositories;
using CarSalesApp.Data.Models;
using CarSalesApp.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarSalesApp.Services.Data
{
    public class BodyCarService : IBodyCarService
    {
        private readonly IDeletableEntityRepository<Body> bodyRepository;

        public BodyCarService(IDeletableEntityRepository<Body> bodyRepository)
        {
            this.bodyRepository = bodyRepository;
        }

        public IEnumerable<T> GetAll<T>()
        {
            IQueryable<Body> query = this.bodyRepository.All();
            return query.To<T>().ToList();
        }
    }
}
