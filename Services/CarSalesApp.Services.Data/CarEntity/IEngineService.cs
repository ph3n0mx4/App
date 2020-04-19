using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarSalesApp.Services.Data.CarEntity
{
    public interface IEngineService
    {
        Task<int> AddAsync(int modelId, int fuelId, int cc, int power, int gear, int gearType, int yearFrom, int yearTo);
    }
}
