using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarSalesApp.Services.Data
{
    public interface IModelCarService
    {
        IEnumerable<T> GetAll<T>();

        T GetByName<T>(string name);

        T GetById<T>(int id);

        Task AddAsync(string name, int makeId);

        bool IsHasModelName(string modelName);
    }
}
