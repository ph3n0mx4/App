using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarSalesApp.Services.Data
{
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
