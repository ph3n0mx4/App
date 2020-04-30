namespace CarSalesApp.Services.Data.CarEntity
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IEngineService
    {
        Task<int> AddAsync(int modelId, int fuelId, int cc, int power, int gear, int gearType, int yearFrom, int yearTo);

        T GetById<T>(int id);

        Task<int> EditAsync(int id, int displacement, int gear, int gearType, int power, int yearFrom, int yearTo);

        IEnumerable<T> GetAllByModelIdAndFuelId<T>(int modelId, int fuelId);
    }
}
