using CarSalesApp.Data.Common.Repositories;
using CarSalesApp.Data.Models;
using CarSalesApp.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarSalesApp.Services.Data.CarEntity
{
    public class EngineService : IEngineService
    {
        private readonly IDeletableEntityRepository<Drive> driveRepository;

        public EngineService(IDeletableEntityRepository<Drive> driveRepository)
        {
            this.driveRepository = driveRepository;
        }

        public async Task<int> AddAsync(int modelId, int fuelId, int displacement, int power, int gear, int gearType, int yearFrom, int yearTo)
        {
            var drive = new Drive
            {
                ModelId = modelId,
                Fuel = (FuelType)fuelId,
                Displacement = displacement,
                Power = power,
                GearType = (GearType)gearType,
                Gear = gear,
                YearFrom = new DateTime(yearFrom, 1, 1),
                YearTo = new DateTime(yearTo, 1, 1),
            };

            await this.driveRepository.AddAsync(drive);
            await this.driveRepository.SaveChangesAsync();
            return drive.Id;
        }
    }
}
