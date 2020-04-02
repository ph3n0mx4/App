using System.Collections.Generic;
using System.Text;

namespace CarSalesApp.Services.Data
{
    public interface ICarService
    {
        IEnumerable<T> GetAll<T>(int? count = null);
    }
}
