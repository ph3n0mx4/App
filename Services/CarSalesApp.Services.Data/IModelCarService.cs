namespace CarSalesApp.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IModelCarService
    {
        IEnumerable<T> GetAll<T>();

        IEnumerable<T> GetAllByMakeId<T>(int makeId);

        T GetByName<T>(string name)
            where T : class;

        T GetById<T>(int id);

        Task<int> AddAsync(string name, int makeId);

        Task<int> EditAsync(int id, string name, string makeName);
    }
}
