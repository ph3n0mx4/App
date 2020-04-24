using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarSalesApp.Services.Data.CarEntity
{
    public interface IFeatureService
    {
        Task AddAsync(string name, int typeId);

        Task<IEnumerable<T>> GetAllOfTypeAsync<T>(string type);
    }
}
