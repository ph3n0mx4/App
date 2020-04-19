using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarSalesApp.Services.Data
{
    public interface IBodyCarService
    {
        IEnumerable<T> GetAll<T>();

        Task<int> AddAsync(int category, int seats, int doors);
    }
}
