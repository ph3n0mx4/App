using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesApp.Services.Data
{
    public interface IBodyCarService
    {
        IEnumerable<T> GetAll<T>();
    }
}
