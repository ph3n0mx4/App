﻿using CarSalesApp.Data.Common.Repositories;
using CarSalesApp.Data.Models;
using CarSalesApp.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSalesApp.Services.Data
{
    public class MakeCarService : IMakeCarService
    {
        private readonly IDeletableEntityRepository<Make> makeRepository;

        public MakeCarService(IDeletableEntityRepository<Make> makeRepository)
        {
            this.makeRepository = makeRepository;
        }

        public async Task<int> AddAsync(string name)
        {
            var make = new Make
            {
                Name = name,
            };

            await this.makeRepository.AddAsync(make);
            await this.makeRepository.SaveChangesAsync();
            return make.Id;
        }

        public IEnumerable<T> GetAll<T>()
        {
            IQueryable<Make> query = this.makeRepository.All();
            return query.To<T>().ToList();
        }

        public T GetByName<T>(string name)
        {
            var make = this.makeRepository.All()
                .Where(x => x.Name.ToLower() == name.ToLower())
                .To<T>().FirstOrDefault();
            return make;
        }

        public bool IsHasMakeId(int makeId)
        {
            var currentMake = this.makeRepository.All()
                .Where(x => x.Id == makeId)
                .Select(x => x.Id)
                .FirstOrDefault();

            return currentMake == makeId;
        }

        public bool IsHasMakeName(string makeName)
        {
            var currentMake = this.makeRepository.All()
                .Where(x => x.Name == makeName)
                .Select(x => x.Name)
                .FirstOrDefault();

            return currentMake == makeName;
        }
    }
}
