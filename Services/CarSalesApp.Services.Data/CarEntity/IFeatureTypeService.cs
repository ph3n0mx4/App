using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarSalesApp.Services.Data.CarEntity
{
    public interface IFeatureTypeService
    {
        IEnumerable<T> GetAll<T>();

        bool IsHasTypeName(string makeName);

        T GetByName<T>(string name);

        Task<int> AddAsync(string name);
    }
}
