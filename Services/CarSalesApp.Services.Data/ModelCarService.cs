namespace CarSalesApp.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CarSalesApp.Data.Common.Repositories;
    using CarSalesApp.Data.Models;
    using CarSalesApp.Services.Mapping;

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

        public IEnumerable<T> GetAllByMakeId<T>(int makeId)
        {
            IQueryable query = this.modelRepository.All()
                .Where(x => x.MakeId == makeId);
            return query.To<T>().ToList();
        }

        public async Task<int> AddAsync(string name, int makeId)
        {
            //check for existing entity
            var model = new Model()
            {
                Name = name,
                MakeId = makeId,
            };

            await this.modelRepository.AddAsync(model);
            await this.modelRepository.SaveChangesAsync();
            return model.Id;
        }

        public async Task<int> EditAsync(
            int currentModelId, string newModelName, string newMakeName)
        {
            var model = this.modelRepository.All().FirstOrDefault(m => m.Id == currentModelId);
            model.Name = newModelName;
            model.Make.Name = newMakeName;
            this.modelRepository.Update(model);
            await this.modelRepository.SaveChangesAsync();
            return model.Id;
        }

        public T GetByName<T>(string name)
            where T : class
        {
            if (name == null)
            {
                return null;
            }

            var model = this.modelRepository.All()
                .Where(x => x.Name.ToLower() == name.ToLower())
                .To<T>()
                .FirstOrDefault();
            return model;
        }

        public T GetById<T>(int id)
        {
            var model = this.modelRepository.All()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefault();
            return model;
        }
    }
}
