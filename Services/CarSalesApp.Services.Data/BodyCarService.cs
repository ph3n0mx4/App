﻿namespace CarSalesApp.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CarSalesApp.Data.Common.Repositories;
    using CarSalesApp.Data.Models;
    using CarSalesApp.Data.Models.Enums;
    using CarSalesApp.Services.Mapping;

    public class BodyCarService : IBodyCarService
    {
        private readonly IDeletableEntityRepository<Body> bodyRepository;

        public BodyCarService(IDeletableEntityRepository<Body> bodyRepository)
        {
            this.bodyRepository = bodyRepository;
        }

        public async Task<int> AddAsync(int category, int seats, int doors)
        {
            var body = new Body
            {
                Category = (CategoryType)category,
                Seats = seats,
                Doors = (DoorType)doors,
            };

            await this.bodyRepository.AddAsync(body);
            await this.bodyRepository.SaveChangesAsync();
            return body.Id;
        }

        public IEnumerable<T> GetAll<T>()
        {
            IQueryable<Body> query = this.bodyRepository.All();
            return query.To<T>().ToList();
        }
    }
}
