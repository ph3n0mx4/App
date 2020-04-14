using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarSalesApp.Services.Data
{
    public interface IMakeCarService
    {
        IEnumerable<T> GetAll<T>();

        T GetByName<T>(string name);

        Task<int> AddAsync(string name);

        bool IsHasMakeId(int makeId);

        bool IsHasMakeName(string makeName);
    }
}
