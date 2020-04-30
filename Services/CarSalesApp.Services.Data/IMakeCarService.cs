namespace CarSalesApp.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IMakeCarService
    {
        IEnumerable<T> GetAll<T>();

        T GetByName<T>(string name)
            where T : class;

        Task<int> AddAsync(string name);

        bool IsHasMakeName(string makeName);

        T GetById<T>(int id);
    }
}
