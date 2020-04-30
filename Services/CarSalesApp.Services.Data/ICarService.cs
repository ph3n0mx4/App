namespace CarSalesApp.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CarSalesApp.Data.Models.Enums;

    public interface ICarService
    {
        IEnumerable<T> GetAll<T>(int? count = null);

        T GetById<T>(int id);

        Task<int> AddAsync(int makeId, int modelId, int driveId, int bodyId, MonthsOfYear month, int year, ColorType color, ICollection<int> inputFeatures, IEnumerable<string> inputImages, int mileage, decimal price, string inputMainImage, string description, string userId);

        Task<int> EditAsync(int carId, int makeId, int modelId, int driveId, int bodyId, MonthsOfYear month, int year, ColorType color, ICollection<int> inputFeatures, int mileage, decimal price, string description);
    }
}
