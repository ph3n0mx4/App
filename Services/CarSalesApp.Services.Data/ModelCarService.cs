using CarSalesApp.Data.Common.Repositories;
using CarSalesApp.Data.Models;
using CarSalesApp.Services.Mapping;
//using CarSalesApp.Web.ViewModels.Cars;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<int> AddAsync(string name, int makeId)
        {
            var model = new Model()
            {
                Name = name,
                MakeId = makeId,
            };

            await this.modelRepository.AddAsync(model);
            await this.modelRepository.SaveChangesAsync();
            return model.Id;
        }

        public async Task<int> EditAsync(int id, string name, string makeName)
        {
            //public async Task EditPostContent(EditPostModel model)
            //{
            //    var post = await this.GetByIdAsync(model.PostId);
            //    post.Content = new HtmlSanitizer().Sanitize(model.Content);
            //    this.postsRepository.Update(post);
            //    await this.postsRepository.SaveChangesAsync();
            //}

            var model = this.modelRepository.All().FirstOrDefault(m => m.Id == id);
            model.Name = name;
            model.Make.Name = makeName;
            this.modelRepository.Update(model);
            await this.modelRepository.SaveChangesAsync();
            return model.Id;
        }

        public T GetByName<T>(string name)
        {
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

        public async Task<Model> GetByIdAsync(int id)
        {
            var obj = await this.modelRepository.All().Where(x => x.Id == id).FirstOrDefaultAsync();

            return obj;
        }

        public bool IsHasModelName(string modelName)
        {
            var currentMake = this.modelRepository.All()
                .Where(x => x.Name == modelName)
                .Select(x => x.Name)
                .FirstOrDefault();

            return currentMake == modelName;
        }
    }
}
