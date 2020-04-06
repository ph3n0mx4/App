using CarSalesApp.Data.Common.Repositories;
using CarSalesApp.Data.Models;
using CarSalesApp.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesApp.Services.Data
{
    public class CarService : ICarService
    {
        private IDeletableEntityRepository<Car> carRepository;

        public CarService(IDeletableEntityRepository<Car> carRepository)
        {
            this.carRepository = carRepository;
        }

        public IEnumerable<T> GetAll<T>(int? count = null)
        {
            IQueryable<Car> query = this.carRepository.All();

            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

            return query.To<T>().ToList();
        }
    }
}
