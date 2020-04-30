namespace CarSalesApp.Services.Data.CarEntity
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IFeatureTypeService
    {
        IEnumerable<T> GetAll<T>();

        bool IsHasTypeName(string makeName);

        T GetByName<T>(string name);

        Task<int> AddAsync(string name);
    }
}
