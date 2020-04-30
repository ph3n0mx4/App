namespace CarSalesApp.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IBodyCarService
    {
        IEnumerable<T> GetAll<T>();

        Task<int> AddAsync(int category, int seats, int doors);
    }
}
