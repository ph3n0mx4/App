using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesApp.Services.Data
{
    public interface IModelCarService
    {
        IEnumerable<T> GetAll<T>();
    }
}
