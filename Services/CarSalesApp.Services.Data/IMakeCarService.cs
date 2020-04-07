using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesApp.Services.Data
{
    public interface IMakeCarService
    {
        IEnumerable<T> GetAll<T>(int? id = null);
    }
}
