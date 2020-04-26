using CarSalesApp.Data.Common.Repositories;
using CarSalesApp.Data.Models;
using CarSalesApp.Data.Models.Enums;
using CarSalesApp.Services.Mapping;
using System;
using System.Linq;
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

        public async Task<int> AddAsync(int modelId, int fuelId, int displacement, int power, int gearType, int gear, int yearFrom, int yearTo)
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

        public async Task<int> EditAsync(int id, int displacement, int gear, int gearType, int power, int yearFrom, int yearTo)
        {
            var engine = this.driveRepository.All().FirstOrDefault(m => m.Id == id);

            engine.Displacement = displacement;
            engine.Gear = gear;
            engine.GearType = (GearType)gearType;
            engine.Power = power;
            engine.YearFrom = new DateTime(yearFrom, 1, 1);
            engine.YearTo = new DateTime(yearTo, 1, 1);

            this.driveRepository.Update(engine);
            await this.driveRepository.SaveChangesAsync();

            return engine.Id;
        }

        public T GetById<T>(int id)
        {
            var engine = this.driveRepository.All()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefault();
            return engine;
        }
    }
}
