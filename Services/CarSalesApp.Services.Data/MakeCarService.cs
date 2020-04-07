using CarSalesApp.Data.Common.Repositories;
using CarSalesApp.Data.Models;
using CarSalesApp.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarSalesApp.Services.Data
{
    public class MakeCarService : IMakeCarService
    {
        private readonly IDeletableEntityRepository<Make> makeRepository;

        public MakeCarService(IDeletableEntityRepository<Make> makeRepository)
        {
            this.makeRepository = makeRepository;
        }

        public IEnumerable<T> GetAll<T>(int? id = null)
        {
            IQueryable<Make> query = this.makeRepository.All();

            if (id.HasValue)
            {
                query = query.Where(x => x.Id == id.Value);
            }

            return query.To<T>().ToList();
        }
    }
}
