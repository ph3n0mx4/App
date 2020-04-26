using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSalesApp.Services.Data.CarEntity
{
    public interface IFeatureService
    {
        Task AddAsync(string name, int typeId);

        Task<ICollection<T>> GetAllOfTypeAsync<T>(string type);

        Task<ICollection<T>> GetAllOfTypeByCarIdAsync<T>(string type, int carId);
    }
}
