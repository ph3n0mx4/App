namespace CarSalesApp.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CarSalesApp.Data.Common.Repositories;
    using CarSalesApp.Data.Models;
    using CarSalesApp.Services.Mapping;

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

        public T GetByName<T>(string makeName)
            where T : class
        {
            if (makeName == null)
            {
                return null;
            }

            var make = this.makeRepository.All()
                .Where(x => x.Name.ToLower() == makeName.ToLower())
                .To<T>().FirstOrDefault();
            return make;
        }

        public bool IsHasMakeName(string makeName)
        {
            if (makeName == null)
            {
                return false;
            }

            var currentMake = this.makeRepository.All()
                .Where(x => x.Name == makeName)
                .Select(x => x.Name)
                .FirstOrDefault();

            return currentMake == makeName;
        }

        public T GetById<T>(int id)
        {
            var make = this.makeRepository.All()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefault();
            return make;
        }
    }
}
