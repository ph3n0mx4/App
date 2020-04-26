using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSalesApp.Services.Data
{
    public interface IModelCarService
    {
        IEnumerable<T> GetAll<T>();

        T GetByName<T>(string name);

        T GetById<T>(int id);

        Task<int> AddAsync(string name, int makeId);

        bool IsHasModelName(string modelName);

        Task<int> EditAsync(int id, string name, string makeName);
    }
}
